using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/**
 * 
 * Program.cs
 * DataStructureBasic
 * 
 * IS403
 * Section 2 Group 3
 * 
 * Created by Jaden Feddock on 9/19/16.
 * Copyright © 2016 XLR8 Development LLC. All rights reserved.
 * 
 * 
 **/

namespace DataStructureBasic
{
    class Program
    {
        // Start new Random Number
        public static Random random = new Random();

        // Set global contants, how many customers are in the line? How much padding on the result?
        public const int CUSTOMERS = 100;
        public const int PAD = 30;

        // Returns a string with a random name selected from the list of names in the String array
        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        // Returns a random number within the range
        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }

        static void Main(string[] args)
        {
            // Create new Queue and Dictionary
            Queue<String> list = new Queue<String>();
            Dictionary<String, int> dict = new Dictionary<string,int>();

            // MARK: Input Data

            // Add customers to the queue 'line'
            for (int i=0; i<CUSTOMERS; i++)
            {
                list.Enqueue(randomName());
            }

            // For every customer in the list, add them to the dictionary (if they already exist, increment their value)
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

            // MARK: Print Data

            // Print all of the data in the dictionary.
            foreach (KeyValuePair<String, int> cust in dict)
            {
                Console.WriteLine(cust.Key.PadRight(PAD, ' ') + cust.Value);
            }

            Console.ReadLine();
        }
    }
}
