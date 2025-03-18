using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DexstorAndPackmaen
{
    public class Game
    {
        private Scena _scena;
        private Player _player;

        private int _countBal;

        public Game() 
        {
            _scena = new Scena("map.txt");
            _player = new Player(new Vecktor(1, 1), '@', _scena);
            _countBal = 0;
        }

        public void Start()
        {
            char[,] map;

            Task.Run(() => 
            {
                while (_player.IsLive)
                {
                    _player.Controle();
                }
            });
            
            while (_player.IsLive)
            {
                map = _scena.GetMap();

                _player.Updete();
                
                if(_scena.IsIAteIt(_player))
                    _countBal++;

                Console.Clear();

                _scena.Draw();

                Console.WriteLine($"Количество очков {_countBal}");

                _player.Draw();

                Thread.Sleep(500);
            }     
        }
    }
}
