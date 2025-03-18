using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexstorAndPackmaen
{
    public abstract class GameObject: IGameObject
    {
        protected Scena GameScena;
        private Vecktor _position;

        public GameObject(Vecktor vecktor, char simpole, Scena scena) 
        {
            _position = vecktor;
            SimboleObject = simpole;
            GameScena = scena;
            X = _position.X;
            Y = _position.Y;
        }

        public char SimboleObject { get;private set; }

        public int X {  get; private set; }
        
        public int Y {  get; private set; }

        protected Vecktor GetPosition => _position;

        public abstract void Updete();

        public void Draw()
        {
            Console.SetCursorPosition(_position.X, _position.Y);
            Console.Write(SimboleObject);
        }

        protected void SetPosition(Vecktor vecktor)
        {
            Vecktor oldPosition = _position;
            _position += vecktor;
            
            if(GameScena.IsCollisionWithWall(_position))
                _position = oldPosition;

            X= _position.X; 
            Y= _position.Y;
        }

        protected void GetOldPosition(Vecktor oldPosition)
        {
            _position = oldPosition;
        }
    }
}
