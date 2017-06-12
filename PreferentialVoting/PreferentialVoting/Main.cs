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
    public partial class Main : Form
    {
        private Dictionary<string, int> vote;
        private List<Dictionary<string, int>> allVotes;
        private List<string> candidates;
        public Main()
        {
            InitializeComponent();
            vote = new Dictionary<string, int>();
            allVotes = new List<Dictionary<string, int>>();
            candidates = new List<string>();
            candidates.Add("Chocolate");
            candidates.Add("Ice-Cream");
            candidates.Add("Chips");

            vote.Add("Ice-Cream", 3);
            vote.Add("Chocolate", 1);
            
            vote.Add("Chips", 2);
            allVotes.Add(vote);
            foreach (string c in candidates) {
                dataGridView1.Columns.Add(c, c);
            }
            foreach (Dictionary<string, int> v in allVotes)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
   
                foreach(KeyValuePair<string, int> entry in v) {
                    row.Cells[candidates.IndexOf(entry.Key)].Value = entry.Value;
                 
                }
                dataGridView1.Rows.Add(row);
            }

        }
    }
}
