using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexstorAndPackmaen
{
    public class ManagementGrafs
    {
        private List<Graf> _grafs;

        private Scena _scena;
        private char[,] _map;

        public ManagementGrafs(Scena scena)
        {
            _scena = scena;
            PostGrafs(scena);
            _map = scena.GetMap();
        }

        public Queue<Vecktor> GetRoute(Player player, Graf Start)
        {
            Queue<Vecktor> route = new Queue<Vecktor>();
            List<Graf> failedGraphs = new List<Graf>();
            AddGrafs(failedGraphs);

            List<Edge> edges = new List<Edge>();
            failedGraphs.Remove(Start);

            while (new Vecktor(Start.X,Start.Y) != new Vecktor(player.X, player.Y))
            {
                if (Start.Left.Weight != 0)
                    edges.Add(Start.Left);
                if (Start.Rigth.Weight != 0)
                    edges.Add(Start.Rigth);
                if (Start.Upper.Weight != 0)
                    edges.Add(Start.Upper);
                if (Start.Lower.Weight != 0)
                    edges.Add(Start.Lower);

                Edge minWeight = edges[0];

                for (int i = 0; i < edges.Count; i++)
                {
                    if (minWeight.Weight > edges[i].Weight)
                        minWeight = edges[i];
                }

                if(failedGraphs.Contains(minWeight.One) ==false)
                {
                    route.Append(minWeight.PositionTwo);
                    Start = minWeight.Two;
                }
                else
                {
                    route.Append(minWeight.PosirionOne);
                    Start = minWeight.One;
                }
            }

            return route;
        }

        private void AddGrafs(List<Graf> failedGraphs)
        {
            for (int i = 0; i < _grafs.Count; i++)
                failedGraphs.Add(_grafs[i]);
        }

        private void PostGrafs(Scena scena)
        {
            int startX = 1;
            int startY = 1;
            
            for(int y = startY; y < _map.GetLength(0); y++)
            {
                for(int x = startX; x < _map.GetLength(0); x++)
                {
                    if(IsPostGraf(new Vecktor(x, y)))
                        _grafs.Add(new Graf(new Vecktor(x,y)));
                }
            }
        }

        private bool IsPostGraf(Vecktor point)
        {
            int step = 1;
            int stop = 0;
            bool isWall = false;

            if (
               (_scena.IsCollisionWithWall(point + new Vecktor(point.X - step,stop)) == isWall && 
               _scena.IsCollisionWithWall(point + new Vecktor(stop, point.Y -step)) == isWall)|| 
               (_scena.IsCollisionWithWall(point + new Vecktor(point.X + step, stop)) == isWall && 
                _scena.IsCollisionWithWall(point + new Vecktor(stop, point.Y + step)) == isWall)
              )
                return true;
            return false;
        }
    }
}
