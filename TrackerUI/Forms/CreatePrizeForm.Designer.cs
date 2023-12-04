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
            CreateTeamLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            CreateTeamLabel.ForeColor = SystemColors.MenuHighlight;
            CreateTeamLabel.Location = new Point(34, 35);
            CreateTeamLabel.Margin = new Padding(4, 0, 4, 0);
            CreateTeamLabel.Name = "CreateTeamLabel";
            CreateTeamLabel.RightToLeft = RightToLeft.No;
            CreateTeamLabel.Size = new Size(250, 54);
            CreateTeamLabel.TabIndex = 13;
            CreateTeamLabel.Text = "Create Prize";
            // 
            // placeNumberLabel
            // 
            placeNumberLabel.AutoSize = true;
            placeNumberLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            placeNumberLabel.ForeColor = SystemColors.MenuHighlight;
            placeNumberLabel.Location = new Point(42, 111);
            placeNumberLabel.Name = "placeNumberLabel";
            placeNumberLabel.Size = new Size(145, 28);
            placeNumberLabel.TabIndex = 15;
            placeNumberLabel.Text = "Place Number";
            // 
            // placeNumberValue
            // 
            placeNumberValue.BorderStyle = BorderStyle.FixedSingle;
            placeNumberValue.Location = new Point(206, 111);
            placeNumberValue.Name = "placeNumberValue";
            placeNumberValue.Size = new Size(214, 31);
            placeNumberValue.TabIndex = 14;
            // 
            // PlaceNameLabel
            // 
            PlaceNameLabel.AutoSize = true;
            PlaceNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            PlaceNameLabel.ForeColor = SystemColors.MenuHighlight;
            PlaceNameLabel.Location = new Point(42, 177);
            PlaceNameLabel.Name = "PlaceNameLabel";
            PlaceNameLabel.Size = new Size(124, 28);
            PlaceNameLabel.TabIndex = 17;
            PlaceNameLabel.Text = "Place Name";
            // 
            // PlaceNameValue
            // 
            PlaceNameValue.BorderStyle = BorderStyle.FixedSingle;
            PlaceNameValue.Location = new Point(206, 177);
            PlaceNameValue.Name = "PlaceNameValue";
            PlaceNameValue.Size = new Size(214, 31);
            PlaceNameValue.TabIndex = 16;
            // 
            // prizeAmountLabel
            // 
            prizeAmountLabel.AutoSize = true;
            prizeAmountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            prizeAmountLabel.ForeColor = SystemColors.MenuHighlight;
            prizeAmountLabel.Location = new Point(42, 249);
            prizeAmountLabel.Name = "prizeAmountLabel";
            prizeAmountLabel.Size = new Size(141, 28);
            prizeAmountLabel.TabIndex = 19;
            prizeAmountLabel.Text = "Prize Amount";
            // 
            // prizeAmountValue
            // 
            prizeAmountValue.BorderStyle = BorderStyle.FixedSingle;
            prizeAmountValue.Location = new Point(206, 249);
            prizeAmountValue.Name = "prizeAmountValue";
            prizeAmountValue.Size = new Size(214, 31);
            prizeAmountValue.TabIndex = 18;
            prizeAmountValue.Text = "0";
            // 
            // prizePercentageLabel
            // 
            prizePercentageLabel.AutoSize = true;
            prizePercentageLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            prizePercentageLabel.ForeColor = SystemColors.MenuHighlight;
            prizePercentageLabel.Location = new Point(30, 442);
            prizePercentageLabel.Name = "prizePercentageLabel";
            prizePercentageLabel.Size = new Size(170, 28);
            prizePercentageLabel.TabIndex = 21;
            prizePercentageLabel.Text = "Prize Percentage";
            // 
            // prizePercentageValue
            // 
            prizePercentageValue.BorderStyle = BorderStyle.FixedSingle;
            prizePercentageValue.Location = new Point(206, 442);
            prizePercentageValue.Name = "prizePercentageValue";
            prizePercentageValue.Size = new Size(214, 31);
            prizePercentageValue.TabIndex = 20;
            prizePercentageValue.Text = "0";
            // 
            // orLabel
            // 
            orLabel.AutoSize = true;
            orLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            orLabel.ForeColor = SystemColors.MenuHighlight;
            orLabel.Location = new Point(187, 336);
            orLabel.Name = "orLabel";
            orLabel.Size = new Size(97, 45);
            orLabel.TabIndex = 22;
            orLabel.Text = "- or -";
            // 
            // createPrizeButton
            // 
            createPrizeButton.BackColor = Color.Silver;
            createPrizeButton.FlatStyle = FlatStyle.Flat;
            createPrizeButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            createPrizeButton.Location = new Point(104, 522);
            createPrizeButton.Name = "createPrizeButton";
            createPrizeButton.Size = new Size(254, 76);
            createPrizeButton.TabIndex = 24;
            createPrizeButton.Text = "Create Prize";
            createPrizeButton.UseVisualStyleBackColor = false;
            createPrizeButton.Click += createPrizeButton_Click;
            // 
            // CreatePrizeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(475, 631);
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