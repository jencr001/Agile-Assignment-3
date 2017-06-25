using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreferentialVoting.Classes
{
    /// <summary>
    /// Class that stores the result of the vote count
    /// </summary>
    public class Result
    {
        private Dictionary<string, int> finalResults = new Dictionary<string, int>();           // Holds the final score results
        private List<string> winners;                                                           // Holds the string of the winners
        private List<Dictionary<string, int>> rounds = new List<Dictionary<string, int>>();     // Holds the results of each round       
        private int numberOfInvalidVotes = 0;                                                   // Holds the number of invalid votes

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Result() { }
        #endregion

        #region Getters and Setters
        // Getters and Setters
        public Dictionary<string, int> FinalResults
        {
            get { return finalResults; }
            set { finalResults = value; }
        }

        public List<string> Winners
        {
            get
            {
                List<string> returnValue = new List<string>();  // The winning candidate(s)
                int highestValue = finalResults.Values.Max();   // The final vote of the winning candidate(s)

                // Goes through each of the final results and checks if they had the highest vote meaning they are a winner
                // and then adds it to the list of winners
                foreach (KeyValuePair<string, int> entry in finalResults)
                {
                    if (highestValue == entry.Value)
                    {
                        returnValue.Add(entry.Key);
                    }
                }
                return returnValue;
            }
            set { winners = value; }
        }

        public List<Dictionary<string, int>> Rounds
        {
            get { return rounds; }
            set { rounds = value; }
        }

        public int NumberOfInvalidVotes
        {
            get { return numberOfInvalidVotes; }
            set { numberOfInvalidVotes = value; }
        }
        #endregion
    }     
}
