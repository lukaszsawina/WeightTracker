namespace WeightTracker.Views
{
    partial class PersonMenuViewForm
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
            this.PersonNameTitleLabel = new System.Windows.Forms.Label();
            this.AgeTitleLabel = new System.Windows.Forms.Label();
            this.WeightsListBox = new System.Windows.Forms.ListBox();
            this.WeightsTitleLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.BMITitleLabel = new System.Windows.Forms.Label();
            this.BMIValueLabel = new System.Windows.Forms.Label();
            this.WhatMeansTitleLabel = new System.Windows.Forms.Label();
            this.WhatMeansLabel = new System.Windows.Forms.Label();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.HeightTitleLabel = new System.Windows.Forms.Label();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.PersonNameLabel = new System.Windows.Forms.Label();
            this.NewWeightTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorInputLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PersonNameTitleLabel
            // 
            this.PersonNameTitleLabel.AutoSize = true;
            this.PersonNameTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.PersonNameTitleLabel.Location = new System.Drawing.Point(15, 9);
            this.PersonNameTitleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PersonNameTitleLabel.Name = "PersonNameTitleLabel";
            this.PersonNameTitleLabel.Size = new System.Drawing.Size(99, 31);
            this.PersonNameTitleLabel.TabIndex = 0;
            this.PersonNameTitleLabel.Text = "Name:";
            // 
            // AgeTitleLabel
            // 
            this.AgeTitleLabel.AutoSize = true;
            this.AgeTitleLabel.Location = new System.Drawing.Point(16, 40);
            this.AgeTitleLabel.Name = "AgeTitleLabel";
            this.AgeTitleLabel.Size = new System.Drawing.Size(57, 26);
            this.AgeTitleLabel.TabIndex = 1;
            this.AgeTitleLabel.Text = "Age:";
            // 
            // WeightsListBox
            // 
            this.WeightsListBox.FormattingEnabled = true;
            this.WeightsListBox.ItemHeight = 25;
            this.WeightsListBox.Location = new System.Drawing.Point(340, 40);
            this.WeightsListBox.Name = "WeightsListBox";
            this.WeightsListBox.Size = new System.Drawing.Size(232, 229);
            this.WeightsListBox.TabIndex = 2;
            // 
            // WeightsTitleLabel
            // 
            this.WeightsTitleLabel.AutoSize = true;
            this.WeightsTitleLabel.Location = new System.Drawing.Point(335, 9);
            this.WeightsTitleLabel.Name = "WeightsTitleLabel";
            this.WeightsTitleLabel.Size = new System.Drawing.Size(97, 26);
            this.WeightsTitleLabel.TabIndex = 3;
            this.WeightsTitleLabel.Text = "Weights:";
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AddButton.Location = new System.Drawing.Point(340, 326);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(108, 47);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add weight";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.RemoveButton.Location = new System.Drawing.Point(454, 326);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(118, 47);
            this.RemoveButton.TabIndex = 5;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // BMITitleLabel
            // 
            this.BMITitleLabel.AutoSize = true;
            this.BMITitleLabel.Location = new System.Drawing.Point(16, 148);
            this.BMITitleLabel.Name = "BMITitleLabel";
            this.BMITitleLabel.Size = new System.Drawing.Size(57, 26);
            this.BMITitleLabel.TabIndex = 6;
            this.BMITitleLabel.Text = "BMI:";
            // 
            // BMIValueLabel
            // 
            this.BMIValueLabel.AutoSize = true;
            this.BMIValueLabel.Location = new System.Drawing.Point(79, 148);
            this.BMIValueLabel.Name = "BMIValueLabel";
            this.BMIValueLabel.Size = new System.Drawing.Size(107, 26);
            this.BMIValueLabel.TabIndex = 7;
            this.BMIValueLabel.Text = "BmiValue";
            // 
            // WhatMeansTitleLabel
            // 
            this.WhatMeansTitleLabel.AutoSize = true;
            this.WhatMeansTitleLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WhatMeansTitleLabel.Location = new System.Drawing.Point(16, 174);
            this.WhatMeansTitleLabel.Name = "WhatMeansTitleLabel";
            this.WhatMeansTitleLabel.Size = new System.Drawing.Size(200, 26);
            this.WhatMeansTitleLabel.TabIndex = 8;
            this.WhatMeansTitleLabel.Text = "What does it mean:";
            // 
            // WhatMeansLabel
            // 
            this.WhatMeansLabel.AutoSize = true;
            this.WhatMeansLabel.Location = new System.Drawing.Point(16, 200);
            this.WhatMeansLabel.Name = "WhatMeansLabel";
            this.WhatMeansLabel.Size = new System.Drawing.Size(87, 26);
            this.WhatMeansLabel.TabIndex = 9;
            this.WhatMeansLabel.Text = "wartosc";
            // 
            // AgeLabel
            // 
            this.AgeLabel.AutoSize = true;
            this.AgeLabel.Location = new System.Drawing.Point(79, 40);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(51, 26);
            this.AgeLabel.TabIndex = 10;
            this.AgeLabel.Text = "Age";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(103, 66);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(75, 26);
            this.HeightLabel.TabIndex = 12;
            this.HeightLabel.Text = "Height";
            // 
            // HeightTitleLabel
            // 
            this.HeightTitleLabel.AutoSize = true;
            this.HeightTitleLabel.Location = new System.Drawing.Point(16, 66);
            this.HeightTitleLabel.Name = "HeightTitleLabel";
            this.HeightTitleLabel.Size = new System.Drawing.Size(81, 26);
            this.HeightTitleLabel.TabIndex = 11;
            this.HeightTitleLabel.Text = "Height:";
            // 
            // ReturnButton
            // 
            this.ReturnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ReturnButton.Location = new System.Drawing.Point(12, 326);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(137, 34);
            this.ReturnButton.TabIndex = 15;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // PersonNameLabel
            // 
            this.PersonNameLabel.AutoSize = true;
            this.PersonNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.PersonNameLabel.Location = new System.Drawing.Point(126, 9);
            this.PersonNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PersonNameLabel.Name = "PersonNameLabel";
            this.PersonNameLabel.Size = new System.Drawing.Size(99, 31);
            this.PersonNameLabel.TabIndex = 16;
            this.PersonNameLabel.Text = "Name:";
            // 
            // NewWeightTextBox
            // 
            this.NewWeightTextBox.Location = new System.Drawing.Point(454, 286);
            this.NewWeightTextBox.Name = "NewWeightTextBox";
            this.NewWeightTextBox.Size = new System.Drawing.Size(118, 32);
            this.NewWeightTextBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(339, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "New weight";
            // 
            // ErrorInputLabel
            // 
            this.ErrorInputLabel.AutoSize = true;
            this.ErrorInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ErrorInputLabel.Location = new System.Drawing.Point(340, 272);
            this.ErrorInputLabel.Name = "ErrorInputLabel";
            this.ErrorInputLabel.Size = new System.Drawing.Size(29, 13);
            this.ErrorInputLabel.TabIndex = 19;
            this.ErrorInputLabel.Text = "Error";
            // 
            // PersonMenuViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.ErrorInputLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewWeightTextBox);
            this.Controls.Add(this.PersonNameLabel);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.HeightTitleLabel);
            this.Controls.Add(this.AgeLabel);
            this.Controls.Add(this.WhatMeansLabel);
            this.Controls.Add(this.WhatMeansTitleLabel);
            this.Controls.Add(this.BMIValueLabel);
            this.Controls.Add(this.BMITitleLabel);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.WeightsTitleLabel);
            this.Controls.Add(this.WeightsListBox);
            this.Controls.Add(this.AgeTitleLabel);
            this.Controls.Add(this.PersonNameTitleLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PersonMenuViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PersonMenuVIewForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PersonMenuViewForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PersonNameTitleLabel;
        private System.Windows.Forms.Label AgeTitleLabel;
        private System.Windows.Forms.ListBox WeightsListBox;
        private System.Windows.Forms.Label WeightsTitleLabel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Label BMITitleLabel;
        private System.Windows.Forms.Label BMIValueLabel;
        private System.Windows.Forms.Label WhatMeansTitleLabel;
        private System.Windows.Forms.Label WhatMeansLabel;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label HeightTitleLabel;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Label PersonNameLabel;
        private System.Windows.Forms.TextBox NewWeightTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ErrorInputLabel;
    }
}