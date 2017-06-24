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
        }



        private void ImportCSVButton_Click(object sender, EventArgs e)
        {

            // Stupid fix
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
                        List<string> lines = new List<string>();
                        try
                        {

                            StreamReader sr = new StreamReader(stream);
                            string l;
                            // read data in line by line
                            while ((l = sr.ReadLine()) != null)
                            {
                                lines.Add(l);

                            }
                            sr.Close();
                            // Result of the stream

                            int numColumns = this.VotesGridView.Columns.Count;
                            int oldRows = this.VotesGridView.Rows.Count;
                            int differentColumns = this.VotesGridView.Columns.Count;


                            bool first = true;
                            string[] headers;
                            int rowNumber = 0;

                            foreach (string line in lines)
                            {
                                if (first)
                                {
                                    string newLine = line.Replace('"', ' ').Trim();
                                    headers = newLine.Split(',');

                                    int headerLocation = this.VotesGridView.Columns.Count;

                                    foreach (string h in headers)
                                    {
                                        List<char> result = h.ToList();
                                        result.RemoveAll(c => c == ' ');
                                        string newH = new string(result.ToArray());

                                        bool found = false;

                                        for (int i = 0; i < VotesGridView.Columns.Count; i++)
                                        {
                                            if ((VotesGridView.Columns[i].Name.Equals(newH, StringComparison.InvariantCultureIgnoreCase)))
                                            {
                                                headerLocation--;
                                                differentColumns--;
                                                found = true;
                                                //numColumns--;
                                                DataGridViewColumn tempCol = this.VotesGridView.Columns[i]; // Copy of the matching column

                                                List<string> data = new List<string>(); // Holds cell values

                                                // Adds the columns' cell value to the list
                                                for (int j = 0; j < this.VotesGridView.RowCount - 1; j++)
                                                {
                                                    data.Add(this.VotesGridView.Rows[j].Cells[i].Value.ToString());
                                                }
                                                
                                                // Removes then re-inserts the column in the right spot
                                                this.VotesGridView.Columns.Remove(this.VotesGridView.Columns[i]);
                                               // this.VotesGridView.Columns.Insert(headerLocation, tempCol);
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
                                        if (!found)
                                        {
                                            VotesGridView.Columns.Add(newH, newH);
                                        }

                                        headerLocation++;
                                    }
                                    first = false;

                                }

                                else
                                {
                                    
                                    string[] voteInfo = line.Split(',');

                                    if (numColumns > 0)
                                    {
                                        

                                        //  for (int i = 0; i < numColumns; i++)
                                        // {
                                        
                                       
                                        while (rowNumber < oldRows - 1)
                                        {
                                            
                                            List<string> voteList = new List<string>(); // Holds list of all cell values for a row
                                            for (int j = 0; j < this.VotesGridView.Columns.Count; j++)
                                            {
                                                
                                                if (this.VotesGridView.Rows[rowNumber].Cells[j].Value != null)
                                                {
                                                    // Adds the pre-existing cell values for a row
                                                    voteList.Add(this.VotesGridView.Rows[rowNumber].Cells[j].Value.ToString());
                                                }
                                                else
                                                {
                                                    voteList.Add("");
                                                }

                                                // Adds each of the imported cell values
                                                // foreach (string str in voteInfo)
                                                //{
                                                //  voteList.Add(str);
                                                //}
                                            }

                                            
                                            // Makes it an array so that it can be added as the row
                                            string[] existingRow = voteList.ToArray();


                                            if (this.VotesGridView.Rows.Count == 1 && differentColumns == 0)
                                            {
                                                Console.WriteLine("Weird Error");
                                                this.VotesGridView.Rows.Clear();
                                                this.VotesGridView.Rows.Add(existingRow);
                                                //this.VotesGridView.Rows.RemoveAt(rowNumber);
                                            }
                                            else
                                            {
                                                this.VotesGridView.Rows.RemoveAt(rowNumber);
                                                this.VotesGridView.Rows.Insert(rowNumber, existingRow);
                                            }
                                            
                                            rowNumber++;
                                            

                                        }
                                        
                                        List<string> newVoteList = new List<string>(); // Holds list of all cell values for a row
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

                                        // }
                                    }
                                    else
                                    {
                                        VotesGridView.Rows.Add(voteInfo);
                                    }
                                    DataGridViewRow dataRow = new DataGridViewRow();


                                }
                            }

                            // Checks for errors
                        }
                        catch (ArgumentNullException ex)
                        {
                            MessageBox.Show("Error: File can't be accessed");
                            MessageBox.Show(ex.Message);

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


                if (finalResult != null)
                {
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

        }

        private void ExportCSVButton_Click(object sender, EventArgs e)
        {
            if (candidates.Count > 0)
            {

                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();   // Creates a dialog to ask the user where the file is to be saved
                    saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";      // Can only use csv files
                    saveFileDialog.DefaultExt = "csv";
                    saveFileDialog.AddExtension = true;

                    // Checks if the user didn't press cancel
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder csv = new StringBuilder();    // Contains the StringBuilder of the information for the csv

                        // Column headings
                        csv.Append("Round, ");


                        candidates = new List<string>();

                        foreach (DataGridViewColumn col in this.VotesGridView.Columns)
                        {
                            csv.Append(col.Name + ", ");
                            candidates.Add(col.Name);
                        }

                        csv.AppendLine("");
                        int round = 0;

                        foreach (Dictionary<string, int> rnd in allVotes.Results.Rounds)
                        {
                            round++;
                            csv.Append(round + ", ");

                            int index = 0;
                            Console.WriteLine("Round Count: " + rnd.Count);

                            foreach (KeyValuePair<string, int> entry in rnd)
                            {

                                while (candidates[index] != entry.Key)
                                {
                                    csv.Append("P, ");
                                    index++;
                                }
                                if (candidates[index] == entry.Key)
                                {
                                    csv.Append(entry.Value + ", ");
                                }


                                index++;
                            }

                            Console.WriteLine("Index: " + index);
                            Console.WriteLine("Cs: " + candidates.Count);
                            while (index < candidates.Count)
                            {
                                csv.Append("P, ");
                                index++;
                            }



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

            else
            {
                MessageBox.Show("Error", "No results to export");
            }
        }

    }
}
