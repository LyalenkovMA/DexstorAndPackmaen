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
        private List<Edge> _edges;

        private Scena _scena;
        private char[,] _map;

        public ManagementGrafs(Scena scena)
        {
            _scena = scena;
            PostGrafs(scena);
            _map = scena.GetMap();
        }

        public Vecktor GetRotateGraf(GameObject gameObject, Vecktor finish, List<Vecktor> completedGrafs)
        {
            Vecktor finishGraf = finish;
            Vecktor start = new Vecktor(gameObject.X, gameObject.Y);

            if(completedGrafs.Contains(start) == false)
                completedGrafs.Add(start);

            Edge oneEdge = new Edge();

            for (int i = 0; i < _edges.Count; i++)
            {
                if((gameObject.X == _edges[i].PosirionOne.X && gameObject.Y == _edges[i].PosirionOne.Y)||
                   (gameObject.X == _edges[i].PositionTwo.X && gameObject.Y == _edges[i].PositionTwo.Y))
                {
                    oneEdge = _edges[i];
                    break;
                }
            }

            //Edge minEdge = oneEdge.GetMinSizeEdge();          

            return finishGraf;
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

        private void PostEdges()
        {
            int countRotait = 4;
            Graf grafTwo = null;

            foreach(Graf grafOne in _grafs)
            {
                for(int i = 1; i < countRotait; i++)
                {
                    if (_scena.IsCollisionWithWall(new Vecktor(grafOne.X+1, grafOne.Y)) == false)
                    {
                        if (IsGraf(new Vecktor(grafOne.X, grafOne.Y), out grafTwo))
                        {
                            _edges.Add(new Edge(grafOne , grafTwo));
                            grafOne.SetListEdges(_edges[_edges.Count - 1]);
                            grafTwo.SetListEdges(_edges[_edges.Count - 1]);
                        }
                    }
                }
            }
        }

        private void CreateRoute(int x, int y, Graf graf)
        {
            int grafX = graf.X;
            int grafY = graf.Y;

            if (_scena.IsCollisionWithWall(new Vecktor(graf.X + x, graf.Y + y)) == false)
            {
                if(x != 0)
                {
                    
                }
            }
        }

        private bool IsGraf(Vecktor grafVecktor, out Graf grafTwo)
        {
            bool isGraf = false;
            grafTwo = null;

            foreach (Graf graf in _grafs)
            {
                if(grafVecktor == new Vecktor(graf.X,graf.Y))
                {
                    isGraf = true;
                    grafTwo = graf;
                    break;
                }
            }

            return isGraf;
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
