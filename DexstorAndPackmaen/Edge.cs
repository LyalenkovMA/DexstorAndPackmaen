using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DexstorAndPackmaen
{
    public class Edge
    {
        public Graf One;
        public Graf Two;
        
        public Edge(Graf one, Graf two)
        {
            One = one;
            Two = two;
            PosirionOne = new Vecktor(one.X,one.Y);
            PositionTwo = new Vecktor(two.X,two.Y);

            if (PosirionOne.X - PositionTwo.X != 0)
                Weight = Math.Abs(PosirionOne.X - PositionTwo.X);
            else
                Weight = Math.Abs(PosirionOne.Y - PositionTwo.Y);
        }

        public int Weight { get;private set; }

        public Vecktor PosirionOne { get; internal set; }

        public Vecktor PositionTwo { get; private set; }
    }
}