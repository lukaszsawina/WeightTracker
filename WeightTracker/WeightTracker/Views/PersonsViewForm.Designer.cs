namespace WeightTracker
{
    partial class PersonsViewForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TitleAddNewPerson = new System.Windows.Forms.Label();
            this.SelectPersonButton = new System.Windows.Forms.Button();
            this.SelectPersonLabel = new System.Windows.Forms.Label();
            this.PersonListBox = new System.Windows.Forms.ListBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.AgeTextBox = new System.Windows.Forms.TextBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.NewPersonAddButton = new System.Windows.Forms.Button();
            this.ClearNewPersonFormButton = new System.Windows.Forms.Button();
            this.ErrorInputLabel = new System.Windows.Forms.Label();
            this.LoadDataProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            // 
            // TitleAddNewPerson
            // 
            this.TitleAddNewPerson.AutoSize = true;
            this.TitleAddNewPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold);
            this.TitleAddNewPerson.Location = new System.Drawing.Point(18, 14);
            this.TitleAddNewPerson.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TitleAddNewPerson.Name = "TitleAddNewPerson";
            this.TitleAddNewPerson.Size = new System.Drawing.Size(279, 39);
            this.TitleAddNewPerson.TabIndex = 1;
            this.TitleAddNewPerson.Text = "Add new person";
            // 
            // SelectPersonButton
            // 
            this.SelectPersonButton.Location = new System.Drawing.Point(308, 304);
            this.SelectPersonButton.Name = "SelectPersonButton";
            this.SelectPersonButton.Size = new System.Drawing.Size(232, 34);
            this.SelectPersonButton.TabIndex = 11;
            this.SelectPersonButton.Text = "Select";
            this.SelectPersonButton.UseVisualStyleBackColor = true;
            this.SelectPersonButton.Click += new System.EventHandler(this.SelectPersonButton_Click);
            // 
            // SelectPersonLabel
            // 
            this.SelectPersonLabel.AutoSize = true;
            this.SelectPersonLabel.Location = new System.Drawing.Point(304, 72);
            this.SelectPersonLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SelectPersonLabel.Name = "SelectPersonLabel";
            this.SelectPersonLabel.Size = new System.Drawing.Size(166, 20);
            this.SelectPersonLabel.TabIndex = 12;
            this.SelectPersonLabel.Text = "Select person from list";
            // 
            // PersonListBox
            // 
            this.PersonListBox.FormattingEnabled = true;
            this.PersonListBox.ItemHeight = 20;
            this.PersonListBox.Location = new System.Drawing.Point(308, 97);
            this.PersonListBox.Name = "PersonListBox";
            this.PersonListBox.Size = new System.Drawing.Size(232, 184);
            this.PersonListBox.TabIndex = 13;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(67, 72);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(51, 20);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(69, 97);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(148, 26);
            this.NameTextBox.TabIndex = 3;
            // 
            // AgeLabel
            // 
            this.AgeLabel.AutoSize = true;
            this.AgeLabel.Location = new System.Drawing.Point(67, 128);
            this.AgeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(38, 20);
            this.AgeLabel.TabIndex = 4;
            this.AgeLabel.Text = "Age";
            // 
            // AgeTextBox
            // 
            this.AgeTextBox.Location = new System.Drawing.Point(69, 153);
            this.AgeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AgeTextBox.Name = "AgeTextBox";
            this.AgeTextBox.Size = new System.Drawing.Size(148, 26);
            this.AgeTextBox.TabIndex = 5;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(68, 184);
            this.HeightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(56, 20);
            this.HeightLabel.TabIndex = 6;
            this.HeightLabel.Text = "Height";
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(70, 209);
            this.HeightTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(148, 26);
            this.HeightTextBox.TabIndex = 7;
            // 
            // NewPersonAddButton
            // 
            this.NewPersonAddButton.Location = new System.Drawing.Point(68, 261);
            this.NewPersonAddButton.Name = "NewPersonAddButton";
            this.NewPersonAddButton.Size = new System.Drawing.Size(149, 34);
            this.NewPersonAddButton.TabIndex = 8;
            this.NewPersonAddButton.Text = "Add";
            this.NewPersonAddButton.UseVisualStyleBackColor = true;
            this.NewPersonAddButton.Click += new System.EventHandler(this.NewPersonAddButton_Click);
            // 
            // ClearNewPersonFormButton
            // 
            this.ClearNewPersonFormButton.Location = new System.Drawing.Point(68, 304);
            this.ClearNewPersonFormButton.Name = "ClearNewPersonFormButton";
            this.ClearNewPersonFormButton.Size = new System.Drawing.Size(149, 34);
            this.ClearNewPersonFormButton.TabIndex = 9;
            this.ClearNewPersonFormButton.Text = "Clear";
            this.ClearNewPersonFormButton.UseVisualStyleBackColor = true;
            this.ClearNewPersonFormButton.Click += new System.EventHandler(this.ClearNewPersonFormButton_Click);
            // 
            // ErrorInputLabel
            // 
            this.ErrorInputLabel.AutoSize = true;
            this.ErrorInputLabel.ForeColor = System.Drawing.Color.Coral;
            this.ErrorInputLabel.Location = new System.Drawing.Point(71, 242);
            this.ErrorInputLabel.Name = "ErrorInputLabel";
            this.ErrorInputLabel.Size = new System.Drawing.Size(0, 20);
            this.ErrorInputLabel.TabIndex = 14;
            // 
            // LoadDataProgressBar
            // 
            this.LoadDataProgressBar.Location = new System.Drawing.Point(308, 282);
            this.LoadDataProgressBar.Name = "LoadDataProgressBar";
            this.LoadDataProgressBar.Size = new System.Drawing.Size(232, 13);
            this.LoadDataProgressBar.TabIndex = 15;
            // 
            // PersonsViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.LoadDataProgressBar);
            this.Controls.Add(this.ErrorInputLabel);
            this.Controls.Add(this.PersonListBox);
            this.Controls.Add(this.SelectPersonLabel);
            this.Controls.Add(this.SelectPersonButton);
            this.Controls.Add(this.ClearNewPersonFormButton);
            this.Controls.Add(this.NewPersonAddButton);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.AgeTextBox);
            this.Controls.Add(this.AgeLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.TitleAddNewPerson);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PersonsViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weight Track app";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PersonsViewForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TitleAddNewPerson;
        private System.Windows.Forms.Button SelectPersonButton;
        private System.Windows.Forms.Label SelectPersonLabel;
        private System.Windows.Forms.ListBox PersonListBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.TextBox AgeTextBox;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.Button NewPersonAddButton;
        private System.Windows.Forms.Button ClearNewPersonFormButton;
        private System.Windows.Forms.Label ErrorInputLabel;
        private System.Windows.Forms.ProgressBar LoadDataProgressBar;
    }
}

