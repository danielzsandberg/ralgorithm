using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCore.RubiksUIControls
{
    public struct TwoDPosition
    {
        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public TwoDPosition(int x, int y)
            : this()
        {
            X = x;
            Y = y;
        }
    }
}
