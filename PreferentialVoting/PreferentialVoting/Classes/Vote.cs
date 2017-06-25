using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreferentialVoting.Classes
{
    /// <summary>
    /// Class that for one vote 
    /// </summary>
    class Vote : Dictionary<string, int>
    {
        private int currentPreferenceNumber;    // The current preference number for the vote
        private string currentCandidate;        // The current selected candidate for the vote

        #region Constructors
        // Default Constructor that sets the current preference number as 1
        public Vote()
        {
            currentPreferenceNumber = 1;
        }

        // Copy Constructor
        public Vote(Vote other)
        {
            this.currentCandidate = other.CurrentCandidate;
            this.currentPreferenceNumber = other.CurrentPreferenceNumber;
        }
        #endregion

        #region Getters and Setters
        // Getters and Setters
        public int CurrentPreferenceNumber
        {
            get { return currentPreferenceNumber; }
            set { currentPreferenceNumber = value; }
        }
        
        public string CurrentCandidate
        {
            get { return currentCandidate; }
            set { currentCandidate = value; }
        }
        #endregion

        #region Vote and Candidate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidates">The list of candidates</param>
        /// <returns>If the vote is invalid</returns>
        public bool checkIfInvalidVote(List<string> candidates)
        {
            List<int> numbers = new List<int>();

            for (int i = 1; i <= candidates.Count; i++)
            {
                numbers.Add(i);
            }

            foreach (KeyValuePair<string, int> entry in this)
            {
                if (!candidates.Contains(entry.Key)) return true;

                if (numbers.Contains(entry.Value))
                {
                    numbers.Remove(entry.Value);
                }
                else return true;
            }

            if (numbers.Count > 0) return true;

            return false;
        }

        /// <summary>
        /// Redistributes the lowest candidate's votes
        /// </summary>
        /// <param name="candidate">The removed candidate</param>
        public void redistrbuteCandidate(string candidate)
        {
            int candidatePreferenceNumber = 0;  // The candidate preference number  

            // Gets the candidate's preference number based on the candidate
            if (this.TryGetValue(candidate, out candidatePreferenceNumber))
            {
                // Checks if the numbers match, if they do increment the current preference number 
                // while it still is contained in the values,
                // then remove the candidate
                if (candidatePreferenceNumber == currentPreferenceNumber)
                {
                    do
                    {
                        currentPreferenceNumber++;
                    } while (!this.Values.Contains(currentPreferenceNumber));

                }
                this.Remove(candidate);
            }
        }
        #endregion
    }
}

