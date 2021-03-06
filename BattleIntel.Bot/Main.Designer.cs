﻿namespace BattleIntel.Bot
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.nupIntervalSeconds = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGroupMeRoom = new System.Windows.Forms.Label();
            this.lblSheet = new System.Windows.Forms.Label();
            this.txtSheetURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBattle = new System.Windows.Forms.Label();
            this.lblBattleDates = new System.Windows.Forms.Label();
            this.cbPostSheetUrl = new System.Windows.Forms.CheckBox();
            this.pnlBotControls = new System.Windows.Forms.Panel();
            this.btnWriteSheet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupIntervalSeconds)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlBotControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(84, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.Location = new System.Drawing.Point(12, 133);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(524, 312);
            this.txtConsole.TabIndex = 3;
            // 
            // nupIntervalSeconds
            // 
            this.nupIntervalSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nupIntervalSeconds.Location = new System.Drawing.Point(467, 7);
            this.nupIntervalSeconds.Maximum = new decimal(new int[] {
            7200,
            0,
            0,
            0});
            this.nupIntervalSeconds.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nupIntervalSeconds.Name = "nupIntervalSeconds";
            this.nupIntervalSeconds.Size = new System.Drawing.Size(54, 20);
            this.nupIntervalSeconds.TabIndex = 4;
            this.nupIntervalSeconds.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nupIntervalSeconds.ValueChanged += new System.EventHandler(this.nupIntervalSeconds_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Interval";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblGroupMeRoom, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSheet, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSheetURL, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBattle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBattleDates, 1, 1);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 14);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(524, 111);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "GroupMe Room";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.tableLayoutPanel1.SetRowSpan(this.label4, 2);
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Google Sheet";
            // 
            // lblGroupMeRoom
            // 
            this.lblGroupMeRoom.AutoSize = true;
            this.lblGroupMeRoom.Location = new System.Drawing.Point(100, 40);
            this.lblGroupMeRoom.Name = "lblGroupMeRoom";
            this.lblGroupMeRoom.Size = new System.Drawing.Size(0, 14);
            this.lblGroupMeRoom.TabIndex = 4;
            // 
            // lblSheet
            // 
            this.lblSheet.AutoSize = true;
            this.lblSheet.Location = new System.Drawing.Point(100, 60);
            this.lblSheet.Name = "lblSheet";
            this.lblSheet.Size = new System.Drawing.Size(0, 14);
            this.lblSheet.TabIndex = 5;
            // 
            // txtSheetURL
            // 
            this.txtSheetURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSheetURL.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSheetURL.Location = new System.Drawing.Point(100, 83);
            this.txtSheetURL.Name = "txtSheetURL";
            this.txtSheetURL.ReadOnly = true;
            this.txtSheetURL.Size = new System.Drawing.Size(421, 20);
            this.txtSheetURL.TabIndex = 7;
            this.txtSheetURL.Enter += new System.EventHandler(this.txtSheetURL_Enter);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Battle";
            // 
            // lblBattle
            // 
            this.lblBattle.AutoSize = true;
            this.lblBattle.Location = new System.Drawing.Point(100, 0);
            this.lblBattle.Name = "lblBattle";
            this.lblBattle.Size = new System.Drawing.Size(0, 14);
            this.lblBattle.TabIndex = 3;
            // 
            // lblBattleDates
            // 
            this.lblBattleDates.AutoSize = true;
            this.lblBattleDates.Location = new System.Drawing.Point(100, 20);
            this.lblBattleDates.Name = "lblBattleDates";
            this.lblBattleDates.Size = new System.Drawing.Size(0, 14);
            this.lblBattleDates.TabIndex = 8;
            // 
            // cbPostSheetUrl
            // 
            this.cbPostSheetUrl.AutoSize = true;
            this.cbPostSheetUrl.Checked = true;
            this.cbPostSheetUrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPostSheetUrl.Location = new System.Drawing.Point(165, 7);
            this.cbPostSheetUrl.Name = "cbPostSheetUrl";
            this.cbPostSheetUrl.Size = new System.Drawing.Size(103, 17);
            this.cbPostSheetUrl.TabIndex = 7;
            this.cbPostSheetUrl.Text = "Post Sheet URL";
            this.cbPostSheetUrl.UseVisualStyleBackColor = true;
            this.cbPostSheetUrl.CheckedChanged += new System.EventHandler(this.cbPostSheetUrl_CheckedChanged);
            // 
            // pnlBotControls
            // 
            this.pnlBotControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBotControls.Controls.Add(this.btnWriteSheet);
            this.pnlBotControls.Controls.Add(this.btnStart);
            this.pnlBotControls.Controls.Add(this.cbPostSheetUrl);
            this.pnlBotControls.Controls.Add(this.label1);
            this.pnlBotControls.Controls.Add(this.btnStop);
            this.pnlBotControls.Controls.Add(this.nupIntervalSeconds);
            this.pnlBotControls.Location = new System.Drawing.Point(12, 451);
            this.pnlBotControls.Name = "pnlBotControls";
            this.pnlBotControls.Size = new System.Drawing.Size(524, 31);
            this.pnlBotControls.TabIndex = 8;
            // 
            // btnWriteSheet
            // 
            this.btnWriteSheet.Location = new System.Drawing.Point(274, 3);
            this.btnWriteSheet.Name = "btnWriteSheet";
            this.btnWriteSheet.Size = new System.Drawing.Size(75, 23);
            this.btnWriteSheet.TabIndex = 8;
            this.btnWriteSheet.Text = "Write Sheet";
            this.btnWriteSheet.UseVisualStyleBackColor = true;
            this.btnWriteSheet.Click += new System.EventHandler(this.btnWriteSheet_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 494);
            this.Controls.Add(this.pnlBotControls);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtConsole);
            this.Name = "Main";
            this.Text = "Intel Bot";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupIntervalSeconds)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlBotControls.ResumeLayout(false);
            this.pnlBotControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.NumericUpDown nupIntervalSeconds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBattle;
        private System.Windows.Forms.Label lblGroupMeRoom;
        private System.Windows.Forms.Label lblSheet;
        private System.Windows.Forms.CheckBox cbPostSheetUrl;
        private System.Windows.Forms.TextBox txtSheetURL;
        private System.Windows.Forms.Label lblBattleDates;
        private System.Windows.Forms.Panel pnlBotControls;
        private System.Windows.Forms.Button btnWriteSheet;
    }
}

