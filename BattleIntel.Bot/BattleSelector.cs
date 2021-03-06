﻿using BattleIntel.Core;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleIntel.Bot
{
    public partial class BattleSelector : Form
    {
        public Battle SelectedBattle { get; private set; }

        public BattleSelector()
        {
            InitializeComponent();

            dtpBattleStarts.Value = DateTime.Today;
            dtpBattleEnds.Value = DateTime.Today.AddDays(3);
            listBox1.DisplayMember = "Name";
            
            NH.UsingSession(s =>
            {
                LoadBattles(s);
            });
        }

        private void btnCreateBattle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBattleName.Text))
            {
                MessageBox.Show(this, "Please enter a battle name.");
                return;
            }

            NH.UsingSession(s =>
            {
                var b = new Battle
                {
                    Name = txtBattleName.Text,
                    StartDateUTC = dtpBattleStarts.Value.ToUniversalTime(),
                    EndDateUTC = dtpBattleEnds.Value.ToUniversalTime()
                };
                s.Save(b);

                LoadBattles(s);
            });
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedBattle = listBox1.SelectedItem as Battle;
            if (SelectedBattle == null)
            {
                MessageBox.Show(this, "Please select a battle.");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void LoadBattles(ISession s)
        {
            listBox1.Items.Clear();

            var battles = s.QueryOver<Battle>()
                .OrderBy(x => x.StartDateUTC).Desc
                .List();

            listBox1.Items.AddRange(battles.ToArray());
        }
    }
}
