using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PreferentialVoting.Classes;

namespace PreferentialVoting
{
    public partial class Main : Form
    {
        
        private VotesList allVotes;
        private List<string> candidates;
        public Main()
        {
            InitializeComponent();
            
            allVotes = new VotesList();
            candidates = new List<string>();
            VotesGridView.Columns.Add("Chocolate", "Chocolate");
            VotesGridView.Columns.Add("Ice-Cream", "Ice-Cream");
            VotesGridView.Columns.Add("Chips", "Chips");
         
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

        }

        private void CountVotesButton_Click(object sender, EventArgs e)
        {
            allVotes = new VotesList();
            candidates = new List<string>();
            foreach (DataGridViewColumn col in VotesGridView.Columns)
            {
                candidates.Add(col.Name);
            }
            for (int i = 0; i < VotesGridView.Rows.Count - 1; i++)
            {
                Vote vote = new Vote();
                foreach (DataGridViewCell cell in VotesGridView.Rows[i].Cells) 
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
                allVotes.Add(vote);
            }
            VotesList resultVotes = new VotesList(allVotes);
            resultVotes.calculateResult(candidates);
        }

        

       
    }
}
