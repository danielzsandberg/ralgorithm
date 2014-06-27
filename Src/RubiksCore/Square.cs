using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCore
{
    struct Square
    {
        public Position PositionOne
        {
            get;
            set;
        }

        public Position PositionTwo
        {
            get;
            set;
        }

        public Position PositionThree
        {
            get;
            set;
        }

        public Position PositionFour
        {
            get;
            set;
        }

        public IEnumerable<Position> PositionsInSquare
        {
            get;
            set;
        }
    } 
}
