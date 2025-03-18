using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexstorAndPackmaen
{
    public abstract class  Ghost : GameObject, IGameObject
    {
        private int _keyPosition;
        private Player _player;
        private Graf _point;
        private ManagementGrafs _managementGrafs;
        
        public Ghost(int keyPosition,Player player, Scena scena, ManagementGrafs managementGrafs) :
            base(scena.GetPositionStartGhost(),'S',scena)
        {
            _keyPosition = keyPosition;
            _player = player;
            _managementGrafs = managementGrafs;

            if (keyPosition <= 4)
                _point = GetPivot(player, keyPosition);
            else
                _point = GetPivot(player, 4);
        }

        public override void Updete()
        {
            if (X == _point.X && Y == _point.Y)
                _point = new Graf(new Vecktor(_player.X,_player.Y));

        }

        private Graf GetPivot(Player player, int key) 
        {
            const int KeyOne = 1;
            const int KeyTwo = 2;
            const int KeyThree = 3;
            const int KeyFour = 4;

            Graf pivot = null;

            switch (key)
            {
                case KeyOne:
                    pivot = new Graf(new Vecktor(player.X, player.Y + 1));
                    break;
                case KeyTwo:
                    pivot = new Graf(new Vecktor(player.X, player.Y - 1));
                    break;
                case KeyThree:
                    pivot = new Graf(new Vecktor(player.X -1, player.Y));
                    break;
                case KeyFour:
                    pivot = new Graf(new Vecktor(player.X+1, player.Y));
                    break;
            }

            return pivot;
        }
    }
}
