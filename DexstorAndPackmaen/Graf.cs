using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexstorAndPackmaen
{
    public class Graf : IGameObject
    {
        private Vecktor _position;

        public Graf(Vecktor position)
        {
            _position = position;

            X = _position.X;
            Y = _position.Y;
        }

        public int X { get; private set; }
        
        public int Y { get; private set; }

        public Edge Upper { get; private set; }

        public Edge Lower { get; private set; }

        public Edge Left { get; private set; }

        public Edge Rigth { get; private set;}

        public void SetEdges(Graf graf)
        {
            if (graf.X < X)
                Left = new Edge(graf, this);
            else
                Left = null;
            if (graf.X > X)
                Rigth = new Edge(this, graf);
            else
                Rigth = null;
            if (graf.Y > Y)
                Lower = new Edge(this, graf);
            else
                Lower = null;
            if (graf.Y < Y)
                Upper = new Edge(graf, this);
            else
                Upper = null;
        }
    }
}
