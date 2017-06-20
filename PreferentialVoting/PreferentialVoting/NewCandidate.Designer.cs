namespace PreferentialVoting
{
    partial class NewCandidate
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
            this.AddCandidateButton = new System.Windows.Forms.Button();
            this.CandidateTextBox = new System.Windows.Forms.TextBox();
            this.CandidateHeadingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddCandidateButton
            // 
            this.AddCandidateButton.Location = new System.Drawing.Point(88, 170);
            this.AddCandidateButton.Name = "AddCandidateButton";
            this.AddCandidateButton.Size = new System.Drawing.Size(112, 23);
            this.AddCandidateButton.TabIndex = 8;
            this.AddCandidateButton.Text = "Add Candidate";
            this.AddCandidateButton.UseVisualStyleBackColor = true;
            this.AddCandidateButton.Click += new System.EventHandler(this.AddCandidateButton_Click);
            // 
            // CandidateTextBox
            // 
            this.CandidateTextBox.Location = new System.Drawing.Point(73, 101);
            this.CandidateTextBox.Name = "CandidateTextBox";
            this.CandidateTextBox.Size = new System.Drawing.Size(139, 20);
            this.CandidateTextBox.TabIndex = 7;
            // 
            // CandidateHeadingLabel
            // 
            this.CandidateHeadingLabel.AutoSize = true;
            this.CandidateHeadingLabel.Location = new System.Drawing.Point(85, 69);
            this.CandidateHeadingLabel.Name = "CandidateHeadingLabel";
            this.CandidateHeadingLabel.Size = new System.Drawing.Size(117, 13);
            this.CandidateHeadingLabel.TabIndex = 6;
            this.CandidateHeadingLabel.Text = "Enter a New Candidate";
            // 
            // NewCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.AddCandidateButton);
            this.Controls.Add(this.CandidateTextBox);
            this.Controls.Add(this.CandidateHeadingLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewCandidate";
            this.Text = "New Candidate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddCandidateButton;
        private System.Windows.Forms.TextBox CandidateTextBox;
        private System.Windows.Forms.Label CandidateHeadingLabel;
    }
}