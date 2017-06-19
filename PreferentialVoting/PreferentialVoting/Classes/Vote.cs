using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreferentialVoting.Classes
{
    /// <summary>
    /// Class that one vote 
    /// </summary>
    class Vote : Dictionary<string, int>
    {
        private int currentPreferenceNumber;

        public int CurrentPreferenceNumber
        {
            get { return currentPreferenceNumber; }
            set { currentPreferenceNumber = value; }
        }
        private string currentCandidate;

        public string CurrentCandidate
        {
            get { return currentCandidate; }
            set { currentCandidate = value; }
        }
        public Vote()
        {
            currentPreferenceNumber = 1;
        }

        public Vote(Vote other)
        {
            this.currentCandidate = other.CurrentCandidate;
            this.currentPreferenceNumber = other.CurrentPreferenceNumber;

        }

        public bool checkIfInvalidVote(List<string> candidates)
        {
            List<int> numbers = new List<int>();

            for (int i = 1; i <= candidates.Count; i++)
            {
                numbers.Add(i);
            }

            foreach (KeyValuePair<string, int> entry in this)
            {
                // do something with entry.Value or entry.Key
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

        public void redistrbuteCandidate(string candidate)
        {
            int candidatePreferenceNumber = 0;
            if (this.TryGetValue(candidate, out candidatePreferenceNumber))
            {
                if (candidatePreferenceNumber == currentPreferenceNumber)
                {
                    do
                    {
                        currentPreferenceNumber++;
                    } while (!this.Values.Contains(candidatePreferenceNumber));
                }
                this.Remove(candidate);
            }
        }
    }
}

