﻿namespace PreferentialVoting
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.NewCandidateButton = new System.Windows.Forms.Button();
            this.editCandidateButton = new System.Windows.Forms.Button();
            this.RemoveCandidateButton = new System.Windows.Forms.Button();
            this.ImportCSVButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ResultsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CountVotesButton = new System.Windows.Forms.Button();
            this.ResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.InvalidVotesLabel = new System.Windows.Forms.Label();
            this.InvalidVotesHeadingLabel = new System.Windows.Forms.Label();
            this.WinnerLabel = new System.Windows.Forms.Label();
            this.ExportCSVButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.ResetVoteButton = new System.Windows.Forms.Button();
            this.HeadingHeadingLabel = new System.Windows.Forms.Label();
            this.CandidateGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsChart)).BeginInit();
            this.ResultsGroupBox.SuspendLayout();
            this.CandidateGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewCandidateButton
            // 
            this.NewCandidateButton.Location = new System.Drawing.Point(21, 19);
            this.NewCandidateButton.Name = "NewCandidateButton";
            this.NewCandidateButton.Size = new System.Drawing.Size(89, 23);
            this.NewCandidateButton.TabIndex = 0;
            this.NewCandidateButton.Text = "New Candidate";
            this.NewCandidateButton.UseVisualStyleBackColor = true;
            // 
            // editCandidateButton
            // 
            this.editCandidateButton.Location = new System.Drawing.Point(116, 19);
            this.editCandidateButton.Name = "editCandidateButton";
            this.editCandidateButton.Size = new System.Drawing.Size(89, 23);
            this.editCandidateButton.TabIndex = 1;
            this.editCandidateButton.Text = "Edit Candidate";
            this.editCandidateButton.UseVisualStyleBackColor = true;
            // 
            // RemoveCandidateButton
            // 
            this.RemoveCandidateButton.Location = new System.Drawing.Point(211, 19);
            this.RemoveCandidateButton.Name = "RemoveCandidateButton";
            this.RemoveCandidateButton.Size = new System.Drawing.Size(112, 23);
            this.RemoveCandidateButton.TabIndex = 2;
            this.RemoveCandidateButton.Text = "Remove Candidate";
            this.RemoveCandidateButton.UseVisualStyleBackColor = true;
            // 
            // ImportCSVButton
            // 
            this.ImportCSVButton.Location = new System.Drawing.Point(445, 18);
            this.ImportCSVButton.Name = "ImportCSVButton";
            this.ImportCSVButton.Size = new System.Drawing.Size(112, 23);
            this.ImportCSVButton.TabIndex = 3;
            this.ImportCSVButton.Text = "Import CSV";
            this.ImportCSVButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(536, 199);
            this.dataGridView1.TabIndex = 4;
            // 
            // ResultsChart
            // 
            chartArea1.Name = "ChartArea1";
            this.ResultsChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ResultsChart.Legends.Add(legend1);
            this.ResultsChart.Location = new System.Drawing.Point(17, 76);
            this.ResultsChart.Name = "ResultsChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ResultsChart.Series.Add(series1);
            this.ResultsChart.Size = new System.Drawing.Size(598, 147);
            this.ResultsChart.TabIndex = 5;
            this.ResultsChart.Text = "chart1";
            // 
            // CountVotesButton
            // 
            this.CountVotesButton.Location = new System.Drawing.Point(273, 319);
            this.CountVotesButton.Name = "CountVotesButton";
            this.CountVotesButton.Size = new System.Drawing.Size(75, 23);
            this.CountVotesButton.TabIndex = 6;
            this.CountVotesButton.Text = "Count Votes";
            this.CountVotesButton.UseVisualStyleBackColor = true;
            // 
            // ResultsGroupBox
            // 
            this.ResultsGroupBox.Controls.Add(this.WinnerLabel);
            this.ResultsGroupBox.Controls.Add(this.InvalidVotesLabel);
            this.ResultsGroupBox.Controls.Add(this.InvalidVotesHeadingLabel);
            this.ResultsGroupBox.Controls.Add(this.ResultsChart);
            this.ResultsGroupBox.Location = new System.Drawing.Point(12, 366);
            this.ResultsGroupBox.Name = "ResultsGroupBox";
            this.ResultsGroupBox.Size = new System.Drawing.Size(642, 268);
            this.ResultsGroupBox.TabIndex = 7;
            this.ResultsGroupBox.TabStop = false;
            this.ResultsGroupBox.Text = "Results";
            // 
            // InvalidVotesLabel
            // 
            this.InvalidVotesLabel.AutoSize = true;
            this.InvalidVotesLabel.Location = new System.Drawing.Point(121, 243);
            this.InvalidVotesLabel.Name = "InvalidVotesLabel";
            this.InvalidVotesLabel.Size = new System.Drawing.Size(43, 13);
            this.InvalidVotesLabel.TabIndex = 7;
            this.InvalidVotesLabel.Text = "000000";
            // 
            // InvalidVotesHeadingLabel
            // 
            this.InvalidVotesHeadingLabel.AutoSize = true;
            this.InvalidVotesHeadingLabel.Location = new System.Drawing.Point(31, 243);
            this.InvalidVotesHeadingLabel.Name = "InvalidVotesHeadingLabel";
            this.InvalidVotesHeadingLabel.Size = new System.Drawing.Size(71, 13);
            this.InvalidVotesHeadingLabel.TabIndex = 6;
            this.InvalidVotesHeadingLabel.Text = "Invalid Votes:";
            // 
            // WinnerLabel
            // 
            this.WinnerLabel.AutoSize = true;
            this.WinnerLabel.Location = new System.Drawing.Point(31, 42);
            this.WinnerLabel.Name = "WinnerLabel";
            this.WinnerLabel.Size = new System.Drawing.Size(177, 13);
            this.WinnerLabel.TabIndex = 8;
            this.WinnerLabel.Text = "The Candidate That Won the Vote: ";
            // 
            // ExportCSVButton
            // 
            this.ExportCSVButton.Location = new System.Drawing.Point(390, 653);
            this.ExportCSVButton.Name = "ExportCSVButton";
            this.ExportCSVButton.Size = new System.Drawing.Size(129, 23);
            this.ExportCSVButton.TabIndex = 8;
            this.ExportCSVButton.Text = "Export Results as CSV";
            this.ExportCSVButton.UseVisualStyleBackColor = true;
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(525, 653);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(129, 23);
            this.PrintButton.TabIndex = 9;
            this.PrintButton.Text = "Print Detailed Report";
            this.PrintButton.UseVisualStyleBackColor = true;
            // 
            // ResetVoteButton
            // 
            this.ResetVoteButton.Location = new System.Drawing.Point(463, 319);
            this.ResetVoteButton.Name = "ResetVoteButton";
            this.ResetVoteButton.Size = new System.Drawing.Size(119, 23);
            this.ResetVoteButton.TabIndex = 10;
            this.ResetVoteButton.Text = "Reset All";
            this.ResetVoteButton.UseVisualStyleBackColor = true;
            // 
            // HeadingHeadingLabel
            // 
            this.HeadingHeadingLabel.AutoSize = true;
            this.HeadingHeadingLabel.Location = new System.Drawing.Point(29, 25);
            this.HeadingHeadingLabel.Name = "HeadingHeadingLabel";
            this.HeadingHeadingLabel.Size = new System.Drawing.Size(133, 13);
            this.HeadingHeadingLabel.TabIndex = 11;
            this.HeadingHeadingLabel.Text = "Preferential Voting Counter";
            // 
            // CandidateGroupBox
            // 
            this.CandidateGroupBox.Controls.Add(this.editCandidateButton);
            this.CandidateGroupBox.Controls.Add(this.dataGridView1);
            this.CandidateGroupBox.Controls.Add(this.ImportCSVButton);
            this.CandidateGroupBox.Controls.Add(this.RemoveCandidateButton);
            this.CandidateGroupBox.Controls.Add(this.NewCandidateButton);
            this.CandidateGroupBox.Location = new System.Drawing.Point(25, 60);
            this.CandidateGroupBox.Name = "CandidateGroupBox";
            this.CandidateGroupBox.Size = new System.Drawing.Size(563, 253);
            this.CandidateGroupBox.TabIndex = 12;
            this.CandidateGroupBox.TabStop = false;
            this.CandidateGroupBox.Text = "Candidates";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 714);
            this.Controls.Add(this.CandidateGroupBox);
            this.Controls.Add(this.HeadingHeadingLabel);
            this.Controls.Add(this.ResetVoteButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.ExportCSVButton);
            this.Controls.Add(this.ResultsGroupBox);
            this.Controls.Add(this.CountVotesButton);
            this.Name = "Form1";
            this.Text = "Preferential Voting";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsChart)).EndInit();
            this.ResultsGroupBox.ResumeLayout(false);
            this.ResultsGroupBox.PerformLayout();
            this.CandidateGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewCandidateButton;
        private System.Windows.Forms.Button editCandidateButton;
        private System.Windows.Forms.Button RemoveCandidateButton;
        private System.Windows.Forms.Button ImportCSVButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ResultsChart;
        private System.Windows.Forms.Button CountVotesButton;
        private System.Windows.Forms.GroupBox ResultsGroupBox;
        private System.Windows.Forms.Label InvalidVotesLabel;
        private System.Windows.Forms.Label InvalidVotesHeadingLabel;
        private System.Windows.Forms.Label WinnerLabel;
        private System.Windows.Forms.Button ExportCSVButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button ResetVoteButton;
        private System.Windows.Forms.Label HeadingHeadingLabel;
        private System.Windows.Forms.GroupBox CandidateGroupBox;
    }
}

