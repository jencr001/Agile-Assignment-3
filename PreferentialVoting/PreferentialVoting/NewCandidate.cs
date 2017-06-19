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
    /// Class that adds a candidate
    /// </summary>
    public partial class NewCandidate : Form
    {

        private Main mainForm;     // An instance of the MainForm class

        public NewCandidate(Main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

        }

        /// <summary>
        /// Adds the candidate to the list
        /// </summary>
        /// <param name="sender">The handle to the button</param>
        /// <param name="e">The extra messages</param>
        private void AddCandidateButton_Click(object sender, EventArgs e)
        {

            Boolean found = false;  // Whether the value is contained in the list

            // Goes through the list and changes the found variable if the candidate is already in the list
            for (int i = 0; i < mainForm.VotesGridView.Columns.Count; i++)
            {
                if ((mainForm.VotesGridView.Columns[i].Name.Equals(CandidateTextBox.Text, StringComparison.InvariantCultureIgnoreCase)))
                {
                    found = true;
                }
            }

            // If the conditions are met, adds the candidate to the list and grid view
            if (found == false && CandidateTextBox.Text != "")
            {
                mainForm.VotesGridView.Columns.Add(CandidateTextBox.Text, CandidateTextBox.Text);
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
        private void NewCandidate_Disposed(object sender, EventArgs e)
        {

            // Closes the current form
            this.Hide();
        }
    }
}
