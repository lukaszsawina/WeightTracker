namespace WeightTracker.Views
{
    partial class PersonMenuVIewForm
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
            this.PersonDataLabel = new System.Windows.Forms.Label();
            this.AgeTitleLabel = new System.Windows.Forms.Label();
            this.WeightsListBox = new System.Windows.Forms.ListBox();
            this.WeightsTitleLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BMITitleLabel = new System.Windows.Forms.Label();
            this.BMIValueLabel = new System.Windows.Forms.Label();
            this.WhatMeansTitleLabel = new System.Windows.Forms.Label();
            this.WhatMeansLabel = new System.Windows.Forms.Label();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.HeightTitleLabel = new System.Windows.Forms.Label();
            this.DeletePersonButton = new System.Windows.Forms.Button();
            this.ChangePersonButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PersonDataLabel
            // 
            this.PersonDataLabel.AutoSize = true;
            this.PersonDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.PersonDataLabel.Location = new System.Drawing.Point(15, 9);
            this.PersonDataLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PersonDataLabel.Name = "PersonDataLabel";
            this.PersonDataLabel.Size = new System.Drawing.Size(166, 31);
            this.PersonDataLabel.TabIndex = 0;
            this.PersonDataLabel.Text = "Name: N/N ";
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
            this.WeightsListBox.Size = new System.Drawing.Size(232, 254);
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
            this.AddButton.Location = new System.Drawing.Point(340, 300);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(108, 47);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add weight";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(454, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 47);
            this.button1.TabIndex = 5;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BMITitleLabel
            // 
            this.BMITitleLabel.AutoSize = true;
            this.BMITitleLabel.Location = new System.Drawing.Point(16, 163);
            this.BMITitleLabel.Name = "BMITitleLabel";
            this.BMITitleLabel.Size = new System.Drawing.Size(57, 26);
            this.BMITitleLabel.TabIndex = 6;
            this.BMITitleLabel.Text = "BMI:";
            // 
            // BMIValueLabel
            // 
            this.BMIValueLabel.AutoSize = true;
            this.BMIValueLabel.Location = new System.Drawing.Point(74, 163);
            this.BMIValueLabel.Name = "BMIValueLabel";
            this.BMIValueLabel.Size = new System.Drawing.Size(107, 26);
            this.BMIValueLabel.TabIndex = 7;
            this.BMIValueLabel.Text = "BmiValue";
            // 
            // WhatMeansTitleLabel
            // 
            this.WhatMeansTitleLabel.AutoSize = true;
            this.WhatMeansTitleLabel.Location = new System.Drawing.Point(16, 211);
            this.WhatMeansTitleLabel.Name = "WhatMeansTitleLabel";
            this.WhatMeansTitleLabel.Size = new System.Drawing.Size(133, 26);
            this.WhatMeansTitleLabel.TabIndex = 8;
            this.WhatMeansTitleLabel.Text = "Co oznacza:";
            // 
            // WhatMeansLabel
            // 
            this.WhatMeansLabel.AutoSize = true;
            this.WhatMeansLabel.Location = new System.Drawing.Point(16, 237);
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
            this.HeightLabel.Location = new System.Drawing.Point(103, 84);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(75, 26);
            this.HeightLabel.TabIndex = 12;
            this.HeightLabel.Text = "Height";
            // 
            // HeightTitleLabel
            // 
            this.HeightTitleLabel.AutoSize = true;
            this.HeightTitleLabel.Location = new System.Drawing.Point(16, 84);
            this.HeightTitleLabel.Name = "HeightTitleLabel";
            this.HeightTitleLabel.Size = new System.Drawing.Size(81, 26);
            this.HeightTitleLabel.TabIndex = 11;
            this.HeightTitleLabel.Text = "Height:";
            // 
            // DeletePersonButton
            // 
            this.DeletePersonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DeletePersonButton.Location = new System.Drawing.Point(12, 336);
            this.DeletePersonButton.Name = "DeletePersonButton";
            this.DeletePersonButton.Size = new System.Drawing.Size(169, 33);
            this.DeletePersonButton.TabIndex = 13;
            this.DeletePersonButton.Text = "Delete person";
            this.DeletePersonButton.UseVisualStyleBackColor = true;
            // 
            // ChangePersonButton
            // 
            this.ChangePersonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ChangePersonButton.Location = new System.Drawing.Point(12, 286);
            this.ChangePersonButton.Name = "ChangePersonButton";
            this.ChangePersonButton.Size = new System.Drawing.Size(169, 34);
            this.ChangePersonButton.TabIndex = 14;
            this.ChangePersonButton.Text = "Change data";
            this.ChangePersonButton.UseVisualStyleBackColor = true;
            // 
            // PersonMenuVIewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.ChangePersonButton);
            this.Controls.Add(this.DeletePersonButton);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.HeightTitleLabel);
            this.Controls.Add(this.AgeLabel);
            this.Controls.Add(this.WhatMeansLabel);
            this.Controls.Add(this.WhatMeansTitleLabel);
            this.Controls.Add(this.BMIValueLabel);
            this.Controls.Add(this.BMITitleLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.WeightsTitleLabel);
            this.Controls.Add(this.WeightsListBox);
            this.Controls.Add(this.AgeTitleLabel);
            this.Controls.Add(this.PersonDataLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PersonMenuVIewForm";
            this.Text = "PersonMenuVIewForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PersonDataLabel;
        private System.Windows.Forms.Label AgeTitleLabel;
        private System.Windows.Forms.ListBox WeightsListBox;
        private System.Windows.Forms.Label WeightsTitleLabel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label BMITitleLabel;
        private System.Windows.Forms.Label BMIValueLabel;
        private System.Windows.Forms.Label WhatMeansTitleLabel;
        private System.Windows.Forms.Label WhatMeansLabel;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label HeightTitleLabel;
        private System.Windows.Forms.Button DeletePersonButton;
        private System.Windows.Forms.Button ChangePersonButton;
    }
}