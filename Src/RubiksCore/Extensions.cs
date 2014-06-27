using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCore
{
    public static class Extensions
    {
        public static TurningDirection InvertTurningDirection(this TurningDirection direction)
        {
            switch (direction)
            {
                case TurningDirection.ThreeoClock:
                    return TurningDirection.NineoClock;
                case TurningDirection.SixoClock:
                    return TurningDirection.SixoClock;
                case TurningDirection.NineoClock:
                    return TurningDirection.ThreeoClock;
                default:
                    return default(TurningDirection);
            }
        }
    }
}
