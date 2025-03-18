using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DexstorAndPackmaen
{
    public struct Edge
    {
        private Graf _one;
        private Graf _two;
        
        public Edge(Graf one, Graf two)
        {
            _one = one;
            _two = two;
            PosirionOne = new Vecktor(one.X,one.Y);
            PositionTwo = new Vecktor(two.X,two.Y);

            if (PosirionOne.X - PositionTwo.X != 0)
                Weight = Math.Abs(PosirionOne.X - PositionTwo.X);
            else
                Weight = Math.Abs(PosirionOne.Y - PositionTwo.Y);
        }

        public int Weight { get;private set; }

        public Vecktor PosirionOne { get; private set; }

        public Vecktor PositionTwo { get; private set; }
    }
}