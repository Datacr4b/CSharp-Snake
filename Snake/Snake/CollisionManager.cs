using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class CollisionManager
    {
        public List<Snake> Pieces = new List<Snake>();
        public Snake Player;
        public Apple Apple;

        Buffer _buffer;
        Random _rnd = new Random();

        public CollisionManager(Snake player, Apple apple, Buffer buffer)
        {
            Player = player;
            Apple = apple;

            _buffer = buffer;

            Pieces.Add(player);
        }

        public void Update()
        {
            Pieces.Insert(0, new Snake(Player.Move(_buffer)));
            HandleCollision();
        }

        private void HandleCollision()
        {
            // If player hits apple, new apple is created, old one destroyed
            // The tail is removed unless player eats an apple
            
            if (Pieces[0].Position == Apple.Position)
            {
                Player.Score += 1;
                Apple.Position = (_rnd.Next(1,_buffer.Width-1),_rnd.Next(1,_buffer.Height-1));
            }
            else
            {
                Pieces.RemoveAt(Pieces.Count - 1);
            }

            for (int i = 1; i < Pieces.Count; i++)
            {
                if (Pieces[i].Position == Pieces[0].Position)
                {
                    Player.HitWallOrTail = true;
                }
            }
        }
    }
}
