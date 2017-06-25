namespace PreferentialVoting
{
    partial class Chart
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
            this.PrintButton = new System.Windows.Forms.Button();
            this.ChartHeadingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(651, 3);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(150, 28);
            this.PrintButton.TabIndex = 10;
            this.PrintButton.Text = "Print Detailed Report";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // ChartHeadingLabel
            // 
            this.ChartHeadingLabel.AutoSize = true;
            this.ChartHeadingLabel.Location = new System.Drawing.Point(12, 9);
            this.ChartHeadingLabel.Name = "ChartHeadingLabel";
            this.ChartHeadingLabel.Size = new System.Drawing.Size(188, 16);
            this.ChartHeadingLabel.TabIndex = 11;
            this.ChartHeadingLabel.Text = "The first round of voting results:";
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(804, 432);
            this.Controls.Add(this.ChartHeadingLabel);
            this.Controls.Add(this.PrintButton);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Chart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Initial Vote Chart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Label ChartHeadingLabel;
    }
}