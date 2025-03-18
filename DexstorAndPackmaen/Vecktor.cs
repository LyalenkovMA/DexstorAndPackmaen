using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DexstorAndPackmaen
{
    public struct Vecktor: IGameObject
    {
        public Vecktor(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vecktor(Vecktor vecktor)
        {
            X = vecktor.X;
            Y = vecktor.Y;
        }

        public int X {  get; private set; }

        public int Y { get; private set; }

        public static Vecktor Zero => new Vecktor();

        public static Vecktor operator +(Vecktor one, Vecktor two) 
        {
            return new Vecktor(one.X + two.X,one.Y + two.Y);
        }

        public static bool operator !=(Vecktor one, Vecktor two)
        {
            return (one.X != two.X) && (two.Y != one.Y);
        }

        public static bool operator ==(Vecktor one, Vecktor two)
        {
            return (one.X == two.X) && (two.Y == one.Y);
        }
    }
}
