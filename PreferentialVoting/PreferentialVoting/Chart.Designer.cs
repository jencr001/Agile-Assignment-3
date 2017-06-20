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
            this.SuspendLayout();
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(3, 3);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(129, 23);
            this.PrintButton.TabIndex = 10;
            this.PrintButton.Text = "Print Detailed Report";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.PrintButton);
            this.Name = "Chart";
            this.Text = "Initial Vote Chart";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PrintButton;
    }
}