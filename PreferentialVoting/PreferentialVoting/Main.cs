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
        private VotesList allVotes;         // List of all the votes 
        private List<string> candidates;    // List of the candidates

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Main()
        {
            InitializeComponent();

            // Creates new instances of the lists and sets the font of the dataGridView
            allVotes = new VotesList();
            candidates = new List<string>();
            this.VotesGridView.Font = new Font("Arial", 10, FontStyle.Regular);
        }
        #endregion

        #region Buttons

        #region Candidates
        /// <summary>
        /// Allows the user to add a new candidate
        /// </summary>
        /// <param name="sender">The handle to the button</param>
        /// <param name="e">The extra messages</param>
        private void NewCandidateButton_Click(object sender, EventArgs e)
        {
            this.VotesGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            // Displays a newCandidate Form
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
            // Checks if a part has been selected then removes it from the dataGridView
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
        /// Allows the user to edit a candidate
        /// </summary>
        /// <param name="sender">The handle to the column header</param>
        /// <param name="e">The extra messages</param>
        private void editCandidateButton_Click(object sender, EventArgs e)
        {
            // Checks if a part has been selected then removes it from the gridView
            if (this.VotesGridView.SelectedColumns.Count > 0)
            {
                this.VotesGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

                // Displays an editCandidate Form
                EditCandidate editCandidate = new EditCandidate(this);
                editCandidate.Show();

            }

            // User is informed to select a candidate first, before editing
            else
            {
                MessageBox.Show("You need to select a column first in order to edit it");
            }
        }
        #endregion

        #region Import/Export
        /// <summary>
        /// Imports a CSV of vote data into the dataGridView
        /// </summary>
        /// <param name="sender">The handle to the button</param>
        /// <param name="e">The extra messages</param>
        private void ImportCSVButton_Click(object sender, EventArgs e)
        {
            this.VotesGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

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
                        List<string> lines = new List<string>();                        // Stores the lines from the filestream

                        // Tries to do get the stream
                        try
                        {
                            StreamReader sr = new StreamReader(stream);     // Contents of the stream
                            string l;                                       // The current line from the stream

                            // Read data in line by line
                            while ((l = sr.ReadLine()) != null)
                            {
                                lines.Add(l);
                            }
                            sr.Close();

                            int numColumns = this.VotesGridView.Columns.Count;          // The number of colummns the dataGridView currently has
                            int numRows = this.VotesGridView.Rows.Count;                // The number of rows the dataGridView currently has
                            int differentColumns = this.VotesGridView.Columns.Count;    // Stores the number of columns that are different from the imported file
                            bool first = true;                                          // Whether, the headers are being added or the data itself
                            string[] headers;                                           // Contains the titles for the columns
                            int rowNumber = 0;                                          // What row it is currently up tp filling

                            // Goes through each of the lines from the streamreader
                            foreach (string line in lines)
                            {
                                // If column titles are being added
                                if (first)
                                {
                                    // Split the titles up
                                    string newLine = line.Replace('"', ' ').Trim();
                                    headers = newLine.Split(',');

                                    int headerLocation = this.VotesGridView.Columns.Count;  // The location of where the headers need to be added

                                    // Goes through each of the headers
                                    foreach (string h in headers)
                                    {
                                        // Removes the white space added
                                        List<char> result = h.ToList(); // Holds the candidates as a list 
                                        result.RemoveAll(c => c == ' ');
                                        string newH = new string(result.ToArray());

                                        bool found = false; // Does the candidate already exist

                                        // Goes through each of the columns
                                        for (int i = 0; i < VotesGridView.Columns.Count; i++)
                                        {
                                            // Checks to seek if the candidate already exists
                                            if ((VotesGridView.Columns[i].Name.Equals(newH, StringComparison.InvariantCultureIgnoreCase)))
                                            {
                                                // If found, move the location back a space, this is so the new column can be added correctly, 
                                                // decrement the number of different columns as it's in the imported list and state that it's been 
                                                // found
                                                headerLocation--;
                                                differentColumns--;
                                                found = true;

                                                DataGridViewColumn tempCol = this.VotesGridView.Columns[i]; // Copy of the matching column

                                                List<string> data = new List<string>(); // Holds cell values

                                                // Adds the columns' cell value to the list
                                                for (int j = 0; j < this.VotesGridView.RowCount - 1; j++)
                                                {
                                                    data.Add(this.VotesGridView.Rows[j].Cells[i].Value.ToString());
                                                }

                                                // Removes then re-inserts the column in the right spot
                                                this.VotesGridView.Columns.Remove(this.VotesGridView.Columns[i]);
                                                this.VotesGridView.Columns.Add(tempCol.Name, tempCol.Name);

                                                int rowCount = 0;   // Holds the current row

                                                // Puts on the values back in the cell
                                                foreach (string str in data)
                                                {
                                                    this.VotesGridView[headerLocation, rowCount].Value = str;
                                                    rowCount++;
                                                }

                                                break;
                                            }
                                        }

                                        // If the column doesn't already exist, just add the column
                                        if (!found)
                                        {
                                            VotesGridView.Columns.Add(newH, newH);
                                        }

                                        // Moves the headerLocation forward so any exisiting candidates are added in the right spot
                                        headerLocation++;
                                    }

                                    // Done with the headers
                                    first = false;
                                }

                                // Adding in the data for the candidates
                                else
                                {
                                    string[] voteInfo = line.Split(',');    // Splits the line into individual data bits

                                    // Check for pre-existing columns. This is so that any existing data in the dataGridView is copied
                                    if (numColumns > 0)
                                    {
                                        // While there are rows to copy data for
                                        while (rowNumber < numRows - 1)
                                        {
                                            List<string> voteList = new List<string>(); // Holds list of all cell values for a row

                                            // For each of the columns
                                            for (int j = 0; j < this.VotesGridView.Columns.Count; j++)
                                            {
                                                // If the cell contains stuff
                                                if (this.VotesGridView.Rows[rowNumber].Cells[j].Value != null)
                                                {
                                                    // Adds the pre-existing cell values for a row to an array
                                                    voteList.Add(this.VotesGridView.Rows[rowNumber].Cells[j].Value.ToString());
                                                }
                                                // If it doesn't just fill it with nothing- 
                                                // if this isn't edited then it will be counted as an invalid vote anyways 
                                                // as no data for this vote exists
                                                else
                                                {
                                                    voteList.Add("");
                                                }
                                            }

                                            // Makes it an array so that it can be added as the row
                                            string[] existingRow = voteList.ToArray();

                                            // Add the row and remove the old row by clearing it
                                            if (this.VotesGridView.Rows.Count == 1 && differentColumns == 0)
                                            {
                                                this.VotesGridView.Rows.Clear();
                                                this.VotesGridView.Rows.Add(existingRow);
                                            }

                                            // Add the row and remove the old row
                                            else
                                            {
                                                this.VotesGridView.Rows.RemoveAt(rowNumber);
                                                this.VotesGridView.Rows.Insert(rowNumber, existingRow);
                                            }
                                            rowNumber++;
                                        }

                                        // Imported data
                                        List<string> newVoteList = new List<string>(); // Holds list of all cell values for a row

                                        // Goes through the number of different columns to add nothing similar to above
                                        for (int j = 0; j < differentColumns; j++)
                                        {
                                            newVoteList.Add("");
                                        }

                                        // Adds each of the imported cell values
                                        foreach (string str in voteInfo)
                                        {
                                            newVoteList.Add(str);
                                        }

                                        // Makes it an array so that it can be added as the row
                                        string[] finalRow = newVoteList.ToArray();
                                        this.VotesGridView.Rows.Add(finalRow);
                                    }

                                    // If there isn't any existing columns, just add the data
                                    else
                                    {
                                        VotesGridView.Rows.Add(voteInfo);
                                    }
                                }
                            }

                            // Checks for errors
                        }
                        catch (ArgumentNullException)
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
            catch (Exception)
            {
                MessageBox.Show("Error: Not correct type of file");
            }
        }

        private void ExportCSVButton_Click(object sender, EventArgs e)
        {
            // Checks if there's anything to export
            if (candidates.Count > 0)
            {
                // Tries to export
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();   // Creates a dialog to ask the user where the file is to be saved
                    saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";      // Can only use csv files
                    saveFileDialog.DefaultExt = "csv";                      // Sets the default extension
                    saveFileDialog.AddExtension = true;                     // Adds the extension

                    // Checks if the user didn't press cancel
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder csv = new StringBuilder();    // Contains the StringBuilder of the information for the csv

                        // Column headings
                        csv.Append("Round, ");

                        candidates = new List<string>();    // Holds the candidates

                        // Adds the candidates
                        foreach (DataGridViewColumn col in this.VotesGridView.Columns)
                        {
                            csv.Append(col.Name + ", ");
                            candidates.Add(col.Name);
                        }

                        // Starting for the rounds
                        csv.AppendLine("");

                        int round = 0;  // Current round number

                        // For each round
                        foreach (Dictionary<string, int> rnd in allVotes.Results.Rounds)
                        {
                            // Increment and add the round
                            round++;
                            csv.Append(round + ", ");

                            int index = 0;  // Current data point

                            // Goes through each vote and adds the corresponding data value
                            foreach (KeyValuePair<string, int> entry in rnd)
                            {
                                // The candidate was knocked out so pad with a 'P'
                                while (candidates[index] != entry.Key)
                                {
                                    csv.Append("P, ");
                                    index++;
                                }

                                // If there's a value to add
                                if (candidates[index] == entry.Key)
                                {
                                    csv.Append(entry.Value + ", ");
                                }

                                index++;
                            }

                            // Pads the end if there's no more vote to count, this means the candidate was knocked out
                            while (index < candidates.Count)
                            {
                                csv.Append("P, ");
                                index++;
                            }

                            // New line
                            csv.AppendLine("");
                        }

                        // Writes to the csv and informs the user
                        File.WriteAllText(saveFileDialog.FileName, csv.ToString());
                        MessageBox.Show("CSV saved successfully");
                    }
                }
                // Any problems with writing to the csv
                catch (Exception ex)
                {
                    MessageBox.Show("Error when saving to csv. " + ex.Message);
                }
            }

            // If there was nothing to export
            else
            {
                MessageBox.Show("Error", "No results to export");
            }
        }
        #endregion

        #region Counting/Resetting
        /// <summary>
        /// Gets the result and displays these results to the user
        /// </summary>
        /// <param name="sender">The handle to the button</param>
        /// <param name="e">The extra messages</param>
        private void CountVotesButton_Click(object sender, EventArgs e)
        {
            // Make sure there's data to calculate
            if (this.VotesGridView.Columns.Count > 1)
            {
                // Reset the lists to remove any existing data
                allVotes = new VotesList();
                candidates = new List<string>();

                // Goes through and adds the candidates
                foreach (DataGridViewColumn col in this.VotesGridView.Columns)
                {
                    candidates.Add(col.Name);
                }

                // Goes through and adds the votes
                for (int i = 0; i < VotesGridView.Rows.Count - 1; i++)
                {
                    Vote vote = new Vote(); // Holds the current vote

                    // Goes through each cell and matches the candidate with the vote
                    foreach (DataGridViewCell cell in VotesGridView.Rows[i].Cells)
                    {
                        // If the cell is empty, then add a -1, this is important for counting invalid votes 
                        if (cell.Value == null)
                        {
                            vote.Add(VotesGridView.Columns[cell.ColumnIndex].Name, -1);
                        }
                        else
                        {
                            int n;

                            // Checks for bad input
                            if (int.TryParse(cell.Value.ToString(), out n))
                            {

                                vote.Add(VotesGridView.Columns[cell.ColumnIndex].Name, n);
                            }

                            // If there's bad input 
                            else
                            {
                                MessageBox.Show("Value must be a number");
                                return;
                            }
                        }
                    }

                    // Add the vote
                    allVotes.Add(vote);
                }

                Result finalResult = allVotes.calculateResult(candidates);  // Calculate the result

                // Checks for a result
                if (finalResult != null)
                {
                    // Displays the number of invalid votes
                    this.InvalidVotesLabel.Text = "" + finalResult.NumberOfInvalidVotes;

                    string winnerText = ""; // The text that displays which candidate won the vote

                    // If there's won winner, add the candidate to the string
                    if (finalResult.Winners.Count == 1)
                    {
                        winnerText = finalResult.Winners[0];
                    }
                    
                    // If there's a tie, add each candidate to the string with corresponding English grammar
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

                    // Display the winner(s) and the chart
                    WinnerLabel.Text = winnerText;
                    Chart chart = new Chart(finalResult);
                    chart.ShowDialog();
                }
            }

            // If there isn't enough candidates
            else
            {
                MessageBox.Show("Must have at least 2 candidates", "Error");
            }
        }

        /// <summary>
        /// Resests the data and page
        /// </summary>
        /// <param name="sender">The handle to the button</param>
        /// <param name="e">The extra messages</param>
        private void ResetVoteButton_Click(object sender, EventArgs e)
        {
            this.VotesGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            // Clears the columns, lists and labels
            this.VotesGridView.Columns.Clear();
            allVotes = new VotesList();
            candidates = new List<string>();
            WinnerLabel.Text = "None";
            InvalidVotesLabel.Text = "0";
        }
        #endregion

        #endregion

        #region dataGridView
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
        #endregion
    }
}
