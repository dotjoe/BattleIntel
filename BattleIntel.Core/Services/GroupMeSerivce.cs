﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupMe
{
    using GroupMe.Models;
    using Newtonsoft.Json;
    using System.Collections.Specialized;
    using System.IO;
    using System.Net;
    using System.Threading;

    public class GroupMeService
    {
        private const string apiBaseUrl = @"https://api.groupme.com/v3";
        private readonly string accessToken;

        public GroupMeService(string accessToken)
        {
            this.accessToken = accessToken;
        }

        public IList<Group> GroupsIndex(int page = 1, int per_page = 10)
        {
            string action = string.Format("groups?page={0}&per_page={1}", page, per_page);
            return GET<IList<Group>>(action);
        }

        /// <summary>
        /// Returns the last 20 messages, ordered by created_at descending. 
        /// Use the before_message_id param to page back in time.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="before_message_id">get 20 message before this message</param>
        /// <returns></returns>
        public IList<GroupMessage> GroupMessages(string groupId, string before_message_id = null)
        {
            string action = string.Format("groups/{0}/messages", groupId);

            if (before_message_id != null)
            {
                action += "?before_id=" + WebUtility.UrlEncode(before_message_id);
            }

            try
            {
                return GET<GroupMessages>(action).messages;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError
                    && ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotModified)
                {
                    return new List<GroupMessage>(); //empty list, we hit the beginning of the group
                }
                throw;
            }
        }

        /// <summary>
        /// Returns ALL messages between the from and to dates (optionally after the afterMessageId), order by created_at ascending.
        /// This is not part of the GroupMe API, it is many calls to the GroupMessages()
        /// function using the before_message_id parameter.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="afterMessageId"></param>
        /// <returns></returns>
        public IList<GroupMessage> GroupMessagesByDateRange(string groupId, DateTime fromDate, DateTime toDate, string afterMessageId)
        {
            //have to page back in time until we hit our after_message_id
            var results = new List<GroupMessage>();

            int fromEpoch = fromDate.ToEpoch();
            int toEpoch = toDate.ToEpoch();

            string beforeMessageId = null;

            while (true)
            {
                var page = GroupMessages(groupId, beforeMessageId);
                if (page == null || page.Count() == 0) break; //reached the start of the group

                var inTopRange = page.SkipWhile(x => x.created_at > toEpoch);
                if (inTopRange.Count() > 0)
                {
                    var inRange = inTopRange.TakeWhile(x => x.created_at >= fromEpoch && (afterMessageId == null || x.id != afterMessageId));
                    if (inRange.Count() == 0) break; //done, we went before the range or hit the afterMessage

                    results.AddRange(inRange);

                    if (inRange.Count() != inTopRange.Count()) break; //done, we reached the bottom of the range
                }

                beforeMessageId = page.Last().id;
                Thread.Sleep(2000); //Enhancing my calm to avoid rate limiting
            }

            //reverse the list to sort by created_at ascending
            results.Reverse();

            return results;
        }

        public GroupMessage PostGroupMessage(string groupId, string text)
        {
            //TODO split up text greater than 450 chars
            string action = string.Format("groups/{0}/messages", groupId);

            var data = new PostMessageContainer { 
                message = new PostMessage { 
                    source_guid = Guid.NewGuid().ToString(), 
                    text = text 
                } 
            };

            return POST<GroupMessageContainer>(action, data).message;
        }

        private T GET<T>(string action) where T: class
        {
            var url = string.Format("{0}/{1}", apiBaseUrl, action.TrimStart('/'));
            var request = (HttpWebRequest)WebRequest.Create(url);
            
            request.Method = "GET";
            request.Accept = "application/json";
            request.Headers.Add("X-Access-Token", accessToken);

            ResponseEnvelope<T> envelope;

            
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var obj = reader.ReadToEnd();
                envelope = JsonConvert.DeserializeObject<ResponseEnvelope<T>>(obj);
            }

            return envelope.response;
        }

        private T POST<T>(string action, object data)
        {
            var url = string.Format("{0}/{1}", apiBaseUrl, action.TrimStart('/'));
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.Accept = "application/json";
            request.Headers.Add("X-Access-Token", accessToken);

            if (data != null)
            {
                string dataString = JsonConvert.SerializeObject(data);
                byte[] bytes = new ASCIIEncoding().GetBytes(dataString);

                request.ContentType = "application/json; charset=utf-8";
                request.ContentLength = bytes.Length;

                Stream reqStream = request.GetRequestStream();
                reqStream.Write(bytes, 0, bytes.Length);
                reqStream.Close();
            }

            ResponseEnvelope<T> envelope;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var obj = reader.ReadToEnd();
                envelope = JsonConvert.DeserializeObject<ResponseEnvelope<T>>(obj);
            }

            return envelope.response;
        }
    }

    public static class EpochExtensions
    {
        public static int ToEpoch(this DateTime d)
        {
            return (int)(d.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        public static DateTime ToDateTime(this int epoch, DateTimeKind kind)
        {
            var d = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
            if (kind == DateTimeKind.Local) d = d.ToLocalTime();
            return d;
        }

        public static DateTime ToUniversalTime(this int epoch)
        {
            return epoch.ToDateTime(DateTimeKind.Utc);
        }

        public static DateTime ToLocalTime(this int epoch)
        {
            return epoch.ToDateTime(DateTimeKind.Local);
        }
    }
}

namespace GroupMe.Models { 

    class ResponseEnvelope<T> 
    {
        public T response { get; set; }
        public Meta meta { get; set; }
    }

    class Meta
    {
        public int code { get; set; }
        public List<string> errors { get; set; }
    }

    public class Group
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class GroupMessages
    {
        public int count { get; set; }
        public List<GroupMessage> messages { get; set; }
    }

    public class GroupMessage
    {
        public string id { get; set; }
        public int created_at { get; set; }
        public string user_id { get; set; }
        public string group_id { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public bool system { get; set; }
        //public List<Attachment> attachments { get; set; }
    }

    public class PostMessageContainer
    {
        public PostMessage message { get; set; }
    }

    public class PostMessage
    {
        public string source_guid { get; set; }
        public string text { get; set; }
    }

    public class GroupMessageContainer
    {
        public GroupMessage message { get; set; }
    }
}