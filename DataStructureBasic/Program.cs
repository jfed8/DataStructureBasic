using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureBasic
{
    class Program
    {
        public static Random random = new Random();

        public const int CUSTOMERS = 100;
        public const int PAD = 30;

        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }

        static void Main(string[] args)
        {
            Queue<String> list = new Queue<String>();
            Dictionary<String, int> dict = new Dictionary<string,int>();

            for (int i=0; i<CUSTOMERS; i++)
            {
                list.Enqueue(randomName());
            }

            IEnumerator iter = list.GetEnumerator();

            foreach (String name in list)
            {

                if (dict.ContainsKey(name))
                {
                    int old;
                    dict.TryGetValue(name, out old);
                    dict[name] = old + randomNumberInRange();
                }
                else
                {
                    dict.Add(name, randomNumberInRange());
                }
            }

            foreach (KeyValuePair<String, int> cust in dict)
            {
                Console.WriteLine(cust.Key.PadRight(PAD, ' ') + cust.Value);
            }

            Console.ReadLine();
        }
    }
}
