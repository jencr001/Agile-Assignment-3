using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PreferentialVoting
{
    /// <summary>
    /// Class that edits a candidate
    /// </summary>
    public partial class EditCandidate : Form
    {
        private Main mainForm;          // An instance of the MainForm class
        private string oldCandidate;    // Holds the name of the candidate to change

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainForm">Instance of the mainForm</param>
        public EditCandidate(Main mainForm, string oldCandidate)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.oldCandidate = oldCandidate;
            this.CandidateTextBox.Text = this.oldCandidate;
        }

        /// <summary>
        /// Edits the candidate
        /// </summary>
        /// <param name="sender">The handle to the button</param>
        /// <param name="e">The extra messages</param>
        private void EditCandidateButton_Click(object sender, EventArgs e)
        {
            // Checks if the textbox is empty
            if (CandidateTextBox.Text == "")
            {
                MessageBox.Show("Please enter a candidate", "Error");
            }

            Boolean found = false;  // Whether the value is contained in the list

            // Goes through the list and changes the found variable if the candidate is already in the list
            for (int i = 0; i < mainForm.VotesGridView.Columns.Count; i++)
            {
                if ((mainForm.VotesGridView.Columns[i].Name.Equals(CandidateTextBox.Text, StringComparison.InvariantCultureIgnoreCase)) && 
                    !mainForm.VotesGridView.Columns[i].Name.Equals(
                    mainForm.VotesGridView.Columns[mainForm.VotesGridView.CurrentCell.ColumnIndex].Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    found = true;
                }
            }

            // If the conditions are met, edits the candidate
            if (found == false && CandidateTextBox.Text != "")
            {
                mainForm.VotesGridView.Columns[mainForm.VotesGridView.CurrentCell.ColumnIndex].HeaderText = CandidateTextBox.Text;
                mainForm.VotesGridView.Columns[mainForm.VotesGridView.CurrentCell.ColumnIndex].Name = CandidateTextBox.Text;

                this.Hide();
            }

            // Checks if the textbox is empty
            if (CandidateTextBox.Text == "")
            {
                MessageBox.Show("Please enter a candidate", "Error");
            }

            // If the candidate already exists
            if (found == true)
            {
                MessageBox.Show("Candidate already exists!", "Error");
            }
        }

        /// <summary>
        /// Closes the current form
        /// </summary>
        /// <param name="sender">The handle to the button</param>
        /// <param name="e">The extra messages</param>
        private void EditCandidate_Disposed(object sender, EventArgs e)
        {
            // Closes the current form
            this.Hide();
        }
    }
}
