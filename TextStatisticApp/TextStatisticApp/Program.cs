using System;
using System.Collections.Generic;
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
            string fileName = Console.ReadLine();
            string[] separators = {" ", "", ",", "."," - ", "\\", "|", "/", "!", "?", "(", ")", "{", "}", "[", "]", "<", ">", "\'", "\""};
            Dictionary<string, WordStatistic> wordsInfo = new Dictionary<string, WordStatistic>();
            string[] words = null;

            //read data and get statistics
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    int line = 1;
                    while (!sr.EndOfStream)
                    {

                        words = sr.ReadLine().Trim().Split(separators,StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < words.Length; i++)
                        {
                            if (!wordsInfo.ContainsKey(words[i]))
                                wordsInfo.Add(words[i], new WordStatistic(1, line, i+1));
                            else
                            {
                                wordsInfo[words[i]].Counter++;
                                wordsInfo[words[i]].WordPositions.Add(new Position()
                                {
                                    LineNumber = line,
                                    PositionInLine = i
                                });
                            }
                        }

                        line++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Output all info
            try
            {
                foreach (var word in wordsInfo)
                {
                    Console.WriteLine(word.Key + "\t" + word.Value.Counter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            // find word position
            try
            {
                while (true)
                {
                    string MyWord = Console.ReadLine();
                    if (wordsInfo.ContainsKey(MyWord))
                    {
                        foreach (var pos in wordsInfo[MyWord].WordPositions)
                        {
                            Console.WriteLine($"{MyWord} in line {pos.LineNumber} on position: {pos.PositionInLine}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The word is not in the text. Please enter another");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
