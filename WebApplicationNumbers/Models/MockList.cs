using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationNumbers.Models
{

    public class NMockList : List<KeyValuePair<string, int>>
    {
        private int m_Sum = 0;
        private List<int> m_ListOfAllNumbers = null;

        public int Sum()
        {
            return m_Sum;
        }

        public NMockList()
        {
            m_Sum = 0;
            m_ListOfAllNumbers = new List<int>();
        }

        public List<int> Uniques()
        {
            var resList = m_ListOfAllNumbers.Distinct().ToList<int>();

            return resList;
        }

        //
        //
        //
        public void Add(string key, int value)
        {
            var element = new KeyValuePair<string, int>(key, value);
            this.Add(element);

            m_ListOfAllNumbers.Add(value);

            m_Sum += value;
        }

        //
        //
        //
        public int Repetitions()
        {
            Dictionary<int, int> reps = new Dictionary<int, int>();

            for (var i = 0; i < this.Count; i++)
            {
                var num = this[i].Value;

                if (!reps.ContainsKey(num))
                    reps.Add(num, 1);
                else
                    reps[num] = reps[num] + 1;
            }

            return reps.Count;
        }


        public NMockList NumberForUser(string userID)
        {
            var resList = new NMockList();

            for (var i = 0; i < this.Count; i++)
            {
                if (userID == this[i].Key)
                    resList.Add(this[i]);
            }

            return resList;
        }

    }
}