namespace TrackerUI
{
    partial class CreateTeamForm
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
            CreateTeamLabel = new Label();
            teamNameValue = new TextBox();
            teamNameLabel = new Label();
            addMemberButton = new Button();
            selectTeamMemberDropDown = new ComboBox();
            selectTeamMemberLabel = new Label();
            AddNewMemberGroupBox = new GroupBox();
            cellphoneLabel = new Label();
            cellPhoneValue = new TextBox();
            emailLabel = new Label();
            emailValue = new TextBox();
            lastNameLabel = new Label();
            lastNameValue = new TextBox();
            firstNameLabel = new Label();
            firstNameValue = new TextBox();
            createMemberButton = new Button();
            teamMembersListBox = new ListBox();
            removeSelectedMemberButton = new Button();
            createTeamButton = new Button();
            teamMembersLabel = new Label();
            AddNewMemberGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // CreateTeamLabel
            // 
            CreateTeamLabel.AutoSize = true;
            CreateTeamLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            CreateTeamLabel.ForeColor = SystemColors.MenuHighlight;
            CreateTeamLabel.Location = new Point(29, 9);
            CreateTeamLabel.Margin = new Padding(4, 0, 4, 0);
            CreateTeamLabel.Name = "CreateTeamLabel";
            CreateTeamLabel.RightToLeft = RightToLeft.No;
            CreateTeamLabel.Size = new Size(177, 37);
            CreateTeamLabel.TabIndex = 12;
            CreateTeamLabel.Text = "TEAM FORM";
            // 
            // teamNameValue
            // 
            teamNameValue.BorderStyle = BorderStyle.FixedSingle;
            teamNameValue.Location = new Point(36, 84);
            teamNameValue.Margin = new Padding(4, 5, 4, 5);
            teamNameValue.Name = "teamNameValue";
            teamNameValue.Size = new Size(276, 23);
            teamNameValue.TabIndex = 11;
            // 
            // teamNameLabel
            // 
            teamNameLabel.AutoSize = true;
            teamNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            teamNameLabel.ForeColor = SystemColors.MenuHighlight;
            teamNameLabel.Location = new Point(36, 60);
            teamNameLabel.Margin = new Padding(4, 0, 4, 0);
            teamNameLabel.Name = "teamNameLabel";
            teamNameLabel.RightToLeft = RightToLeft.No;
            teamNameLabel.Size = new Size(89, 19);
            teamNameLabel.TabIndex = 13;
            teamNameLabel.Text = "Team Name";
            // 
            // addMemberButton
            // 
            addMemberButton.BackColor = Color.Silver;
            addMemberButton.FlatStyle = FlatStyle.Flat;
            addMemberButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addMemberButton.ForeColor = SystemColors.InfoText;
            addMemberButton.Location = new Point(214, 146);
            addMemberButton.Name = "addMemberButton";
            addMemberButton.Size = new Size(98, 26);
            addMemberButton.TabIndex = 19;
            addMemberButton.Text = "Add Member";
            addMemberButton.UseVisualStyleBackColor = false;
            addMemberButton.Click += AddMemberButton_Click;
            // 
            // selectTeamMemberDropDown
            // 
            selectTeamMemberDropDown.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            selectTeamMemberDropDown.FormattingEnabled = true;
            selectTeamMemberDropDown.Location = new Point(36, 147);
            selectTeamMemberDropDown.Margin = new Padding(4, 5, 4, 5);
            selectTeamMemberDropDown.Name = "selectTeamMemberDropDown";
            selectTeamMemberDropDown.Size = new Size(170, 25);
            selectTeamMemberDropDown.TabIndex = 18;
            // 
            // selectTeamMemberLabel
            // 
            selectTeamMemberLabel.AutoSize = true;
            selectTeamMemberLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            selectTeamMemberLabel.ForeColor = SystemColors.MenuHighlight;
            selectTeamMemberLabel.Location = new Point(36, 123);
            selectTeamMemberLabel.Margin = new Padding(4, 0, 4, 0);
            selectTeamMemberLabel.Name = "selectTeamMemberLabel";
            selectTeamMemberLabel.Size = new Size(150, 19);
            selectTeamMemberLabel.TabIndex = 17;
            selectTeamMemberLabel.Text = "Select Team Member";
            // 
            // AddNewMemberGroupBox
            // 
            AddNewMemberGroupBox.Controls.Add(cellphoneLabel);
            AddNewMemberGroupBox.Controls.Add(cellPhoneValue);
            AddNewMemberGroupBox.Controls.Add(emailLabel);
            AddNewMemberGroupBox.Controls.Add(emailValue);
            AddNewMemberGroupBox.Controls.Add(lastNameLabel);
            AddNewMemberGroupBox.Controls.Add(lastNameValue);
            AddNewMemberGroupBox.Controls.Add(firstNameLabel);
            AddNewMemberGroupBox.Controls.Add(firstNameValue);
            AddNewMemberGroupBox.FlatStyle = FlatStyle.Flat;
            AddNewMemberGroupBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            AddNewMemberGroupBox.ForeColor = SystemColors.MenuHighlight;
            AddNewMemberGroupBox.Location = new Point(36, 192);
            AddNewMemberGroupBox.Name = "AddNewMemberGroupBox";
            AddNewMemberGroupBox.Size = new Size(276, 243);
            AddNewMemberGroupBox.TabIndex = 20;
            AddNewMemberGroupBox.TabStop = false;
            AddNewMemberGroupBox.Text = "Add New Member";
            // 
            // cellphoneLabel
            // 
            cellphoneLabel.AutoSize = true;
            cellphoneLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cellphoneLabel.ForeColor = SystemColors.MenuHighlight;
            cellphoneLabel.Location = new Point(10, 187);
            cellphoneLabel.Name = "cellphoneLabel";
            cellphoneLabel.Size = new Size(66, 17);
            cellphoneLabel.TabIndex = 16;
            cellphoneLabel.Text = "Cellphone";
            // 
            // cellPhoneValue
            // 
            cellPhoneValue.BorderStyle = BorderStyle.FixedSingle;
            cellPhoneValue.Location = new Point(83, 187);
            cellPhoneValue.Name = "cellPhoneValue";
            cellPhoneValue.Size = new Size(180, 29);
            cellPhoneValue.TabIndex = 15;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            emailLabel.ForeColor = SystemColors.MenuHighlight;
            emailLabel.Location = new Point(6, 142);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(39, 17);
            emailLabel.TabIndex = 14;
            emailLabel.Text = "Email";
            // 
            // emailValue
            // 
            emailValue.BorderStyle = BorderStyle.FixedSingle;
            emailValue.Location = new Point(83, 137);
            emailValue.Name = "emailValue";
            emailValue.Size = new Size(180, 29);
            emailValue.TabIndex = 13;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.ForeColor = SystemColors.MenuHighlight;
            lastNameLabel.Location = new Point(6, 102);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(70, 17);
            lastNameLabel.TabIndex = 12;
            lastNameLabel.Text = "Last Name";
            // 
            // lastNameValue
            // 
            lastNameValue.BorderStyle = BorderStyle.FixedSingle;
            lastNameValue.Location = new Point(83, 97);
            lastNameValue.Name = "lastNameValue";
            lastNameValue.Size = new Size(180, 29);
            lastNameValue.TabIndex = 11;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.ForeColor = SystemColors.MenuHighlight;
            firstNameLabel.Location = new Point(6, 51);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(71, 17);
            firstNameLabel.TabIndex = 10;
            firstNameLabel.Text = "First Name";
            // 
            // firstNameValue
            // 
            firstNameValue.BorderStyle = BorderStyle.FixedSingle;
            firstNameValue.Location = new Point(83, 51);
            firstNameValue.Name = "firstNameValue";
            firstNameValue.Size = new Size(180, 29);
            firstNameValue.TabIndex = 9;
            // 
            // createMemberButton
            // 
            createMemberButton.BackColor = Color.Silver;
            createMemberButton.FlatStyle = FlatStyle.Flat;
            createMemberButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            createMemberButton.ForeColor = SystemColors.InfoText;
            createMemberButton.Location = new Point(36, 441);
            createMemberButton.Name = "createMemberButton";
            createMemberButton.Size = new Size(276, 30);
            createMemberButton.TabIndex = 20;
            createMemberButton.Text = "Create Member";
            createMemberButton.UseVisualStyleBackColor = false;
            createMemberButton.Click += CreateMemberButton_Click;
            // 
            // teamMembersListBox
            // 
            teamMembersListBox.BorderStyle = BorderStyle.FixedSingle;
            teamMembersListBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            teamMembersListBox.FormattingEnabled = true;
            teamMembersListBox.ItemHeight = 15;
            teamMembersListBox.Location = new Point(331, 88);
            teamMembersListBox.Name = "teamMembersListBox";
            teamMembersListBox.Size = new Size(221, 347);
            teamMembersListBox.TabIndex = 21;
            // 
            // removeSelectedMemberButton
            // 
            removeSelectedMemberButton.BackColor = Color.Silver;
            removeSelectedMemberButton.FlatStyle = FlatStyle.Flat;
            removeSelectedMemberButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            removeSelectedMemberButton.Location = new Point(331, 441);
            removeSelectedMemberButton.Name = "removeSelectedMemberButton";
            removeSelectedMemberButton.Size = new Size(221, 30);
            removeSelectedMemberButton.TabIndex = 22;
            removeSelectedMemberButton.Text = "Remove Member";
            removeSelectedMemberButton.UseVisualStyleBackColor = false;
            removeSelectedMemberButton.Click += RemoveSelectedMemberButton_Click;
            // 
            // createTeamButton
            // 
            createTeamButton.BackColor = Color.Silver;
            createTeamButton.FlatStyle = FlatStyle.Flat;
            createTeamButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            createTeamButton.Location = new Point(258, 12);
            createTeamButton.Name = "createTeamButton";
            createTeamButton.Size = new Size(294, 34);
            createTeamButton.TabIndex = 23;
            createTeamButton.Text = "Create Team";
            createTeamButton.UseVisualStyleBackColor = false;
            createTeamButton.Click += CreateTeamButton_Click;
            // 
            // teamMembersLabel
            // 
            teamMembersLabel.AutoSize = true;
            teamMembersLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            teamMembersLabel.ForeColor = SystemColors.MenuHighlight;
            teamMembersLabel.Location = new Point(331, 60);
            teamMembersLabel.Margin = new Padding(4, 0, 4, 0);
            teamMembersLabel.Name = "teamMembersLabel";
            teamMembersLabel.Size = new Size(112, 19);
            teamMembersLabel.TabIndex = 24;
            teamMembersLabel.Text = "Team Members";
            // 
            // CreateTeamForm
            // 
            AutoScaleDimensions = new SizeF(6F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(581, 494);
            Controls.Add(createMemberButton);
            Controls.Add(teamMembersLabel);
            Controls.Add(createTeamButton);
            Controls.Add(removeSelectedMemberButton);
            Controls.Add(teamMembersListBox);
            Controls.Add(AddNewMemberGroupBox);
            Controls.Add(addMemberButton);
            Controls.Add(selectTeamMemberDropDown);
            Controls.Add(selectTeamMemberLabel);
            Controls.Add(teamNameLabel);
            Controls.Add(CreateTeamLabel);
            Controls.Add(teamNameValue);
            Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(2, 3, 2, 3);
            Name = "CreateTeamForm";
            Text = "Create Team";
            AddNewMemberGroupBox.ResumeLayout(false);
            AddNewMemberGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CreateTeamLabel;
        private TextBox teamNameValue;
        private Label teamNameLabel;
        private Button addMemberButton;
        private ComboBox selectTeamMemberDropDown;
        private Label selectTeamMemberLabel;
        private GroupBox AddNewMemberGroupBox;
        private Label firstNameLabel;
        private TextBox firstNameValue;
        private Label emailLabel;
        private TextBox emailValue;
        private Label lastNameLabel;
        private TextBox lastNameValue;
        private Label cellphoneLabel;
        private TextBox cellPhoneValue;
        private Button createMemberButton;
        private ListBox teamMembersListBox;
        private Button removeSelectedMemberButton;
        private Button createTeamButton;
        private Label teamMembersLabel;
    }
}