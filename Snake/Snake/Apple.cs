using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Apple
    {
        public (int x, int y) Position;
        public ConsoleChar Icon = new ConsoleChar('@', ConsoleColor.Black, ConsoleColor.Red);

        public Apple((int, int) position)
        {
            Position = position;
        }
    }
}
