﻿namespace TrackerUI
{
    partial class CreateTournamentForm
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
            headerLabel = new Label();
            TournamentNameLabel = new Label();
            TournamentNameValue = new TextBox();
            EntryFeeLabel = new Label();
            EntryFeeValue = new TextBox();
            selectTeamDropDown = new ComboBox();
            selectTeamLabel = new Label();
            createNewTeamLink = new LinkLabel();
            addTeamButton = new Button();
            createPrizeButton = new Button();
            tournamentTeamsListBox = new ListBox();
            tournamentTeamsLabel = new Label();
            removeSelectedTeamButton = new Button();
            RemoveSelectedPrizeButton = new Button();
            prizesLabel = new Label();
            prizesListBox = new ListBox();
            createTournamentButton = new Button();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            headerLabel.ForeColor = SystemColors.MenuHighlight;
            headerLabel.Location = new Point(37, 27);
            headerLabel.Margin = new Padding(4, 0, 4, 0);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(385, 54);
            headerLabel.TabIndex = 1;
            headerLabel.Text = "Create Tournament";
            // 
            // TournamentNameLabel
            // 
            TournamentNameLabel.AutoSize = true;
            TournamentNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            TournamentNameLabel.ForeColor = SystemColors.MenuHighlight;
            TournamentNameLabel.Location = new Point(37, 95);
            TournamentNameLabel.Margin = new Padding(4, 0, 4, 0);
            TournamentNameLabel.Name = "TournamentNameLabel";
            TournamentNameLabel.RightToLeft = RightToLeft.No;
            TournamentNameLabel.Size = new Size(188, 28);
            TournamentNameLabel.TabIndex = 10;
            TournamentNameLabel.Text = "Tournament Name";
            // 
            // TournamentNameValue
            // 
            TournamentNameValue.BorderStyle = BorderStyle.FixedSingle;
            TournamentNameValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TournamentNameValue.Location = new Point(37, 128);
            TournamentNameValue.Margin = new Padding(4, 5, 4, 5);
            TournamentNameValue.Name = "TournamentNameValue";
            TournamentNameValue.Size = new Size(298, 31);
            TournamentNameValue.TabIndex = 9;
            // 
            // EntryFeeLabel
            // 
            EntryFeeLabel.AutoSize = true;
            EntryFeeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            EntryFeeLabel.ForeColor = SystemColors.MenuHighlight;
            EntryFeeLabel.Location = new Point(33, 198);
            EntryFeeLabel.Margin = new Padding(4, 0, 4, 0);
            EntryFeeLabel.Name = "EntryFeeLabel";
            EntryFeeLabel.Size = new Size(101, 28);
            EntryFeeLabel.TabIndex = 12;
            EntryFeeLabel.Text = "Entry Fee";
            // 
            // EntryFeeValue
            // 
            EntryFeeValue.BorderStyle = BorderStyle.FixedSingle;
            EntryFeeValue.Location = new Point(151, 200);
            EntryFeeValue.Margin = new Padding(4, 5, 4, 5);
            EntryFeeValue.Name = "EntryFeeValue";
            EntryFeeValue.Size = new Size(102, 31);
            EntryFeeValue.TabIndex = 11;
            EntryFeeValue.Text = "0";
            // 
            // selectTeamDropDown
            // 
            selectTeamDropDown.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            selectTeamDropDown.FormattingEnabled = true;
            selectTeamDropDown.Location = new Point(37, 312);
            selectTeamDropDown.Margin = new Padding(4, 5, 4, 5);
            selectTeamDropDown.Name = "selectTeamDropDown";
            selectTeamDropDown.Size = new Size(298, 36);
            selectTeamDropDown.TabIndex = 14;
            // 
            // selectTeamLabel
            // 
            selectTeamLabel.AutoSize = true;
            selectTeamLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            selectTeamLabel.ForeColor = SystemColors.MenuHighlight;
            selectTeamLabel.Location = new Point(37, 278);
            selectTeamLabel.Margin = new Padding(4, 0, 4, 0);
            selectTeamLabel.Name = "selectTeamLabel";
            selectTeamLabel.Size = new Size(125, 28);
            selectTeamLabel.TabIndex = 13;
            selectTeamLabel.Text = "Select Team";
            // 
            // createNewTeamLink
            // 
            createNewTeamLink.AutoSize = true;
            createNewTeamLink.Location = new Point(233, 278);
            createNewTeamLink.Name = "createNewTeamLink";
            createNewTeamLink.Size = new Size(102, 25);
            createNewTeamLink.TabIndex = 15;
            createNewTeamLink.TabStop = true;
            createNewTeamLink.Text = "Create New";
            createNewTeamLink.LinkClicked += CreateNewTeamLink_LinkClicked;
            // 
            // addTeamButton
            // 
            addTeamButton.BackColor = Color.Silver;
            addTeamButton.FlatStyle = FlatStyle.Flat;
            addTeamButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addTeamButton.Location = new Point(119, 365);
            addTeamButton.Name = "addTeamButton";
            addTeamButton.Size = new Size(111, 42);
            addTeamButton.TabIndex = 16;
            addTeamButton.Text = "Add Team";
            addTeamButton.UseVisualStyleBackColor = false;
            addTeamButton.Click += addTeamButton_Click;
            // 
            // createPrizeButton
            // 
            createPrizeButton.BackColor = Color.Silver;
            createPrizeButton.FlatStyle = FlatStyle.Flat;
            createPrizeButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            createPrizeButton.Location = new Point(119, 422);
            createPrizeButton.Name = "createPrizeButton";
            createPrizeButton.Size = new Size(111, 42);
            createPrizeButton.TabIndex = 17;
            createPrizeButton.Text = "Create Prize";
            createPrizeButton.UseVisualStyleBackColor = false;
            createPrizeButton.Click += createPrizeButton_Click;
            // 
            // tournamentTeamsListBox
            // 
            tournamentTeamsListBox.BorderStyle = BorderStyle.FixedSingle;
            tournamentTeamsListBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tournamentTeamsListBox.FormattingEnabled = true;
            tournamentTeamsListBox.ItemHeight = 25;
            tournamentTeamsListBox.Location = new Point(386, 128);
            tournamentTeamsListBox.Name = "tournamentTeamsListBox";
            tournamentTeamsListBox.Size = new Size(246, 127);
            tournamentTeamsListBox.TabIndex = 18;
            // 
            // tournamentTeamsLabel
            // 
            tournamentTeamsLabel.AutoSize = true;
            tournamentTeamsLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            tournamentTeamsLabel.ForeColor = SystemColors.MenuHighlight;
            tournamentTeamsLabel.Location = new Point(386, 95);
            tournamentTeamsLabel.Margin = new Padding(4, 0, 4, 0);
            tournamentTeamsLabel.Name = "tournamentTeamsLabel";
            tournamentTeamsLabel.RightToLeft = RightToLeft.No;
            tournamentTeamsLabel.Size = new Size(183, 28);
            tournamentTeamsLabel.TabIndex = 19;
            tournamentTeamsLabel.Text = "Tounament Teams";
            // 
            // removeSelectedTeamButton
            // 
            removeSelectedTeamButton.BackColor = Color.Silver;
            removeSelectedTeamButton.FlatStyle = FlatStyle.Flat;
            removeSelectedTeamButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            removeSelectedTeamButton.Location = new Point(647, 150);
            removeSelectedTeamButton.Name = "removeSelectedTeamButton";
            removeSelectedTeamButton.Size = new Size(111, 67);
            removeSelectedTeamButton.TabIndex = 20;
            removeSelectedTeamButton.Text = "Remove Selected";
            removeSelectedTeamButton.UseVisualStyleBackColor = false;
            removeSelectedTeamButton.Click += removeSelectedTeamButton_Click;
            // 
            // RemoveSelectedPrizeButton
            // 
            RemoveSelectedPrizeButton.BackColor = Color.Silver;
            RemoveSelectedPrizeButton.FlatStyle = FlatStyle.Flat;
            RemoveSelectedPrizeButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            RemoveSelectedPrizeButton.Location = new Point(647, 348);
            RemoveSelectedPrizeButton.Name = "RemoveSelectedPrizeButton";
            RemoveSelectedPrizeButton.Size = new Size(111, 73);
            RemoveSelectedPrizeButton.TabIndex = 23;
            RemoveSelectedPrizeButton.Text = "Remove Selected";
            RemoveSelectedPrizeButton.UseVisualStyleBackColor = false;
            RemoveSelectedPrizeButton.Click += RemoveSelectedPrizeButton_Click;
            // 
            // prizesLabel
            // 
            prizesLabel.AutoSize = true;
            prizesLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            prizesLabel.ForeColor = SystemColors.MenuHighlight;
            prizesLabel.Location = new Point(386, 278);
            prizesLabel.Margin = new Padding(4, 0, 4, 0);
            prizesLabel.Name = "prizesLabel";
            prizesLabel.RightToLeft = RightToLeft.No;
            prizesLabel.Size = new Size(68, 28);
            prizesLabel.TabIndex = 22;
            prizesLabel.Text = "Prizes";
            // 
            // prizesListBox
            // 
            prizesListBox.BorderStyle = BorderStyle.FixedSingle;
            prizesListBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            prizesListBox.FormattingEnabled = true;
            prizesListBox.ItemHeight = 25;
            prizesListBox.Location = new Point(386, 312);
            prizesListBox.Name = "prizesListBox";
            prizesListBox.Size = new Size(246, 152);
            prizesListBox.TabIndex = 21;
            // 
            // createTournamentButton
            // 
            createTournamentButton.BackColor = Color.Silver;
            createTournamentButton.FlatStyle = FlatStyle.Flat;
            createTournamentButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            createTournamentButton.Location = new Point(269, 513);
            createTournamentButton.Name = "createTournamentButton";
            createTournamentButton.Size = new Size(260, 57);
            createTournamentButton.TabIndex = 24;
            createTournamentButton.Text = "Create Tournament";
            createTournamentButton.UseVisualStyleBackColor = false;
            createTournamentButton.Click += createTournamentButton_Click;
            // 
            // CreateTournamentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(794, 598);
            Controls.Add(createTournamentButton);
            Controls.Add(RemoveSelectedPrizeButton);
            Controls.Add(prizesLabel);
            Controls.Add(prizesListBox);
            Controls.Add(removeSelectedTeamButton);
            Controls.Add(tournamentTeamsLabel);
            Controls.Add(tournamentTeamsListBox);
            Controls.Add(createPrizeButton);
            Controls.Add(addTeamButton);
            Controls.Add(createNewTeamLink);
            Controls.Add(selectTeamDropDown);
            Controls.Add(selectTeamLabel);
            Controls.Add(EntryFeeLabel);
            Controls.Add(EntryFeeValue);
            Controls.Add(TournamentNameLabel);
            Controls.Add(TournamentNameValue);
            Controls.Add(headerLabel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "CreateTournamentForm";
            Text = "Create Tournament";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label TournamentNameLabel;
        private TextBox TournamentNameValue;
        private Label EntryFeeLabel;
        private TextBox EntryFeeValue;
        private ComboBox selectTeamDropDown;
        private Label selectTeamLabel;
        private LinkLabel createNewTeamLink;
        private Button addTeamButton;
        private Button createPrizeButton;
        private ListBox tournamentTeamsListBox;
        private Label tournamentTeamsLabel;
        private Button removeSelectedTeamButton;
        private Button RemoveSelectedPrizeButton;
        private Label prizesLabel;
        private ListBox prizesListBox;
        private Button createTournamentButton;
    }
}