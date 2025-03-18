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
        private List<Edge> _edges;

        public Graf(Vecktor position)
        {
            _position = position;

            X = _position.X;
            Y = _position.Y;
        }

        public int X { get; private set; }
        
        public int Y { get; private set; }

        public void SetListEdges(Edge edge)
        {
            _edges.Add(edge);
        }

        public Edge GetEdge(Graf purpose)
        {
            Edge edgePurpose = new Edge();

            foreach (Edge edge in _edges)
            {
                if(edge.PosirionOne.X == X && edge.PosirionOne.Y == Y)
                {
                    if(edge.PositionTwo.X - X< purpose.X - X ||
                        edge.PositionTwo.Y - Y < purpose.Y - Y)
                        edgePurpose = edge;
                    break;
                }
                else if (edge.PositionTwo.X == X && edge.PositionTwo.Y == Y)
                {
                    if (edge.PosirionOne.X - X < purpose.X - X ||
                        edge.PosirionOne.Y - Y < purpose.Y - Y)
                        edgePurpose = edge;
                    break;
                }
            }

            return edgePurpose;
        }

        public Edge GetMinSizeEdge()
        {
            Edge minSizeEdge = _edges[0];
            
            if(_edges.Count > 1)
            {
                for(int i = 1; i < _edges.Count; i++)
                {
                    if(minSizeEdge.Weight > _edges[i].Weight)
                        minSizeEdge = _edges[i];
                }
            }

           return minSizeEdge;
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
                    pivot = new Graf(new Vecktor(player.X, player.Y - 1));
                    break;
                case KeyTwo:
                    pivot = new Graf(new Vecktor(player.X, player.Y - 1));
                    break;
                case KeyThree:
                    pivot = new Graf(new Vecktor(player.X - 1, player.Y));
                    break;
                case KeyFour:
                    pivot = new Graf(new Vecktor(player.X + 1, player.Y));
                    break;
            }

            return pivot;
        }
    }
}
