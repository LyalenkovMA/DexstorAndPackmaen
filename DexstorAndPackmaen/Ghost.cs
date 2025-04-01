using System.Collections.Generic;

namespace DexstorAndPackmaen
{
    public class Ghost : GameObject, IGameObject
    {
        private Player _player;
        private List<Vecktor> _way;
        private ManagementGrafs _managementGrafs;

        private bool _isRun;
        private bool _isEaten;
        private bool _isLive;
        private int _time;

        private Vecktor _moveUp;
        private Vecktor _moveDovn;
        private Vecktor _moveLeft;
        private Vecktor _moveRight;

        public Ghost(Player player, Scena scena, ManagementGrafs managementGrafs) :
            base(scena.GetPositionStartGhost(), 'S', scena)
        {
            _player = player;
            _managementGrafs = managementGrafs;
            _isRun = false;
            _isEaten = false;
            _isLive = true;

            _moveUp = new Vecktor(0, -1);
            _moveDovn = new Vecktor(0, 1);
            _moveLeft = new Vecktor(-1, 0);
            _moveRight = new Vecktor(1, 0);
        }

        public override void Updete()
        {
            Vecktor finish = new Vecktor(_player.X, _player.Y);
            Vecktor start = new Vecktor(X, Y);

            if (_way != null)
            {
                if (_way.Count > 0)
                {
                    if (_way[0].X != X && _way[0].Y != Y)
                    {
                        if (_way[0].Y == Y)
                        {
                            if (X > _way[0].X)
                                SetPosition(_moveLeft);
                            else
                                SetPosition(_moveRight);
                        }
                        else
                        {
                            if (Y > _way[0].Y)
                                SetPosition(_moveUp);
                            else
                                SetPosition(_moveDovn);
                        }
                    }
                    else
                    {
                        _way.RemoveAt(0);
                    }
                }
                else
                {
                    _way = null;
                }
            }
            else
            {
                _way = _managementGrafs.GetWay(finish, start);
            }
        }
    }
}
