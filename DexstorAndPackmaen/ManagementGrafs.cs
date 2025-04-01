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
        Vecktor _upMove;
        Vecktor _downMove;
        Vecktor _leftMove;
        Vecktor _rigthMove;

        public ManagementGrafs(Scena scena)
        {
            _upMove = new Vecktor(0, -1);
            _downMove = new Vecktor(0, 1);
            _leftMove = new Vecktor(-1, 0);
            _rigthMove = new Vecktor(1, 0);

            _scena = scena;
            _map = scena.GetMap();
            _grafs = new List<Graf>();

            PlaceGraphs();
            PlaceEdge();
        }

        public List<Vecktor> GetWay(Vecktor finishPosition, Vecktor startPosition)
        {
            List<Vecktor> way = new List<Vecktor>();
            Edge minEdge = null;
            List<Graf> failedGraphs = new List<Graf>();
            Graf finish = new Graf(finishPosition);
            Graf start = new Graf(startPosition);
            Graf graf;
            SetEdge(finish);

            foreach (Graf grafOne in _grafs)
                if (grafOne.X == startPosition.X && grafOne.Y == startPosition.Y)
                    start = grafOne;

            foreach (Graf grafTwo in _grafs)
                failedGraphs.Add(grafTwo);

            failedGraphs.Add(finish);


            while(start.X != finish.X && start.Y != finish.Y)
            {
                if(failedGraphs.Contains(start))
                    failedGraphs.Remove(start);

                graf = start;
                minEdge = GetMinEdge(graf);
                start = minEdge.Two;

                if(minEdge != null)
                    way.Add(new Vecktor(start.X,start.Y));
            }

            return way;
        }

        private Edge GetMinEdge(Graf graf)
        {
            Edge edge = null;

            edge = GetEdge(graf.Upper, edge);
            edge = GetEdge(graf.Lower, edge);
            edge = GetEdge(graf.Left, edge);
            edge = GetEdge(graf.Rigth, edge);

            return edge;
        }

        private static Edge GetEdge(Edge edgeGraf, Edge edge)
        {
            Edge edgeMin = edge;
            if(edge != null)
                if (edgeMin.Weight < edgeGraf.Weight)
                    edgeMin = edgeGraf;
            return edgeMin;
        }

        private void PlaceGraphs()
        {
            Vecktor vecktor;
            for(int y= 0; y < _map.GetLength(0); y++)
            {
                for(int x = 0; x < _map.GetLength(1); x++)
                {
                    vecktor = new Vecktor(y, x);

                    if (_scena.IsCollisionWithWall(vecktor) == false)
                        AddGraf(vecktor);
                }
            }
        }

        private void PlaceEdge()
        {
            foreach (Graf graf in _grafs)
            {
                SetEdge(graf);
            }
        }

        private void SetEdge(Graf graf)
        {
            MoveEdge(graf, _upMove);
            MoveEdge(graf, _downMove);
            MoveEdge(graf, _leftMove);
            MoveEdge(graf, _rigthMove);
        }

        private void MoveEdge(Graf graf, Vecktor move)
        {
            Graf grafTwo;
            Vecktor vecktor = new Vecktor(graf.X,graf.Y);

            while(IsGrag(vecktor,out grafTwo))
                vecktor += move;
            
            if (grafTwo != null)
                graf.SetEdges(grafTwo);
        }

        private bool IsGrag(Vecktor vecktor,out Graf graf)
        {
            bool isGraf = false;
            graf = null;

            for(int i = 0; i < _grafs.Count; i++)
            {
                if (vecktor.X == _grafs[i].X && vecktor.Y == _grafs[i].Y)
                {
                    isGraf = true;
                    graf = _grafs[i];
                    break;
                }
            }

            return isGraf;
        }

        private void AddGraf(Vecktor position)
        {
            int numberPaths = 0;
            Vecktor upMove = new Vecktor(0, -1);
            Vecktor downMove = new Vecktor(0, 1);
            Vecktor leftMove = new Vecktor(-1, 0);
            Vecktor rigthMove = new Vecktor(1, 0);

            if (_scena.IsCollisionWithWall(position) == false)
            {
                numberPaths = ToFeelWay(position, numberPaths, upMove);
                numberPaths = ToFeelWay(position, numberPaths, downMove);
                numberPaths = ToFeelWay(position, numberPaths, leftMove);
                numberPaths = ToFeelWay(position, numberPaths, rigthMove);

                if(numberPaths > 1)
                {
                    if(numberPaths > 2)
                    {
                        if ((_scena.IsCollisionWithWall(position + upMove) && _scena.IsCollisionWithWall(position + leftMove)) ||
                           (_scena.IsCollisionWithWall(position + upMove) && _scena.IsCollisionWithWall(position + rigthMove)) ||
                           (_scena.IsCollisionWithWall(position + downMove) && _scena.IsCollisionWithWall(position + leftMove)) ||
                           (_scena.IsCollisionWithWall(position + downMove) && _scena.IsCollisionWithWall(position + rigthMove)))
                            _grafs.Add(new Graf(position));
                    }
                    else
                    {
                        _grafs.Add(new Graf(position));
                    }
                }
            }
        }

        private int ToFeelWay(Vecktor position, int numberPaths, Vecktor move)
        {
            if (_scena.IsCollisionWithWall(position + move))
                numberPaths++;
            return numberPaths;
        }
    }
}
