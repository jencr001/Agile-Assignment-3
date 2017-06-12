using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreferentialVoting.Classes
{
    class Result
    {
        private Dictionary<string, int> results = new Dictionary<string, int>();
        private List<string> winners;

        public List<string> Winners
        {
            get {
                List<string> returnValue = new List<string>();
                int highestValue = results.Values.Max();
                foreach (KeyValuePair<string, int> entry in results)
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

       

        public Dictionary<string, int> Results
        {
            get { return results; }
            set { results = value; }
        }




        public Result() { }

    }
}
