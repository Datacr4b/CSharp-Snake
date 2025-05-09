using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    struct ConsoleChar
    {
        public char Character;
        public ConsoleColor Background;
        public ConsoleColor Foreground;

        public ConsoleChar(char character, ConsoleColor background = ConsoleColor.Black, ConsoleColor foreground = ConsoleColor.White)
        {
            Character = character;
            Background = background;
            Foreground = foreground;
        }
    }
}
