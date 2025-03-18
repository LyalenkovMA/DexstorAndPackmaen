using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexstorAndPackmaen
{
    public abstract class  Ghost : GameObject, IGameObject
    {
        private Player _player;
        private Queue<Vecktor> _way;
        private Game _game;

        private bool _isRun;
        private bool _isEaten;
        private bool _isLive;
        private int _time;

        public Ghost(Player player, Scena scena, Game game) :
            base(scena.GetPositionStartGhost(), 'S', scena)
        {
            _player = player;
            _isRun = false;
            _isEaten = false;
            _isLive = true;
            _game = game;
        }

        public override void Updete()
        {
           if(_isRun == false)
            {

            }
           else if(_isEaten == false)
            {
                if (_isLive)
                {

                }
            }
            else
            {
                if (_isEaten)
                {
                    if(_time - _game.CountKadr >= 5)
                    {
                        _isLive = true;
                        _isEaten = false;
                        GetOldPosition();
                    }
                }
            }
        }

        private void Wait()
        {
            if(_isLive == false && _isEaten == false)
            {
                _time = _game.CountKadr;
                _isEaten = true;
            }
        }
    }
}
