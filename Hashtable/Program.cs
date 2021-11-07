using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string sentence = "To be or not to be";
            CountWordFrequency(sentence );
            Console.ReadLine();
        }
        public static void CountWordFrequency(string sentence)
        {
            MyHashCode<string, int> hashtable = new MyHashCode<string, int>(6);
            string[] words = sentence.Split(' ');
            foreach (string word in words)
            {
                if (hashtable.Exists(word))
                {
                    hashtable.Add(word, hashtable.get(word) + 1);

                }
                else
                {
                    hashtable.Add(word, 1);
                }
            }
            Console.WriteLine("Displaying after add operations");
            hashtable.Display();
            Console.WriteLine("=======================================");
        }
    }
}
