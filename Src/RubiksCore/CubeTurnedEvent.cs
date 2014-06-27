using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCore
{
    public class CubeTurnedEvent
    {
        public RubiksDirection FaceTurned 
        { 
            get; 
            private set; 
        }

        public TurningDirection DirectionOfTurn 
        { 
            get; 
            private set; 
        }

        public int NumberOfLayersDeep 
        { 
            get; 
            private set; 
        }

        public CubeTurnedEvent(RubiksDirection faceTurned, TurningDirection directionOfTurn, int numberOfLayersDeep)
        {
            FaceTurned = faceTurned;
            DirectionOfTurn = directionOfTurn;
            NumberOfLayersDeep = numberOfLayersDeep;
        }
    }
}
