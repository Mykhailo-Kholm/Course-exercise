using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Channels;

namespace TextStatisticApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, WordStatistic> wordsInfo = new Dictionary<string, WordStatistic>();
            string fileName = Console.ReadLine();

            //read data and get statistics

            // Stopwatch sw = new Stopwatch();
            // sw.Start();
            DataWorker.GetWordsIhfo(fileName, wordsInfo);
                
            //Output all info
            var orderWordsInfo = wordsInfo.OrderByDescending(w => w.Value.Counter);
            foreach (var word in orderWordsInfo)
            {
                Console.WriteLine($"{word.Key}      {word.Value.Counter}");
            }
            // sw.Stop();
            // TimeSpan ts = sw.Elapsed;
            // Console.WriteLine(ts.TotalSeconds);

            // find word position
            DataWorker.FindPositionOfWord(wordsInfo);
        }
    }
}
