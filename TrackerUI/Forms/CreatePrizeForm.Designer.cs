namespace TrackerUI
{
    partial class CreatePrizeForm
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
            placeNumberLabel = new Label();
            placeNumberValue = new TextBox();
            PlaceNameLabel = new Label();
            PlaceNameValue = new TextBox();
            prizeAmountLabel = new Label();
            prizeAmountValue = new TextBox();
            prizePercentageLabel = new Label();
            prizePercentageValue = new TextBox();
            orLabel = new Label();
            createPrizeButton = new Button();
            SuspendLayout();
            // 
            // CreateTeamLabel
            // 
            CreateTeamLabel.AutoSize = true;
            CreateTeamLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            CreateTeamLabel.ForeColor = SystemColors.MenuHighlight;
            CreateTeamLabel.Location = new Point(24, 18);
            CreateTeamLabel.Margin = new Padding(4, 0, 4, 0);
            CreateTeamLabel.Name = "CreateTeamLabel";
            CreateTeamLabel.RightToLeft = RightToLeft.No;
            CreateTeamLabel.Size = new Size(176, 37);
            CreateTeamLabel.TabIndex = 13;
            CreateTeamLabel.Text = "PRIZE FORM";
            // 
            // placeNumberLabel
            // 
            placeNumberLabel.AutoSize = true;
            placeNumberLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            placeNumberLabel.ForeColor = SystemColors.MenuHighlight;
            placeNumberLabel.Location = new Point(24, 81);
            placeNumberLabel.Name = "placeNumberLabel";
            placeNumberLabel.Size = new Size(104, 19);
            placeNumberLabel.TabIndex = 15;
            placeNumberLabel.Text = "Place Number";
            // 
            // placeNumberValue
            // 
            placeNumberValue.BorderStyle = BorderStyle.FixedSingle;
            placeNumberValue.Location = new Point(153, 81);
            placeNumberValue.Name = "placeNumberValue";
            placeNumberValue.Size = new Size(177, 23);
            placeNumberValue.TabIndex = 14;
            // 
            // PlaceNameLabel
            // 
            PlaceNameLabel.AutoSize = true;
            PlaceNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            PlaceNameLabel.ForeColor = SystemColors.MenuHighlight;
            PlaceNameLabel.Location = new Point(24, 117);
            PlaceNameLabel.Name = "PlaceNameLabel";
            PlaceNameLabel.Size = new Size(89, 19);
            PlaceNameLabel.TabIndex = 17;
            PlaceNameLabel.Text = "Place Name";
            // 
            // PlaceNameValue
            // 
            PlaceNameValue.BorderStyle = BorderStyle.FixedSingle;
            PlaceNameValue.Location = new Point(153, 117);
            PlaceNameValue.Name = "PlaceNameValue";
            PlaceNameValue.Size = new Size(177, 23);
            PlaceNameValue.TabIndex = 16;
            // 
            // prizeAmountLabel
            // 
            prizeAmountLabel.AutoSize = true;
            prizeAmountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            prizeAmountLabel.ForeColor = SystemColors.MenuHighlight;
            prizeAmountLabel.Location = new Point(24, 156);
            prizeAmountLabel.Name = "prizeAmountLabel";
            prizeAmountLabel.Size = new Size(100, 19);
            prizeAmountLabel.TabIndex = 19;
            prizeAmountLabel.Text = "Prize Amount";
            // 
            // prizeAmountValue
            // 
            prizeAmountValue.BorderStyle = BorderStyle.FixedSingle;
            prizeAmountValue.Location = new Point(153, 156);
            prizeAmountValue.Name = "prizeAmountValue";
            prizeAmountValue.Size = new Size(177, 23);
            prizeAmountValue.TabIndex = 18;
            prizeAmountValue.Text = "0";
            // 
            // prizePercentageLabel
            // 
            prizePercentageLabel.AutoSize = true;
            prizePercentageLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            prizePercentageLabel.ForeColor = SystemColors.MenuHighlight;
            prizePercentageLabel.Location = new Point(24, 256);
            prizePercentageLabel.Name = "prizePercentageLabel";
            prizePercentageLabel.Size = new Size(123, 19);
            prizePercentageLabel.TabIndex = 21;
            prizePercentageLabel.Text = "Prize Percentage";
            // 
            // prizePercentageValue
            // 
            prizePercentageValue.BorderStyle = BorderStyle.FixedSingle;
            prizePercentageValue.Location = new Point(153, 256);
            prizePercentageValue.Name = "prizePercentageValue";
            prizePercentageValue.Size = new Size(177, 23);
            prizePercentageValue.TabIndex = 20;
            prizePercentageValue.Text = "0";
            // 
            // orLabel
            // 
            orLabel.AutoSize = true;
            orLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            orLabel.ForeColor = SystemColors.MenuHighlight;
            orLabel.Location = new Point(143, 202);
            orLabel.Name = "orLabel";
            orLabel.Size = new Size(65, 30);
            orLabel.TabIndex = 22;
            orLabel.Text = "- or -";
            // 
            // createPrizeButton
            // 
            createPrizeButton.BackColor = Color.Silver;
            createPrizeButton.FlatStyle = FlatStyle.Flat;
            createPrizeButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            createPrizeButton.Location = new Point(207, 21);
            createPrizeButton.Name = "createPrizeButton";
            createPrizeButton.Size = new Size(123, 36);
            createPrizeButton.TabIndex = 24;
            createPrizeButton.Text = "Create Prize";
            createPrizeButton.UseVisualStyleBackColor = false;
            createPrizeButton.Click += createPrizeButton_Click;
            // 
            // CreatePrizeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(358, 300);
            Controls.Add(createPrizeButton);
            Controls.Add(orLabel);
            Controls.Add(prizePercentageLabel);
            Controls.Add(prizePercentageValue);
            Controls.Add(prizeAmountLabel);
            Controls.Add(prizeAmountValue);
            Controls.Add(PlaceNameLabel);
            Controls.Add(PlaceNameValue);
            Controls.Add(placeNumberLabel);
            Controls.Add(placeNumberValue);
            Controls.Add(CreateTeamLabel);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Black;
            Name = "CreatePrizeForm";
            Text = "Create Prize";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CreateTeamLabel;
        private Label placeNumberLabel;
        private TextBox placeNumberValue;
        private Label PlaceNameLabel;
        private TextBox PlaceNameValue;
        private Label prizeAmountLabel;
        private TextBox prizeAmountValue;
        private Label prizePercentageLabel;
        private TextBox prizePercentageValue;
        private Label orLabel;
        private Button createPrizeButton;
    }
}