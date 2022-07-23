namespace WeightTracker.Views
{
    partial class ChangePersonDataViewForm
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
            this.PersonNameLabel = new System.Windows.Forms.Label();
            this.PersonNameTextBox = new System.Windows.Forms.TextBox();
            this.PersonAgeTextBox = new System.Windows.Forms.TextBox();
            this.PersonAgeLabel = new System.Windows.Forms.Label();
            this.PersonHeightTextBox = new System.Windows.Forms.TextBox();
            this.PersonHeightLabel = new System.Windows.Forms.Label();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.ErrorMessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PersonNameLabel
            // 
            this.PersonNameLabel.AutoSize = true;
            this.PersonNameLabel.Location = new System.Drawing.Point(12, 9);
            this.PersonNameLabel.Name = "PersonNameLabel";
            this.PersonNameLabel.Size = new System.Drawing.Size(148, 26);
            this.PersonNameLabel.TabIndex = 0;
            this.PersonNameLabel.Text = "Person name:";
            // 
            // PersonNameTextBox
            // 
            this.PersonNameTextBox.Location = new System.Drawing.Point(17, 38);
            this.PersonNameTextBox.Name = "PersonNameTextBox";
            this.PersonNameTextBox.Size = new System.Drawing.Size(143, 32);
            this.PersonNameTextBox.TabIndex = 1;
            // 
            // PersonAgeTextBox
            // 
            this.PersonAgeTextBox.Location = new System.Drawing.Point(171, 38);
            this.PersonAgeTextBox.Name = "PersonAgeTextBox";
            this.PersonAgeTextBox.Size = new System.Drawing.Size(143, 32);
            this.PersonAgeTextBox.TabIndex = 3;
            // 
            // PersonAgeLabel
            // 
            this.PersonAgeLabel.AutoSize = true;
            this.PersonAgeLabel.Location = new System.Drawing.Point(166, 9);
            this.PersonAgeLabel.Name = "PersonAgeLabel";
            this.PersonAgeLabel.Size = new System.Drawing.Size(129, 26);
            this.PersonAgeLabel.TabIndex = 2;
            this.PersonAgeLabel.Text = "Person age:";
            // 
            // PersonHeightTextBox
            // 
            this.PersonHeightTextBox.Location = new System.Drawing.Point(17, 102);
            this.PersonHeightTextBox.Name = "PersonHeightTextBox";
            this.PersonHeightTextBox.Size = new System.Drawing.Size(143, 32);
            this.PersonHeightTextBox.TabIndex = 5;
            // 
            // PersonHeightLabel
            // 
            this.PersonHeightLabel.AutoSize = true;
            this.PersonHeightLabel.Location = new System.Drawing.Point(12, 73);
            this.PersonHeightLabel.Name = "PersonHeightLabel";
            this.PersonHeightLabel.Size = new System.Drawing.Size(152, 26);
            this.PersonHeightLabel.TabIndex = 4;
            this.PersonHeightLabel.Text = "Person height:";
            // 
            // ChangeButton
            // 
            this.ChangeButton.Location = new System.Drawing.Point(90, 140);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(143, 45);
            this.ChangeButton.TabIndex = 6;
            this.ChangeButton.Text = "Change";
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // ErrorMessageLabel
            // 
            this.ErrorMessageLabel.AutoSize = true;
            this.ErrorMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ErrorMessageLabel.Location = new System.Drawing.Point(182, 102);
            this.ErrorMessageLabel.Name = "ErrorMessageLabel";
            this.ErrorMessageLabel.Size = new System.Drawing.Size(0, 20);
            this.ErrorMessageLabel.TabIndex = 7;
            // 
            // ChangePersonDataViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 207);
            this.Controls.Add(this.ErrorMessageLabel);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.PersonHeightTextBox);
            this.Controls.Add(this.PersonHeightLabel);
            this.Controls.Add(this.PersonAgeTextBox);
            this.Controls.Add(this.PersonAgeLabel);
            this.Controls.Add(this.PersonNameTextBox);
            this.Controls.Add(this.PersonNameLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ChangePersonDataViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePersonDataViewForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PersonNameLabel;
        private System.Windows.Forms.TextBox PersonNameTextBox;
        private System.Windows.Forms.TextBox PersonAgeTextBox;
        private System.Windows.Forms.Label PersonAgeLabel;
        private System.Windows.Forms.TextBox PersonHeightTextBox;
        private System.Windows.Forms.Label PersonHeightLabel;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Label ErrorMessageLabel;
    }
}