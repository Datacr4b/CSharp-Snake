using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Render
    {
        Buffer _buffer;
        CollisionManager _manager;
        public Render(Buffer buffer, CollisionManager manager)
        {
            _buffer = buffer;
            _manager = manager;
        }

        public void DrawChar((int x, int y) position, ConsoleChar character)
        {
            _buffer.ConsoleBuffer[position.y][position.x] = character;
        }

        public void DrawOverlay()
        {
            for (int y = 0; y < _buffer.Height; y++)
            {
                for (int x = 0; x < _buffer.Width; x++) 
                {
                    if (y == 0 || y == _buffer.Height-1)
                        _buffer.ConsoleBuffer[y][x] = new ConsoleChar('▓');
                    else
                    {
                        _buffer.ConsoleBuffer[y][0] = new ConsoleChar('▓');
                        _buffer.ConsoleBuffer[y][_buffer.Width-1] = new ConsoleChar('▓');
                    }
                }
            }
        }

        public void DrawEntities()
        {
            int index = 0;
            DrawChar(_manager.Apple.Position, _manager.Apple.Icon);
            foreach(var p in _manager.Pieces)
            {
                if (index == 0)
                    DrawChar(p.Position, new ConsoleChar(p.Icon.Character, ConsoleColor.Green, ConsoleColor.Green));
                else
                    DrawChar(p.Position, p.Icon);
                index++;
            }
        }
    }
}
