using System;
using System.Collections.Generic;
using System.IO;

namespace TextStatisticApp
{
    class DataWorker
    {
        public static void GetWordsInfo(string fileName, Dictionary<string,WordStatistic> wordsInfo)
        {
            try
            {
                string[] separators = { " ", "", ",", ".", " - ", "\\", "|", "/", "!", "?", "(", ")", "{", "}", "[", "]", "<", ">", "\"" };
                string[] words = null;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    int line = 1;
                    while (!sr.EndOfStream)
                    {
                        words = sr.ReadLine().Trim().ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < words.Length; i++)
                        {
                            if (!wordsInfo.ContainsKey(words[i]))
                                wordsInfo.Add(words[i], new WordStatistic(1, line, i + 1));
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
        }

        public static void FindPositionOfWord(Dictionary<string, WordStatistic> wordsInfo)
        {
            while (true)
            {
                Console.WriteLine("What word do you want to find?");
                var MyWord = Console.ReadLine();
                if (wordsInfo.ContainsKey(MyWord))
                {
                    foreach (var pos in wordsInfo[MyWord].WordPositions)
                    {
                        Console.WriteLine($"{MyWord} in line {pos.LineNumber} on position: {pos.PositionInLine}");
                    }
                }
                else
                {
                    Console.WriteLine("The word is not in the text. Please, enter another");
                }
            }
        }
    }


}
