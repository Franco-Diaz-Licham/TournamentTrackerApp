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
            createMemberButton = new Button();
            cellphoneLabel = new Label();
            cellPhoneValue = new TextBox();
            emailLabel = new Label();
            emailValue = new TextBox();
            lastNameLabel = new Label();
            lastNameValue = new TextBox();
            firstNameLabel = new Label();
            firstNameValue = new TextBox();
            teamMembersListBox = new ListBox();
            removeSelectedMemberButton = new Button();
            createTeamButton = new Button();
            AddNewMemberGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // CreateTeamLabel
            // 
            CreateTeamLabel.AutoSize = true;
            CreateTeamLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            CreateTeamLabel.ForeColor = SystemColors.MenuHighlight;
            CreateTeamLabel.Location = new Point(25, 33);
            CreateTeamLabel.Margin = new Padding(4, 0, 4, 0);
            CreateTeamLabel.Name = "CreateTeamLabel";
            CreateTeamLabel.RightToLeft = RightToLeft.No;
            CreateTeamLabel.Size = new Size(257, 54);
            CreateTeamLabel.TabIndex = 12;
            CreateTeamLabel.Text = "Create Team";
            // 
            // teamNameValue
            // 
            teamNameValue.BorderStyle = BorderStyle.FixedSingle;
            teamNameValue.Location = new Point(31, 131);
            teamNameValue.Margin = new Padding(4, 5, 4, 5);
            teamNameValue.Name = "teamNameValue";
            teamNameValue.Size = new Size(348, 31);
            teamNameValue.TabIndex = 11;
            // 
            // teamNameLabel
            // 
            teamNameLabel.AutoSize = true;
            teamNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            teamNameLabel.ForeColor = SystemColors.MenuHighlight;
            teamNameLabel.Location = new Point(31, 98);
            teamNameLabel.Margin = new Padding(4, 0, 4, 0);
            teamNameLabel.Name = "teamNameLabel";
            teamNameLabel.RightToLeft = RightToLeft.No;
            teamNameLabel.Size = new Size(124, 28);
            teamNameLabel.TabIndex = 13;
            teamNameLabel.Text = "Team Name";
            // 
            // addMemberButton
            // 
            addMemberButton.BackColor = Color.Silver;
            addMemberButton.FlatStyle = FlatStyle.Flat;
            addMemberButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            addMemberButton.ForeColor = SystemColors.InfoText;
            addMemberButton.Location = new Point(131, 269);
            addMemberButton.Name = "addMemberButton";
            addMemberButton.Size = new Size(157, 47);
            addMemberButton.TabIndex = 19;
            addMemberButton.Text = "Add Member";
            addMemberButton.UseVisualStyleBackColor = false;
            addMemberButton.Click += addMemberButton_Click;
            // 
            // selectTeamMemberDropDown
            // 
            selectTeamMemberDropDown.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            selectTeamMemberDropDown.FormattingEnabled = true;
            selectTeamMemberDropDown.Location = new Point(31, 214);
            selectTeamMemberDropDown.Margin = new Padding(4, 5, 4, 5);
            selectTeamMemberDropDown.Name = "selectTeamMemberDropDown";
            selectTeamMemberDropDown.Size = new Size(348, 36);
            selectTeamMemberDropDown.TabIndex = 18;
            // 
            // selectTeamMemberLabel
            // 
            selectTeamMemberLabel.AutoSize = true;
            selectTeamMemberLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            selectTeamMemberLabel.ForeColor = SystemColors.MenuHighlight;
            selectTeamMemberLabel.Location = new Point(31, 181);
            selectTeamMemberLabel.Margin = new Padding(4, 0, 4, 0);
            selectTeamMemberLabel.Name = "selectTeamMemberLabel";
            selectTeamMemberLabel.Size = new Size(210, 28);
            selectTeamMemberLabel.TabIndex = 17;
            selectTeamMemberLabel.Text = "Select Team Member";
            // 
            // AddNewMemberGroupBox
            // 
            AddNewMemberGroupBox.Controls.Add(createMemberButton);
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
            AddNewMemberGroupBox.Location = new Point(31, 347);
            AddNewMemberGroupBox.Name = "AddNewMemberGroupBox";
            AddNewMemberGroupBox.Size = new Size(348, 382);
            AddNewMemberGroupBox.TabIndex = 20;
            AddNewMemberGroupBox.TabStop = false;
            AddNewMemberGroupBox.Text = "Add New Member";
            // 
            // createMemberButton
            // 
            createMemberButton.BackColor = Color.Silver;
            createMemberButton.FlatStyle = FlatStyle.Flat;
            createMemberButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            createMemberButton.ForeColor = SystemColors.InfoText;
            createMemberButton.Location = new Point(100, 281);
            createMemberButton.Name = "createMemberButton";
            createMemberButton.Size = new Size(157, 79);
            createMemberButton.TabIndex = 20;
            createMemberButton.Text = "Create Member";
            createMemberButton.UseVisualStyleBackColor = false;
            createMemberButton.Click += createMemberButton_Click;
            // 
            // cellphoneLabel
            // 
            cellphoneLabel.AutoSize = true;
            cellphoneLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cellphoneLabel.ForeColor = SystemColors.MenuHighlight;
            cellphoneLabel.Location = new Point(6, 218);
            cellphoneLabel.Name = "cellphoneLabel";
            cellphoneLabel.Size = new Size(100, 28);
            cellphoneLabel.TabIndex = 16;
            cellphoneLabel.Text = "Cellphone";
            // 
            // cellPhoneValue
            // 
            cellPhoneValue.BorderStyle = BorderStyle.FixedSingle;
            cellPhoneValue.Location = new Point(118, 218);
            cellPhoneValue.Name = "cellPhoneValue";
            cellPhoneValue.Size = new Size(214, 39);
            cellPhoneValue.TabIndex = 15;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            emailLabel.ForeColor = SystemColors.MenuHighlight;
            emailLabel.Location = new Point(6, 164);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(59, 28);
            emailLabel.TabIndex = 14;
            emailLabel.Text = "Email";
            // 
            // emailValue
            // 
            emailValue.BorderStyle = BorderStyle.FixedSingle;
            emailValue.Location = new Point(118, 164);
            emailValue.Name = "emailValue";
            emailValue.Size = new Size(214, 39);
            emailValue.TabIndex = 13;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.ForeColor = SystemColors.MenuHighlight;
            lastNameLabel.Location = new Point(6, 109);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(103, 28);
            lastNameLabel.TabIndex = 12;
            lastNameLabel.Text = "Last Name";
            // 
            // lastNameValue
            // 
            lastNameValue.BorderStyle = BorderStyle.FixedSingle;
            lastNameValue.Location = new Point(118, 109);
            lastNameValue.Name = "lastNameValue";
            lastNameValue.Size = new Size(214, 39);
            lastNameValue.TabIndex = 11;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.ForeColor = SystemColors.MenuHighlight;
            firstNameLabel.Location = new Point(6, 51);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(106, 28);
            firstNameLabel.TabIndex = 10;
            firstNameLabel.Text = "First Name";
            // 
            // firstNameValue
            // 
            firstNameValue.BorderStyle = BorderStyle.FixedSingle;
            firstNameValue.Location = new Point(118, 51);
            firstNameValue.Name = "firstNameValue";
            firstNameValue.Size = new Size(214, 39);
            firstNameValue.TabIndex = 9;
            // 
            // teamMembersListBox
            // 
            teamMembersListBox.BorderStyle = BorderStyle.FixedSingle;
            teamMembersListBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            teamMembersListBox.FormattingEnabled = true;
            teamMembersListBox.ItemHeight = 25;
            teamMembersListBox.Location = new Point(411, 131);
            teamMembersListBox.Name = "teamMembersListBox";
            teamMembersListBox.Size = new Size(363, 502);
            teamMembersListBox.TabIndex = 21;
            // 
            // removeSelectedMemberButton
            // 
            removeSelectedMemberButton.BackColor = Color.Silver;
            removeSelectedMemberButton.FlatStyle = FlatStyle.Flat;
            removeSelectedMemberButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            removeSelectedMemberButton.Location = new Point(505, 649);
            removeSelectedMemberButton.Name = "removeSelectedMemberButton";
            removeSelectedMemberButton.Size = new Size(172, 67);
            removeSelectedMemberButton.TabIndex = 22;
            removeSelectedMemberButton.Text = "Remove Selected Member";
            removeSelectedMemberButton.UseVisualStyleBackColor = false;
            removeSelectedMemberButton.Click += removeSelectedMemberButton_Click;
            // 
            // createTeamButton
            // 
            createTeamButton.BackColor = Color.Silver;
            createTeamButton.FlatStyle = FlatStyle.Flat;
            createTeamButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            createTeamButton.Location = new Point(273, 772);
            createTeamButton.Name = "createTeamButton";
            createTeamButton.Size = new Size(254, 76);
            createTeamButton.TabIndex = 23;
            createTeamButton.Text = "Create Team";
            createTeamButton.UseVisualStyleBackColor = false;
            createTeamButton.Click += createTeamButton_Click;
            // 
            // CreateTeamForm
            // 
            AutoScaleDimensions = new SizeF(9F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(804, 879);
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
    }
}