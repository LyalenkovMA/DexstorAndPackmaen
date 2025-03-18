using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexstorAndPackmaen
{
    public class Player : GameObject, IGameObject
    {
        private const int DirectionUp = 1;
        private const int DirectionDown = 2;
        private const int DirectionLeft = 3;
        private const int DirectionRight = 4;

        private Scena _scena;
        private int _direction;
        private Vecktor _startPosition;
        
        public Player(Vecktor vecktor, char simpole, Scena scena): 
        base(vecktor,simpole,scena)
        {
            _scena = scena;
            _direction = DirectionRight;
            CountLive = 3;
            _startPosition = vecktor;
        }

        public int CountLive { get; private set; }

        public bool IsLive => CountLive > 0;

        public override void Updete()
        {
            int moweGo = 1;
            int moweBace = -1;
            int moweStop = 0;

            switch (_direction) 
            {
                case DirectionUp:
                    SetPosition(new Vecktor(moweStop,moweBace));
                    break;
                case DirectionDown:
                    SetPosition(new Vecktor(moweStop, moweGo));
                    break;
                case DirectionLeft:
                    SetPosition(new Vecktor(moweBace, moweStop));
                    break;
                case DirectionRight:
                    SetPosition(new Vecktor(moweGo, moweStop));
                    break;
            }
        }

        public void CollisionGhostes(Ghost[] ghosts)
        {
            foreach (Ghost ghost in ghosts)
            {
                if(X == ghost.X && Y == ghost.Y)
                {
                    CountLive--;
                    GetOldPosition(_startPosition);
                    return;
                }
            }
        }

        public void Controle()
        {
            const ConsoleKey CommandMoveUp = ConsoleKey.UpArrow;
            const ConsoleKey CommandMoveDown = ConsoleKey.DownArrow;
            const ConsoleKey CommandMoveLeft = ConsoleKey.LeftArrow;
            const ConsoleKey CommandMoveRight = ConsoleKey.RightArrow;

            ConsoleKey userkey = Console.ReadKey().Key;

            switch (userkey)
            {
                case CommandMoveUp:
                    _direction = DirectionUp;
                    break;
                case CommandMoveDown:
                    _direction = DirectionDown;
                    break;
                case CommandMoveLeft:
                    _direction = DirectionLeft;
                    break;
                case CommandMoveRight:
                    _direction = DirectionRight;
                    break;
            }
        }

        private void Move()
        {
            int moweForward = 1;
            int moweBack = -1;
            int moweStop = 0;

            switch (_direction)
            {
                case DirectionUp:
                    SetPosition(new Vecktor(moweStop,moweForward));
                    break;
                case DirectionDown:
                    SetPosition(new Vecktor(moweStop, moweBack));
                    break;
                case DirectionLeft:
                    SetPosition(new Vecktor(moweBack,moweStop));
                    break;
                case DirectionRight:
                    SetPosition(new Vecktor(moweForward ,moweStop));
                    break;
            }
        }
    }
}
