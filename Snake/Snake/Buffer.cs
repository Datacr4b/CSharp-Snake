using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Buffer
    {
        public List<ConsoleChar[]> ConsoleBuffer = new List<ConsoleChar[]>();
        public int Width;
        public int Height;

        public Buffer(int width, int height) 
        { 
            Width = width;
            Height = height;

            // Create an empty buffer
            for (int y = 0; y < Height; y++)
            {
                ConsoleBuffer.Add(new ConsoleChar[Width]);
                for (int x = 0; x < Width; x++)
                {
                    ConsoleBuffer[y][x] = new ConsoleChar(' ');
                }
            }
        }

        public void ResetBuffer()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    ConsoleBuffer[y][x] = new ConsoleChar(' ');
                }
            }
        }
    }
}
