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
        private List<string> candidates;        // Hold a list of the candidates
        private int majority;                   // The number needed to win the vote
        private int numberOfVotes;              // The total number of votes
        private int numberOfInvalidVotes;       // The number of invalid votes
        private Result results = new Result();  // An instance of the results of the vote

        #region Constructor/Getters/Setters
        /// <summary>
        /// Constructor
        /// </summary>
        public VotesList() { }

        // Getters and Setters
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
        #endregion

        #region Calcuation
        /// <summary>
        /// Calculates the result of the vote
        /// </summary>
        /// <param name="_candidates">A list of the candidates</param>
        /// <returns>Returns the results of the vote</returns>
        public Result calculateResult(List<string> _candidates)
        {
            // Gets the candidate name and number of votes
            candidates = _candidates;
            numberOfVotes = this.Count;

            // Works out what the majority is
            majority = numberOfVotes / 2 + 1;
            numberOfInvalidVotes = 0;

            bool finalTie = false;  // Whether it's a tie

            // Sets up the final results
            foreach (string candidate in candidates)
            {
                results.FinalResults.Add(candidate, 0);
            }

            // Gets the number of invalid results
            for (int i = 0; i < this.Count; i++)
            {
                // If it's invalid, decrease the number of votes that are being counted, adjust the majority, increase the number of votes, 
                // and remove the vote
                if (this[i].checkIfInvalidVote(candidates))
                {
                    numberOfVotes--;
                    majority = numberOfVotes / 2 + 1;
                    numberOfInvalidVotes++;
                    this.Remove(this[i]);
                }
            }

            // Sets the number of invalid votes
            results.NumberOfInvalidVotes = numberOfInvalidVotes;

            // Checks if there is enough valid votes to make the count
            if (numberOfInvalidVotes < this.Count)
            {
                int highestResult = 0;  // Stores the highest candidate's vote

                // Calculates the round and stores the max
                calculateRound();
                highestResult = results.FinalResults.Values.Max();

                // While there is no winner
                while (highestResult < (majority))
                {
                    int lowestResult = results.FinalResults.Values.Min();   // Stores the lowest candidate's vote
                    List<string> losers = new List<string>();               // Stores the list of candidates that have the lowest votes

                    // Goes through each result and checks if it's the lowest, if it is- add to the losers list
                    foreach (KeyValuePair<string, int> result in results.FinalResults)
                    {
                        if (result.Value == lowestResult)
                        {
                            losers.Add(result.Key);
                        }
                    }

                    // Randomly selects a candidate with the lowest score to be eliminated
                    Random rnd = new Random();  // A new random number
                    int index = rnd.Next(losers.Count);

                    // Finds and removes the selected candidate
                    foreach (Vote vote in this)
                    {
                        vote.redistrbuteCandidate(losers[index]);
                    }
                    candidates.Remove(losers[index]);
                    results.FinalResults.Remove(losers[index]);

                    // Calculates the round and stores the max
                    calculateRound();
                    highestResult = results.FinalResults.Values.Max();

                    // Checks if the final result is a tie 
                    if (candidates.Count == 2 && (results.FinalResults.Values.Min() == results.FinalResults.Values.Max()))
                    {
                        finalTie = true;
                        break;
                    }
                }

                // Get result and return
                String asString = string.Join(";", results);
                return results;
            }

            // If none of the results are valid
            else
            {
                MessageBox.Show("None of the votes were valid!", "Error");
                return null;
            }
        }

        /// <summary>
        /// Calculates each round
        /// </summary>
        private void calculateRound()
        {
            // Clears the previous round's results
            results.FinalResults.Clear();

            // Adds the candidate's for the current round
            foreach (string candidate in candidates)
            {
                results.FinalResults.Add(candidate, 0);
            }

            // Goes through each of the votes
            for (int i = 0; i < this.Count; i++)
            {
                // Checks if the preference is the same as the entry to determine which vote to add, 
                // then increase the number of votes for the candidate
                foreach (KeyValuePair<string, int> entry in this[i])
                {
                    if (entry.Value == this[i].CurrentPreferenceNumber)
                    {
                        results.FinalResults[entry.Key]++;
                    }
                }
            }

            Dictionary<string, int> tmp = new Dictionary<string, int>(results.FinalResults);    // Holds the new result

            // Adds the round to the results
            results.Rounds.Add(tmp);
        }
        #endregion
    }
}
