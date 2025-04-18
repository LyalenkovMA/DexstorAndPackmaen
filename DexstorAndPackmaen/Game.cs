﻿using System;
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
        private ManagementGrafs _managementGrafs;
        Ghost _ghost;

        private int _countBal;

        public Game() 
        {
            _scena = new Scena("map.txt");
            _player = new Player(new Vecktor(1, 1), '@', _scena);
            _managementGrafs = new ManagementGrafs(_scena);
            _ghost = new Ghost(_player,_scena,_managementGrafs);

            _countBal = 0;
            CountKadr = 0;
        }

        public int CountKadr { get; private set; }

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
                _ghost.Updete();
                
                if(_scena.IsIAteIt(_player))
                    _countBal++;

                CountKadr++;
                Console.Clear();

                _scena.Draw();

                Console.WriteLine($"Количество очков {_countBal}");
                Console.WriteLine($"Количество кудров {CountKadr}");

                _player.Draw();
                _ghost.Draw();

                Thread.Sleep(500);
            }     
        }
    }
}
