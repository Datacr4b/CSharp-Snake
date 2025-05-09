using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace Snake
{
    class Game
    {
        Stopwatch _timer = new Stopwatch();
        Buffer _gameBuffer;
        CollisionManager _collisionManager;
        Display _display;
        Snake _player;
        Apple _apple;

        ConsoleKeyInfo? _keyInfo = new ConsoleKeyInfo?();

        int _tickRate = 60;
        int _windowWidth = 51;
        int _windowHeight = 21;

        public Game()
        {
            _gameBuffer = new Buffer(_windowWidth, _windowHeight);
            _player = new Snake((10,10));
            _apple = new Apple((20, 15));

            _collisionManager = new CollisionManager(_player, _apple, _gameBuffer);
            _display = new Display(_gameBuffer, _collisionManager);

            CursorVisible = false;
            SetWindowSize(_windowWidth, _windowHeight);
            SetBufferSize(_windowWidth, _windowHeight);
        }

        public void MainGame()
        {

            while (true)
            {
                _timer.Start();

                if (KeyAvailable)
                {
                    _keyInfo = ReadKey(true);
                }
                if (_timer.ElapsedMilliseconds >= _tickRate)
                {

                    _display.DisplayGame();
                    _collisionManager.Update();

                    if (_player.HitWallOrTail)
                    {
                        SetCursorPosition(20, 10);
                        Write("YOU LOST");
                        ReadKey();
                        MainGame();
                    }

                    if (_keyInfo != null)
                    {
                        _player.ChooseDirection(_keyInfo);
                    }

                    _timer.Restart();
                    _keyInfo = null;
                }
            }
        }
    }
}
