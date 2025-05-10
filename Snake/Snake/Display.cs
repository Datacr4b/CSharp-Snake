using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Snake
{
    class Display
    {
        Render _render;
        Buffer _buffer;

        int _width;
        int _height;

        public Display(Buffer buffer, CollisionManager manager)
        {
            _buffer = buffer;
            _render = new Render(buffer, manager);

            _width = buffer.ConsoleBuffer[0].Length;
            _height = buffer.ConsoleBuffer.Count;
        }
        public void DisplayGame(Snake player)
        {
            // Reset buffer
            _buffer.ResetBuffer();

            // Render all the things into buffer
            _render.DrawOverlay();
            _render.DrawEntities();
            _render.DrawText(" Score: " + player.Score + " ", (4, 0));

            // Display it all in one fell swoop
            DisplayBuffer();

        }

        private void DisplayBuffer()
        {
            SetCursorPosition(0, 0);
            ConsoleColor currentForeground = ConsoleColor.White;
            ConsoleColor currentBackground = ConsoleColor.Black;

            for (int y = 0; y < _height; y++)
            {
                StringBuilder row = new StringBuilder();
                for (int x = 0; x < _width; x++)
                {
                    ConsoleChar c = _buffer.ConsoleBuffer[y][x];

                    if (x == _width - 1 || c.Foreground != currentForeground || c.Background != currentBackground)
                    {
                        if (row.Length > 0)
                        {
                            ForegroundColor = currentForeground;
                            BackgroundColor = currentBackground;
                            Write(row.ToString());
                            row.Clear();
                        }
                        currentBackground = c.Background;
                        currentForeground = c.Foreground;
                    }
                    row.Append(c.Character);
                }

                if (row.Length > 0)
                {
                    ForegroundColor = currentForeground;
                    BackgroundColor = currentBackground;
                    Write(row.ToString());
                }

                if (y < _height - 1)
                    Write('\n');
            }
        }
    }
}
