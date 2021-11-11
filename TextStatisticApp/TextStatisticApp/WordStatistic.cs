using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
