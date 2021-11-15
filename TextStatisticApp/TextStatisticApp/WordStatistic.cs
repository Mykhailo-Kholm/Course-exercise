using System.Collections.Generic;

namespace TextStatisticApp
{
    class WordStatistic
    {
        public int Counter { get; set; }

        public List<Position> WordPositions = new List<Position>();
        public WordStatistic(int counter, int line, int posInLine)
        {
            Counter = counter;
            WordPositions.Add(new Position()
            {
                LineNumber = line,
                PositionInLine = posInLine
            });
        }
    }
}
