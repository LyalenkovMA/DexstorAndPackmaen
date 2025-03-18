using System;
using System.IO;

namespace DexstorAndPackmaen
{
    public struct Scena
    {
        private char[,] _map;

        public Scena(string path)
        {
            _map = null;
            _map = RedFileMap(path);
        }

        public char[,] GetMap()
        {
            char[,] map = new char[_map.GetLength(0), _map.GetLength(1)];

            for (int y = 0; y < _map.GetLength(0); y++)
                for (int x = 0; x < _map.GetLength(1); x++)
                    map[y, x] = _map[y, x];

            return map;
        }

        public Vecktor GetPositionStartGhost()
        {
            Vecktor position = new Vecktor();
            char simboleStart = '$';

            for(int y = 0; y < _map.GetLength(0); y++)
            {
                for (int x = 0; x < _map.GetLength(1); x++)
                    if (_map[y, x] == simboleStart)
                        position = new Vecktor(y,x);
            }

            return position;
        }

        public bool IsCollisionWithWall(Vecktor vecktor)
        {
            char wall = '#';

            if (_map[vecktor.Y, vecktor.X] == wall)
                return true;
            return false;
        }

        public void Draw()
        {
            for (int y = 0; y < _map.GetLength(0); y++)
            {
                for (int x = 0; x < _map.GetLength(1); x++)
                    Console.Write(_map[y, x]);
                Console.WriteLine();
            }
        }

        public bool IsIAteIt(Player player)
        {
            char eat = '.';
            char emptyCell = ' ';

            if (_map[player.Y, player.X] == eat)
            {
                _map[player.Y, player.X] = emptyCell;
                return true;
            }

            return false;
        }

        private char[,] RedFileMap(string path)
        {
            string[] lineFile = File.ReadAllLines(path);
            char[,] map = new char[GetMaxOfLine(lineFile), lineFile.Length];

            for (int y = 0; y < lineFile.Length; y++)
                for (int x = 0; x < lineFile[y].Length; x++)
                    map[y, x] = lineFile[y][x];

            return map;
        }

        private int GetMaxOfLine(string[] lins)
        {
            int maxLins = 0;

            foreach (string line in lins)
            {
                if (line.Length > maxLins)
                    maxLins = line.Length;
            }

            return maxLins;
        }
    }
}
