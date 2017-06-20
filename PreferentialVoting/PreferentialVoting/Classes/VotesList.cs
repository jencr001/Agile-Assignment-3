using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PreferentialVoting.Classes
{

    /// <summary>
    /// Class that holds the votes as a list
    /// </summary>
    class VotesList : List<Vote>
    {
     //   private Dictionary<string, int> results = new Dictionary<string, int>();
        private List<string> candidates;
        private int majority;
        private int numberOfVotes;
        private int numberOfInvalidVotes;
        private Result results = new Result();

        public List<string> Candidates
        {
            get { return candidates; }
            set { candidates = value; }
        }

        public Result Results
        {
            get { return results; }
            set { results = value; }
        }

        /*  public VotesList(VotesList other)
          {
              this.results = other.results;
              this.candidates = other.candidates;
              this.majority = other.majority;
              this.numberOfInvalidVotes = other.numberOfInvalidVotes;
              this.numberOfVotes = other.numberOfVotes;
          }*/
        public VotesList() { }

        public Result calculateResult(List<string> _candidates)
        {
            // Gets the candidate name and number of votes
            candidates = _candidates;
            numberOfVotes = this.Count;
            //works out what the majority is
            majority = numberOfVotes / 2 + 1;
            numberOfInvalidVotes = 0;
            bool finalTie = false;
            //sets up the final results
            foreach (string candidate in candidates)
            {
                results.FinalResults.Add(candidate, 0);
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].checkIfInvalidVote(candidates))
                {
                    numberOfVotes--;
                    majority = numberOfVotes / 2 + 1;
                    numberOfInvalidVotes++;
                    this.Remove(this[i]);
                   
                }
            }
            results.NumberOfInvalidVotes = numberOfInvalidVotes;

            if (numberOfInvalidVotes < this.Count)
            {

                int highestResult = 0;

                calculateRound();
                highestResult = results.FinalResults.Values.Max();

                while (highestResult < (majority))
                {
                    int lowestResult = results.FinalResults.Values.Min();
                    List<string> losers = new List<string>();
                    foreach (KeyValuePair<string, int> result in results.FinalResults)
                    {
                        if (result.Value == lowestResult)
                        {
                            losers.Add(result.Key);
                        }

                    }
                    Random rnd = new Random();
                    int index = rnd.Next(losers.Count);
                    foreach (Vote vote in this)
                    {
                        vote.redistrbuteCandidate(losers[index]);
                    }
                    candidates.Remove(losers[index]);
                    results.FinalResults.Remove(losers[index]);


                    calculateRound();
                    highestResult = results.FinalResults.Values.Max();
                    if (candidates.Count == 2 && (results.FinalResults.Values.Min() == results.FinalResults.Values.Max()))
                    {
                        finalTie = true;
                        break;
                    }
                }

                // Get result
                String asString = string.Join(";", results);
                Console.WriteLine(asString);
               
                return results;
            }

            else
            {
                MessageBox.Show("None of the votes were valid!", "Error");
                return null;
            }

        }

        private void calculateRound()
        {
            results.FinalResults.Clear();
            foreach (string candidate in candidates)
            {
                results.FinalResults.Add(candidate, 0);
            }
            for (int i = 0; i < this.Count; i++)
            {
                {
                        foreach (KeyValuePair<string, int> entry in this[i])
                        {
                            if (entry.Value == this[i].CurrentPreferenceNumber)
                            {
                                results.FinalResults[entry.Key]++;
                            }
                        }
                    }
                
            }
            Dictionary<string, int> tmp = new Dictionary<string, int>(results.FinalResults);
         
            results.Rounds.Add(tmp);
        }
    }
}
