using System;
using System.Collections.Generic;
using System.Linq;

namespace TextStatisticApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsInfo = new Dictionary<string, WordStatistic>();

            Console.WriteLine("Enter path to the file:");
            var fileName = Console.ReadLine();

            //read data and get statistics
            DataWorker.GetWordsInfo(fileName, wordsInfo);
                
            //Output all info
            var orderWordsInfo = wordsInfo.OrderByDescending(w => w.Value.Counter);
            foreach (var word in orderWordsInfo)
            {
                Console.WriteLine($"{word.Key} \t {word.Value.Counter}");
            }

            // find word position
            DataWorker.FindPositionOfWord(wordsInfo);
        }
    }
}
