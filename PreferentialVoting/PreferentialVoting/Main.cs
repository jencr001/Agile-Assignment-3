using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PreferentialVoting.Classes;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PreferentialVoting
{
    /// <summary>
    /// Class that allows for the user to interact with the application
    /// </summary>
    public partial class Main : Form
    {
        private VotesList allVotes;
        private List<string> candidates;

        public Main()
        {
            InitializeComponent();
            
            allVotes = new VotesList();
            candidates = new List<string>();
            
           // VotesGridView.Columns.Add("Chocolate", "Chocolate");
           // VotesGridView.Columns.Add("Ice-Cream", "Ice-Cream");
           // VotesGridView.Columns.Add("Chips", "Chips");

         
            /*
            vote.Add("Ice-Cream", 3);
            vote.Add("Chocolate", 1);
            
            vote.Add("Chips", 2);
            allVotes.Add(vote);
             */
           // foreach (string c in candidates) {
                
            //}
            /*
            foreach (Dictionary<string, int> v in allVotes)
            {
                DataGridViewRow row = (DataGridViewRow)VotesGridView.Rows[0].Clone();
   
                foreach(KeyValuePair<string, int> entry in v) {
                    row.Cells[candidates.IndexOf(entry.Key)].Value = entry.Value;
                 
                }
                VotesGridView.Rows.Add(row);
            }*/

        }



        private void ImportCSVButton_Click(object sender, EventArgs e)
        {
            // Tries to load a file that the user selects
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();    // Creates a dialog to ask the user which file to load

                // Checks if the user didn't press cancel
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;   // Stores the name of the file to load

                    // Checks if the name of the file is valid and then opens a stream  
                    if (File.Exists(filename))
                    {
                        FileStream stream = new FileStream(filename, FileMode.Open);    // Creates a new filestream to write data to
                        List<string> lines = new List<string>();
                        try
                        {
                              
                            StreamReader sr = new StreamReader(stream);

                            // read data in line by line
                            while ((sr.ReadLine()) != null)
                            {
                                Console.WriteLine(lines);
                                lines.Add(sr.ReadLine());
                            }
                            sr.Close();
                            // Result of the stream


                            bool first = true;
                            string[] headers;
                            foreach (string line in lines)
                            {
                                if (first)
                                {
                                    headers = line.Split(',');
                                    foreach (string h in headers)
                                    {
                                        bool found = false;
                                        for (int i = 0; i < VotesGridView.Columns.Count; i++)
                                        {
                                            if ((VotesGridView.Columns[i].Name.Equals(h, StringComparison.InvariantCultureIgnoreCase)))
                                            {
                                                found = true;
                                                break;
                                            }
                                        }
                                        if (!found)
                                        {
                                            VotesGridView.Columns.Add(h, h);
                                        }


                                    }
                                    first = false;
                                }
                                    else
                                {
                                      
                                }
                            }
                         
                            // Checks for errors
                        }
                        catch (ArgumentNullException ex)
                        {
                            MessageBox.Show("Error: File can't be accessed");

                        }
                        // Closes the stream
                        finally
                        {
                            stream.Close();
                        }
                    }
                    
                }
                // If there is an error, display it
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Not correct type of file");
            }
        }

        private void CountVotesButton_Click(object sender, EventArgs e)
        {
            if (this.VotesGridView.Columns.Count > 1)
            {
                allVotes = new VotesList();
                candidates = new List<string>();
                foreach (DataGridViewColumn col in this.VotesGridView.Columns)
                {
                    candidates.Add(col.Name);
                }
                for (int i = 0; i < VotesGridView.Rows.Count - 1; i++)
                {
                    Vote vote = new Vote();
                    foreach (DataGridViewCell cell in VotesGridView.Rows[i].Cells)
                    {
                        if (cell.Value == null)
                        {
                            vote.Add(VotesGridView.Columns[cell.ColumnIndex].Name, -1);
                        }
                        else
                        {
                            int n;

                            if (int.TryParse(cell.Value.ToString(), out n))
                            {

                                vote.Add(VotesGridView.Columns[cell.ColumnIndex].Name, n);
                            }
                            else
                            {
                                MessageBox.Show("Value must be a number");
                                return;
                            }
                        }
                    }
                    allVotes.Add(vote);
                }

                Result finalResult = allVotes.calculateResult(candidates);
           
                

                this.InvalidVotesLabel.Text = "" + finalResult.NumberOfInvalidVotes;

                string winnerText = "";

                if (finalResult != null)
                {

                    if (finalResult.Winners.Count == 1)
                    {
                        winnerText = finalResult.Winners[0];
                    }
                    else
                    {
                        for (int i = 0; i < finalResult.Winners.Count; i++)
                        {

                            if (i == finalResult.Winners.Count - 1)
                            {
                                winnerText += finalResult.Winners[i] + " tie";
                            }
                            else
                            {
                                winnerText += finalResult.Winners[i] + " and ";
                            }
                        }

                    }
                }
                WinnerLabel.Text = winnerText;
                Chart chart = new Chart(finalResult);
                chart.ShowDialog();
            }

            else
            {
                MessageBox.Show("Must have at least 2 candidates", "Error");
            }

        }



        private void NewCandidateButton_Click(object sender, EventArgs e)
        {
            // Stupid fix
            this.VotesGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            NewCandidate newCandidate = new NewCandidate(this);
            newCandidate.Show();
        }

        /// <summary>
        /// Removes a selected candidate from the gridView
        /// </summary>
        /// <param name="sender">The handle to the button</param>
        /// <param name="e">The extra messages</param>
        private void RemoveCandidateButton_Click(object sender, EventArgs e)
        {

            // Checks if a part has been selected then removes it from the gridView
            if (this.VotesGridView.SelectedColumns.Count > 0)
            {
                this.VotesGridView.Columns.RemoveAt(this.VotesGridView.CurrentCell.ColumnIndex);

            }

            // User is informed to select a candidate first, before deleting
            else
            {
                MessageBox.Show("You need to select a column first in order to delete it");
            }
        }

        /// <summary>
        /// Changes the gridView to select an entire column by clicking on the header
        /// </summary>
        /// <param name="sender">The handle to the column</param>
        /// <param name="e">The extra messages</param>
        private void VotesGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            this.VotesGridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        /// <summary>
        /// When a column is added, the header when selected won't automatically sort the data
        /// </summary>
        /// <param name="sender">The handle to the column</param>
        /// <param name="e">The extra messages</param>
        private void VotesGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            this.VotesGridView.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        /// <summary>
        /// Changes the gridView to select an entire row by clicking on the header
        /// </summary>
        /// <param name="sender">The handle to the row</param>
        /// <param name="e">The extra messages</param>
        private void VotesGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.VotesGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        private void editCandidateButton_Click(object sender, EventArgs e)
        {

            // Checks if a part has been selected then removes it from the gridView
            if (this.VotesGridView.SelectedColumns.Count > 0)
            {
                // Stupid fix
                this.VotesGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

                EditCandidate editCandidate = new EditCandidate(this);
                editCandidate.Show();

            }

            // User is informed to select a candidate first, before editing
            else
            {
                MessageBox.Show("You need to select a column first in order to edit it");
            }
        }

        private void ResetVoteButton_Click(object sender, EventArgs e)
        {
            // Stupid fix
            this.VotesGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            this.VotesGridView.Columns.Clear();
            allVotes = new VotesList();
            candidates = new List<string>();
            WinnerLabel.Text = "None";
            InvalidVotesLabel.Text = "0";
           
            // TODO: Clear chart somehow

        }

    }
}
