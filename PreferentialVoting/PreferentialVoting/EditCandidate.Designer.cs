namespace PreferentialVoting
{
    partial class EditCandidate
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
            this.EditCandidateButton = new System.Windows.Forms.Button();
            this.CandidateTextBox = new System.Windows.Forms.TextBox();
            this.CandidateHeadingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EditCandidateButton
            // 
            this.EditCandidateButton.Location = new System.Drawing.Point(103, 209);
            this.EditCandidateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EditCandidateButton.Name = "EditCandidateButton";
            this.EditCandidateButton.Size = new System.Drawing.Size(131, 28);
            this.EditCandidateButton.TabIndex = 11;
            this.EditCandidateButton.Text = "Change";
            this.EditCandidateButton.UseVisualStyleBackColor = true;
            this.EditCandidateButton.Click += new System.EventHandler(this.EditCandidateButton_Click);
            // 
            // CandidateTextBox
            // 
            this.CandidateTextBox.Location = new System.Drawing.Point(85, 125);
            this.CandidateTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CandidateTextBox.Name = "CandidateTextBox";
            this.CandidateTextBox.Size = new System.Drawing.Size(161, 22);
            this.CandidateTextBox.TabIndex = 10;
            // 
            // CandidateHeadingLabel
            // 
            this.CandidateHeadingLabel.AutoSize = true;
            this.CandidateHeadingLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CandidateHeadingLabel.Location = new System.Drawing.Point(89, 87);
            this.CandidateHeadingLabel.Name = "CandidateHeadingLabel";
            this.CandidateHeadingLabel.Size = new System.Drawing.Size(154, 16);
            this.CandidateHeadingLabel.TabIndex = 9;
            this.CandidateHeadingLabel.Text = "Rename the Candidate";
            // 
            // EditCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 322);
            this.Controls.Add(this.EditCandidateButton);
            this.Controls.Add(this.CandidateTextBox);
            this.Controls.Add(this.CandidateHeadingLabel);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "EditCandidate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Candidate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EditCandidateButton;
        private System.Windows.Forms.TextBox CandidateTextBox;
        private System.Windows.Forms.Label CandidateHeadingLabel;
    }
}