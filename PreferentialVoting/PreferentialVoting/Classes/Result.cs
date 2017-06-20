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


        private Dictionary<string, int> finalResults = new Dictionary<string, int>();
        private List<string> winners;
        private List<Dictionary<string, int>> rounds = new List<Dictionary<string, int>>();
        private int numberOfInvalidVotes = 0;

        public int NumberOfInvalidVotes
        {
            get { return numberOfInvalidVotes; }
            set { numberOfInvalidVotes = value; }
        } 

        public List<Dictionary<string, int>> Rounds
        {
            get { return rounds; }
            set { rounds = value; }
        }

        public List<string> Winners
        {
            get {
                List<string> returnValue = new List<string>();
                int highestValue = finalResults.Values.Max();
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



       

        public Dictionary<string, int> FinalResults
        {
            get { return finalResults; }
            set { finalResults = value; }
        }




        public Result() { }

    }
}
