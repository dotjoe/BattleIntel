﻿using BattleIntel.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleIntel.DesktopTool
{
    public partial class StatParserForm : Form
    {
        private IList<Stat> Stats;

        public StatParserForm()
        {
            InitializeComponent();

            cbCopyForSheetMode.SelectedIndex = 0;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsText()) return;
            var lines = GetClipboardLines();
            if (!lines.Any()) return;

            txtTeamName.Text = "";

            //check if we copied from a spreadsheet having the team name on every line separated by a tab.
            if (lines.Count() == lines.Where(x => x.Contains('\t')).Count())
            {
                //use it if every line has the same team name
                var teamNames = lines.Select(x => x.Split('\t').First().Trim()).Distinct(StringComparer.OrdinalIgnoreCase);
                if (teamNames.Count() == 1)
                {
                    txtTeamName.Text = teamNames.First();
                    //remove the team name from all the lines
                    lines = lines.Select(x => string.Join(" ", x.Split('\t').Skip(1).ToArray()));
                }
            }
            else
            {
                //check for team name on the first line
                var firstLineStat = Stat.Parse(lines.First());
                if (firstLineStat.Level == null && firstLineStat.Defense == null)
                {
                    txtTeamName.Text = firstLineStat.Name;
                    lines = lines.Skip(1);
                }
            }

            txtTeamStats.Text = string.Join(Environment.NewLine, lines.ToArray());
        }

        private void btnAppend_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsText()) return;
            var lines = GetClipboardLines();
            if (!lines.Any()) return;
            
            //append to the stats
            txtTeamStats.Text += Environment.NewLine + string.Join(Environment.NewLine, lines.ToArray());
        }

        private IEnumerable<string> GetClipboardLines()
        {
            return Clipboard.GetText(TextDataFormat.UnicodeText)
                .Trim('"') //trim the quotations from a possible cell copy
                .Split('\n')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim());
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            Stats = txtTeamStats.Lines
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => Stat.Parse(x.Trim()))
                    .Distinct()
                    .OrderByDescending(x => x.Level)
                    .ThenByDescending(x => x.DefenseValue)
                    .ThenBy(x => x.Name)
                    .ToList();

            txtTeamStatsOutput.Text = String.Join(Environment.NewLine, Stats.Select(x => x.ToString()).ToArray());
        }

        private void btnCopyForScout_Click(object sender, EventArgs e)
        {
            //team name on first line followed by stats
            var teamName = "";
            if(!string.IsNullOrWhiteSpace(txtTeamName.Text))
            {
                teamName = txtTeamName.Text.Trim() + Environment.NewLine;
            }

            //just use the stats ouput text
            var toClip = teamName + txtTeamStatsOutput.Text;
            if (string.IsNullOrEmpty(toClip)) return;
            
            Clipboard.SetText(toClip);
        }

        private void btnCopyForSheet_Click(object sender, EventArgs e)
        {
            if (Stats == null || Stats.Count == 0) return;

            //default team name to a single space
            var teamName = " \t"; 
            if(!string.IsNullOrWhiteSpace(txtTeamName.Text))
            {
                teamName = txtTeamName.Text.Trim() + "\t";
            }

            string toClip = null;
            var copyMode = GetCopyForSheetMode();

            if (copyMode == CopyForSheetMode.Cell)
            {
                //repeat the teamName above the stats for easy copy
                toClip = teamName + "\"" + teamName + "\n" + string.Join("\n", Stats.Select(x => x.ToString())) + "\"";
            }
            else if (copyMode == CopyForSheetMode.TwoColumns)
            {
                toClip = string.Join(Environment.NewLine, Stats.Select(x => teamName + x.ToString()));
            }
            else if (copyMode == CopyForSheetMode.MultiColumns)
            {
                toClip = string.Join(Environment.NewLine, Stats.Select(x => teamName + x.ToString("\t")));
            }

            if (string.IsNullOrEmpty(toClip)) return;
            
            Clipboard.SetText(toClip);
        }

        private CopyForSheetMode GetCopyForSheetMode()
        {
            return (CopyForSheetMode)cbCopyForSheetMode.SelectedIndex;
        }

        private enum CopyForSheetMode
        {
            Cell = 0,
            TwoColumns = 1,
            MultiColumns = 2
        }
    }
}
