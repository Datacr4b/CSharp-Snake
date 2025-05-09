using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public (int x, int y) Position;
        public ConsoleChar Icon = new ConsoleChar('█');


        public int DirectionX;
        public int DirectionY;
        public int Score = 0;

        public bool HitWallOrTail = false;

        public Snake((int, int) position)
        {
            Position = position;
        }

        public void ChooseDirection(ConsoleKeyInfo? keyInfo)
        {
            DirectionX = 0;
            DirectionY = 0;

            switch (keyInfo.Value.Key)
            {
                case ConsoleKey.W: DirectionY = -1; break;
                case ConsoleKey.S: DirectionY = 1; break;
                case ConsoleKey.D: DirectionX = 1; break;
                case ConsoleKey.A: DirectionX = -1; break;
            }
        }
        public (int, int) Move(Buffer buffer)
        {
            int bufferX = Position.x + DirectionX;
            int bufferY = Position.y + DirectionY;

            if (bufferX > 0 && bufferX < buffer.Width-1 && bufferY >  0 && bufferY < buffer.Height-1)
                return Position = (bufferX, bufferY);
            else
            {
                HitWallOrTail = true;
                return Position;
            }
        }
    }


}
