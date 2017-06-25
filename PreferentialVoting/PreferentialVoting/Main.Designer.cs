namespace PreferentialVoting
{
    partial class Main
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
            this.NewCandidateButton = new System.Windows.Forms.Button();
            this.editCandidateButton = new System.Windows.Forms.Button();
            this.RemoveCandidateButton = new System.Windows.Forms.Button();
            this.ImportCSVButton = new System.Windows.Forms.Button();
            this.CountVotesButton = new System.Windows.Forms.Button();
            this.ResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.WinnerLabel = new System.Windows.Forms.Label();
            this.WinnerHeadingLabel = new System.Windows.Forms.Label();
            this.InvalidVotesLabel = new System.Windows.Forms.Label();
            this.InvalidVotesHeadingLabel = new System.Windows.Forms.Label();
            this.ExportCSVButton = new System.Windows.Forms.Button();
            this.ResetVoteButton = new System.Windows.Forms.Button();
            this.HeadingHeadingLabel = new System.Windows.Forms.Label();
            this.CandidateGroupBox = new System.Windows.Forms.GroupBox();
            this.VotesGridView = new System.Windows.Forms.DataGridView();
            this.DeleteHeadingLabel = new System.Windows.Forms.Label();
            this.ResultsGroupBox.SuspendLayout();
            this.CandidateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VotesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // NewCandidateButton
            // 
            this.NewCandidateButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewCandidateButton.Location = new System.Drawing.Point(24, 23);
            this.NewCandidateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NewCandidateButton.Name = "NewCandidateButton";
            this.NewCandidateButton.Size = new System.Drawing.Size(104, 28);
            this.NewCandidateButton.TabIndex = 0;
            this.NewCandidateButton.Text = "New Candidate";
            this.NewCandidateButton.UseVisualStyleBackColor = true;
            this.NewCandidateButton.Click += new System.EventHandler(this.NewCandidateButton_Click);
            // 
            // editCandidateButton
            // 
            this.editCandidateButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCandidateButton.Location = new System.Drawing.Point(134, 23);
            this.editCandidateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editCandidateButton.Name = "editCandidateButton";
            this.editCandidateButton.Size = new System.Drawing.Size(104, 28);
            this.editCandidateButton.TabIndex = 1;
            this.editCandidateButton.Text = "Edit Candidate";
            this.editCandidateButton.UseVisualStyleBackColor = true;
            this.editCandidateButton.Click += new System.EventHandler(this.editCandidateButton_Click);
            // 
            // RemoveCandidateButton
            // 
            this.RemoveCandidateButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveCandidateButton.Location = new System.Drawing.Point(244, 23);
            this.RemoveCandidateButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemoveCandidateButton.Name = "RemoveCandidateButton";
            this.RemoveCandidateButton.Size = new System.Drawing.Size(131, 28);
            this.RemoveCandidateButton.TabIndex = 2;
            this.RemoveCandidateButton.Text = "Remove Candidate";
            this.RemoveCandidateButton.UseVisualStyleBackColor = true;
            this.RemoveCandidateButton.Click += new System.EventHandler(this.RemoveCandidateButton_Click);
            // 
            // ImportCSVButton
            // 
            this.ImportCSVButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportCSVButton.Location = new System.Drawing.Point(586, 23);
            this.ImportCSVButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ImportCSVButton.Name = "ImportCSVButton";
            this.ImportCSVButton.Size = new System.Drawing.Size(131, 28);
            this.ImportCSVButton.TabIndex = 3;
            this.ImportCSVButton.Text = "Import CSV";
            this.ImportCSVButton.UseVisualStyleBackColor = true;
            this.ImportCSVButton.Click += new System.EventHandler(this.ImportCSVButton_Click);
            // 
            // CountVotesButton
            // 
            this.CountVotesButton.Location = new System.Drawing.Point(319, 421);
            this.CountVotesButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CountVotesButton.Name = "CountVotesButton";
            this.CountVotesButton.Size = new System.Drawing.Size(87, 28);
            this.CountVotesButton.TabIndex = 6;
            this.CountVotesButton.Text = "Count Votes";
            this.CountVotesButton.UseVisualStyleBackColor = true;
            this.CountVotesButton.Click += new System.EventHandler(this.CountVotesButton_Click);
            // 
            // ResultsGroupBox
            // 
            this.ResultsGroupBox.Controls.Add(this.WinnerLabel);
            this.ResultsGroupBox.Controls.Add(this.WinnerHeadingLabel);
            this.ResultsGroupBox.Controls.Add(this.InvalidVotesLabel);
            this.ResultsGroupBox.Controls.Add(this.InvalidVotesHeadingLabel);
            this.ResultsGroupBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultsGroupBox.Location = new System.Drawing.Point(15, 488);
            this.ResultsGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ResultsGroupBox.Name = "ResultsGroupBox";
            this.ResultsGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ResultsGroupBox.Size = new System.Drawing.Size(749, 171);
            this.ResultsGroupBox.TabIndex = 7;
            this.ResultsGroupBox.TabStop = false;
            this.ResultsGroupBox.Text = "Results";
            // 
            // WinnerLabel
            // 
            this.WinnerLabel.AutoSize = true;
            this.WinnerLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinnerLabel.Location = new System.Drawing.Point(272, 52);
            this.WinnerLabel.Name = "WinnerLabel";
            this.WinnerLabel.Size = new System.Drawing.Size(38, 16);
            this.WinnerLabel.TabIndex = 9;
            this.WinnerLabel.Text = "None";
            // 
            // WinnerHeadingLabel
            // 
            this.WinnerHeadingLabel.AutoSize = true;
            this.WinnerHeadingLabel.Location = new System.Drawing.Point(36, 52);
            this.WinnerHeadingLabel.Name = "WinnerHeadingLabel";
            this.WinnerHeadingLabel.Size = new System.Drawing.Size(230, 16);
            this.WinnerHeadingLabel.TabIndex = 8;
            this.WinnerHeadingLabel.Text = "The Candidate That Won the Vote: ";
            // 
            // InvalidVotesLabel
            // 
            this.InvalidVotesLabel.AutoSize = true;
            this.InvalidVotesLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvalidVotesLabel.Location = new System.Drawing.Point(141, 100);
            this.InvalidVotesLabel.Name = "InvalidVotesLabel";
            this.InvalidVotesLabel.Size = new System.Drawing.Size(15, 16);
            this.InvalidVotesLabel.TabIndex = 7;
            this.InvalidVotesLabel.Text = "0";
            // 
            // InvalidVotesHeadingLabel
            // 
            this.InvalidVotesHeadingLabel.AutoSize = true;
            this.InvalidVotesHeadingLabel.Location = new System.Drawing.Point(36, 100);
            this.InvalidVotesHeadingLabel.Name = "InvalidVotesHeadingLabel";
            this.InvalidVotesHeadingLabel.Size = new System.Drawing.Size(93, 16);
            this.InvalidVotesHeadingLabel.TabIndex = 6;
            this.InvalidVotesHeadingLabel.Text = "Invalid Votes:";
            // 
            // ExportCSVButton
            // 
            this.ExportCSVButton.Location = new System.Drawing.Point(601, 667);
            this.ExportCSVButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ExportCSVButton.Name = "ExportCSVButton";
            this.ExportCSVButton.Size = new System.Drawing.Size(162, 28);
            this.ExportCSVButton.TabIndex = 8;
            this.ExportCSVButton.Text = "Export Results as CSV";
            this.ExportCSVButton.UseVisualStyleBackColor = true;
            this.ExportCSVButton.Click += new System.EventHandler(this.ExportCSVButton_Click);
            // 
            // ResetVoteButton
            // 
            this.ResetVoteButton.Location = new System.Drawing.Point(625, 421);
            this.ResetVoteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ResetVoteButton.Name = "ResetVoteButton";
            this.ResetVoteButton.Size = new System.Drawing.Size(139, 28);
            this.ResetVoteButton.TabIndex = 10;
            this.ResetVoteButton.Text = "Reset All";
            this.ResetVoteButton.UseVisualStyleBackColor = true;
            this.ResetVoteButton.Click += new System.EventHandler(this.ResetVoteButton_Click);
            // 
            // HeadingHeadingLabel
            // 
            this.HeadingHeadingLabel.AutoSize = true;
            this.HeadingHeadingLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadingHeadingLabel.Location = new System.Drawing.Point(34, 31);
            this.HeadingHeadingLabel.Name = "HeadingHeadingLabel";
            this.HeadingHeadingLabel.Size = new System.Drawing.Size(215, 19);
            this.HeadingHeadingLabel.TabIndex = 11;
            this.HeadingHeadingLabel.Text = "Preferential Voting Counter";
            // 
            // CandidateGroupBox
            // 
            this.CandidateGroupBox.Controls.Add(this.DeleteHeadingLabel);
            this.CandidateGroupBox.Controls.Add(this.editCandidateButton);
            this.CandidateGroupBox.Controls.Add(this.VotesGridView);
            this.CandidateGroupBox.Controls.Add(this.ImportCSVButton);
            this.CandidateGroupBox.Controls.Add(this.RemoveCandidateButton);
            this.CandidateGroupBox.Controls.Add(this.NewCandidateButton);
            this.CandidateGroupBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CandidateGroupBox.Location = new System.Drawing.Point(14, 74);
            this.CandidateGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CandidateGroupBox.Name = "CandidateGroupBox";
            this.CandidateGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CandidateGroupBox.Size = new System.Drawing.Size(749, 339);
            this.CandidateGroupBox.TabIndex = 12;
            this.CandidateGroupBox.TabStop = false;
            this.CandidateGroupBox.Text = "Candidates";
            // 
            // VotesGridView
            // 
            this.VotesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VotesGridView.Location = new System.Drawing.Point(24, 59);
            this.VotesGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VotesGridView.MultiSelect = false;
            this.VotesGridView.Name = "VotesGridView";
            this.VotesGridView.Size = new System.Drawing.Size(693, 245);
            this.VotesGridView.TabIndex = 4;
            this.VotesGridView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.VotesGridView_ColumnAdded);
            this.VotesGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.VotesGridView_ColumnHeaderMouseClick);
            this.VotesGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.VotesGridView_RowHeaderMouseClick);
            // 
            // DeleteHeadingLabel
            // 
            this.DeleteHeadingLabel.AutoSize = true;
            this.DeleteHeadingLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteHeadingLabel.Location = new System.Drawing.Point(24, 308);
            this.DeleteHeadingLabel.Name = "DeleteHeadingLabel";
            this.DeleteHeadingLabel.Size = new System.Drawing.Size(413, 16);
            this.DeleteHeadingLabel.TabIndex = 5;
            this.DeleteHeadingLabel.Text = "To delete a row, select the full row and press \'Delete\' on your keyboard";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 708);
            this.Controls.Add(this.CandidateGroupBox);
            this.Controls.Add(this.HeadingHeadingLabel);
            this.Controls.Add(this.ResetVoteButton);
            this.Controls.Add(this.ExportCSVButton);
            this.Controls.Add(this.ResultsGroupBox);
            this.Controls.Add(this.CountVotesButton);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferential Voting";
            this.ResultsGroupBox.ResumeLayout(false);
            this.ResultsGroupBox.PerformLayout();
            this.CandidateGroupBox.ResumeLayout(false);
            this.CandidateGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VotesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewCandidateButton;
        private System.Windows.Forms.Button editCandidateButton;
        private System.Windows.Forms.Button RemoveCandidateButton;
        private System.Windows.Forms.Button ImportCSVButton;
        private System.Windows.Forms.Button CountVotesButton;
        private System.Windows.Forms.GroupBox ResultsGroupBox;
        private System.Windows.Forms.Label InvalidVotesLabel;
        private System.Windows.Forms.Label InvalidVotesHeadingLabel;
        private System.Windows.Forms.Label WinnerHeadingLabel;
        private System.Windows.Forms.Button ExportCSVButton;
        private System.Windows.Forms.Button ResetVoteButton;
        private System.Windows.Forms.Label HeadingHeadingLabel;
        private System.Windows.Forms.GroupBox CandidateGroupBox;
        private System.Windows.Forms.Label WinnerLabel;
        internal System.Windows.Forms.DataGridView VotesGridView;
        private System.Windows.Forms.Label DeleteHeadingLabel;
    }
}

