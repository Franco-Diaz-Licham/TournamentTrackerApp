namespace TrackerUI
{
    partial class TournamentViewerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tournamentHeaderLabel = new Label();
            tournamentName = new Label();
            roundLabel = new Label();
            roundsDropDown = new ComboBox();
            unplayedOnlyCheckBox = new CheckBox();
            matchupListBox = new ListBox();
            teamOneLabel = new Label();
            teamOneScoreValue = new TextBox();
            TeamOneScoreLabel = new Label();
            TeamTwoScoreLabel = new Label();
            teamTwoScoreValue = new TextBox();
            teamTwoLabel = new Label();
            versusLabel = new Label();
            scoreButton = new Button();
            tournamentDashboardLabel = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // tournamentHeaderLabel
            // 
            tournamentHeaderLabel.AutoSize = true;
            tournamentHeaderLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            tournamentHeaderLabel.ForeColor = SystemColors.MenuHighlight;
            tournamentHeaderLabel.Location = new Point(17, 71);
            tournamentHeaderLabel.Name = "tournamentHeaderLabel";
            tournamentHeaderLabel.Size = new Size(93, 19);
            tournamentHeaderLabel.TabIndex = 0;
            tournamentHeaderLabel.Text = "Tournament:";
            // 
            // tournamentName
            // 
            tournamentName.AutoSize = true;
            tournamentName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tournamentName.ForeColor = SystemColors.MenuHighlight;
            tournamentName.Location = new Point(143, 73);
            tournamentName.Name = "tournamentName";
            tournamentName.Size = new Size(55, 17);
            tournamentName.TabIndex = 1;
            tournamentName.Text = "<none>";
            // 
            // roundLabel
            // 
            roundLabel.AutoSize = true;
            roundLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            roundLabel.ForeColor = SystemColors.MenuHighlight;
            roundLabel.Location = new Point(17, 107);
            roundLabel.Name = "roundLabel";
            roundLabel.Size = new Size(52, 19);
            roundLabel.TabIndex = 2;
            roundLabel.Text = "Round";
            // 
            // roundsDropDown
            // 
            roundsDropDown.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            roundsDropDown.FormattingEnabled = true;
            roundsDropDown.Location = new Point(143, 107);
            roundsDropDown.Name = "roundsDropDown";
            roundsDropDown.Size = new Size(146, 25);
            roundsDropDown.TabIndex = 3;
            roundsDropDown.SelectedIndexChanged += RoundsDropDown_SelectedIndexChanged;
            // 
            // unplayedOnlyCheckBox
            // 
            unplayedOnlyCheckBox.AutoSize = true;
            unplayedOnlyCheckBox.FlatStyle = FlatStyle.Flat;
            unplayedOnlyCheckBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            unplayedOnlyCheckBox.ForeColor = SystemColors.MenuHighlight;
            unplayedOnlyCheckBox.Location = new Point(456, 69);
            unplayedOnlyCheckBox.Name = "unplayedOnlyCheckBox";
            unplayedOnlyCheckBox.Size = new Size(111, 21);
            unplayedOnlyCheckBox.TabIndex = 4;
            unplayedOnlyCheckBox.Text = "Unpayed Only";
            unplayedOnlyCheckBox.UseVisualStyleBackColor = true;
            unplayedOnlyCheckBox.CheckedChanged += UnplayedOnlyCheckBox_CheckedChanged;
            // 
            // matchupListBox
            // 
            matchupListBox.BorderStyle = BorderStyle.FixedSingle;
            matchupListBox.FormattingEnabled = true;
            matchupListBox.ItemHeight = 15;
            matchupListBox.Location = new Point(308, 107);
            matchupListBox.Name = "matchupListBox";
            matchupListBox.Size = new Size(259, 242);
            matchupListBox.TabIndex = 5;
            matchupListBox.SelectedIndexChanged += MatchupListBox_SelectedIndexChanged;
            // 
            // teamOneLabel
            // 
            teamOneLabel.AutoSize = true;
            teamOneLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            teamOneLabel.ForeColor = SystemColors.MenuHighlight;
            teamOneLabel.Location = new Point(21, 156);
            teamOneLabel.Name = "teamOneLabel";
            teamOneLabel.Size = new Size(85, 17);
            teamOneLabel.TabIndex = 6;
            teamOneLabel.Text = "<Team One>";
            // 
            // teamOneScoreValue
            // 
            teamOneScoreValue.BorderStyle = BorderStyle.FixedSingle;
            teamOneScoreValue.Location = new Point(143, 184);
            teamOneScoreValue.Name = "teamOneScoreValue";
            teamOneScoreValue.Size = new Size(146, 23);
            teamOneScoreValue.TabIndex = 7;
            // 
            // TeamOneScoreLabel
            // 
            TeamOneScoreLabel.AutoSize = true;
            TeamOneScoreLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            TeamOneScoreLabel.ForeColor = SystemColors.MenuHighlight;
            TeamOneScoreLabel.Location = new Point(22, 184);
            TeamOneScoreLabel.Name = "TeamOneScoreLabel";
            TeamOneScoreLabel.Size = new Size(41, 17);
            TeamOneScoreLabel.TabIndex = 8;
            TeamOneScoreLabel.Text = "Score";
            // 
            // TeamTwoScoreLabel
            // 
            TeamTwoScoreLabel.AutoSize = true;
            TeamTwoScoreLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            TeamTwoScoreLabel.ForeColor = SystemColors.MenuHighlight;
            TeamTwoScoreLabel.Location = new Point(21, 280);
            TeamTwoScoreLabel.Name = "TeamTwoScoreLabel";
            TeamTwoScoreLabel.Size = new Size(41, 17);
            TeamTwoScoreLabel.TabIndex = 11;
            TeamTwoScoreLabel.Text = "Score";
            // 
            // teamTwoScoreValue
            // 
            teamTwoScoreValue.BorderStyle = BorderStyle.FixedSingle;
            teamTwoScoreValue.Location = new Point(143, 280);
            teamTwoScoreValue.Name = "teamTwoScoreValue";
            teamTwoScoreValue.Size = new Size(146, 23);
            teamTwoScoreValue.TabIndex = 10;
            // 
            // teamTwoLabel
            // 
            teamTwoLabel.AutoSize = true;
            teamTwoLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            teamTwoLabel.ForeColor = SystemColors.MenuHighlight;
            teamTwoLabel.Location = new Point(21, 249);
            teamTwoLabel.Name = "teamTwoLabel";
            teamTwoLabel.Size = new Size(84, 17);
            teamTwoLabel.TabIndex = 9;
            teamTwoLabel.Text = "<Team Two>";
            // 
            // versusLabel
            // 
            versusLabel.AutoSize = true;
            versusLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            versusLabel.ForeColor = SystemColors.MenuHighlight;
            versusLabel.Location = new Point(124, 226);
            versusLabel.Name = "versusLabel";
            versusLabel.Size = new Size(33, 17);
            versusLabel.TabIndex = 12;
            versusLabel.Text = "-VS-";
            // 
            // scoreButton
            // 
            scoreButton.BackColor = Color.Silver;
            scoreButton.FlatStyle = FlatStyle.Flat;
            scoreButton.Location = new Point(28, 320);
            scoreButton.Name = "scoreButton";
            scoreButton.Size = new Size(261, 29);
            scoreButton.TabIndex = 13;
            scoreButton.Text = "Score";
            scoreButton.UseVisualStyleBackColor = false;
            scoreButton.Click += ScoreButton_Click;
            // 
            // tournamentDashboardLabel
            // 
            tournamentDashboardLabel.AutoSize = true;
            tournamentDashboardLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            tournamentDashboardLabel.ForeColor = SystemColors.MenuHighlight;
            tournamentDashboardLabel.Location = new Point(181, 14);
            tournamentDashboardLabel.Name = "tournamentDashboardLabel";
            tournamentDashboardLabel.RightToLeft = RightToLeft.No;
            tournamentDashboardLabel.Size = new Size(237, 37);
            tournamentDashboardLabel.TabIndex = 15;
            tournamentDashboardLabel.Text = "SCORING BOARD";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(308, 71);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 16;
            label1.Text = "Matchups";
            // 
            // TournamentViewerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(598, 386);
            Controls.Add(label1);
            Controls.Add(tournamentDashboardLabel);
            Controls.Add(scoreButton);
            Controls.Add(versusLabel);
            Controls.Add(TeamTwoScoreLabel);
            Controls.Add(teamTwoScoreValue);
            Controls.Add(teamTwoLabel);
            Controls.Add(TeamOneScoreLabel);
            Controls.Add(teamOneScoreValue);
            Controls.Add(teamOneLabel);
            Controls.Add(matchupListBox);
            Controls.Add(unplayedOnlyCheckBox);
            Controls.Add(roundsDropDown);
            Controls.Add(roundLabel);
            Controls.Add(tournamentName);
            Controls.Add(tournamentHeaderLabel);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            Name = "TournamentViewerForm";
            Text = "Tournament Viewer";
            Load += TournamentViewerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tournamentHeaderLabel;
        private Label tournamentName;
        private Label roundLabel;
        private ComboBox roundsDropDown;
        private CheckBox unplayedOnlyCheckBox;
        private ListBox matchupListBox;
        private Label teamOneLabel;
        private TextBox teamOneScoreValue;
        private Label TeamOneScoreLabel;
        private Label TeamTwoScoreLabel;
        private TextBox teamTwoScoreValue;
        private Label teamTwoLabel;
        private Label versusLabel;
        private Button scoreButton;
        private Label tournamentDashboardLabel;
        private Label label1;
    }
}