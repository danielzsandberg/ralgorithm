using RubiksCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RubiksCore.RubiksUIControls
{
    public static class RubiksCubeExtensions
    {
        private static Dictionary<TwoDPosition, Position> _positionMappings =
            new Dictionary<TwoDPosition, Position>()
            {
                //Corners
                {new TwoDPosition(3, 8), new Position(0,0,0)},
                {new TwoDPosition(0, 5), new Position(0,0,0)},
                {new TwoDPosition(11, 5), new Position(0,0,0)},

                {new TwoDPosition(8, 5), new Position(2,0,0)},
                {new TwoDPosition(5, 8), new Position(2,0,0)},
                {new TwoDPosition(9, 5), new Position(2,0,0)},

                {new TwoDPosition(8, 3), new Position(2,0,2)},
                {new TwoDPosition(5, 0), new Position(2,0,2)},
                {new TwoDPosition(9, 3), new Position(2,0,2)},

                {new TwoDPosition(5, 3), new Position(2,2,2)},
                {new TwoDPosition(6, 3), new Position(2,2,2)},
                {new TwoDPosition(5, 2), new Position(2,2,2)},

                {new TwoDPosition(3, 3), new Position(0,2,2)},
                {new TwoDPosition(2, 3), new Position(0,2,2)},
                {new TwoDPosition(3, 2), new Position(0,2,2)},

                {new TwoDPosition(3, 0), new Position(0,0,2)},
                {new TwoDPosition(0, 3), new Position(0,0,2)},
                {new TwoDPosition(11, 3), new Position(0,0,2)},

                {new TwoDPosition(5, 5), new Position(2,2,0)},
                {new TwoDPosition(5, 6), new Position(2,2,0)},
                {new TwoDPosition(6, 5), new Position(2,2,0)},

                {new TwoDPosition(3, 5), new Position(0,2,0)},
                {new TwoDPosition(2, 5), new Position(0,2,0)},
                {new TwoDPosition(3, 6), new Position(0,2,0)},





                {new TwoDPosition(4, 8), new Position(1,0,0)},
                {new TwoDPosition(10, 5), new Position(1,0,0)},

                {new TwoDPosition(8, 4), new Position(2,0,1)},
                {new TwoDPosition(9, 4), new Position(2,0,1)},

                {new TwoDPosition(4, 0), new Position(1,0,2)},
                {new TwoDPosition(10, 3), new Position(1,0,2)},

                {new TwoDPosition(0, 4), new Position(0,0,1)},
                {new TwoDPosition(11, 4), new Position(0,0,1)},

                {new TwoDPosition(4, 5), new Position(1,2,0)},
                {new TwoDPosition(4, 6), new Position(1,2,0)},

                {new TwoDPosition(3, 4), new Position(0,2,1)},
                {new TwoDPosition(2, 4), new Position(0,2,1)},

                {new TwoDPosition(4, 3), new Position(1,2,2)},
                {new TwoDPosition(4, 2), new Position(1,2,2)},

                {new TwoDPosition(5, 4), new Position(2,2,1)},
                {new TwoDPosition(6, 4), new Position(2,2,1)},

                {new TwoDPosition(3, 1), new Position(0,1,2)},
                {new TwoDPosition(1, 3), new Position(0,1,2)},

                {new TwoDPosition(3, 7), new Position(0,1,0)},
                {new TwoDPosition(1, 5), new Position(0,1,0)},

                {new TwoDPosition(5, 1), new Position(2,1,2)},
                {new TwoDPosition(7, 3), new Position(2,1,2)},

                {new TwoDPosition(7, 5), new Position(2,1,0)},
                {new TwoDPosition(5, 7), new Position(2,1,0)},




                {new TwoDPosition(4, 4), new Position(1,2,1)},
                {new TwoDPosition(10, 4), new Position(1,0,1)},
                {new TwoDPosition(7, 4), new Position(2,1,1)},
                {new TwoDPosition(1, 4), new Position(0,1,1)},
                {new TwoDPosition(4, 1), new Position(1,1,2)},
                {new TwoDPosition(4, 7), new Position(1,1,0)},
            };

        private static Dictionary<TwoDPosition, RubiksDirection> _positionFaceMappings =
            new Dictionary<TwoDPosition, RubiksDirection>()
            {
                {new TwoDPosition(3, 8), RubiksDirection.Down},
                {new TwoDPosition(0, 5), RubiksDirection.Left},
                {new TwoDPosition(11, 5), RubiksDirection.Back},
                {new TwoDPosition(8, 5), RubiksDirection.Right},
                {new TwoDPosition(5, 8), RubiksDirection.Down},
                {new TwoDPosition(9, 5), RubiksDirection.Back},
                {new TwoDPosition(8, 3), RubiksDirection.Right},
                {new TwoDPosition(5, 0), RubiksDirection.Up},
                {new TwoDPosition(9, 3), RubiksDirection.Back},
                {new TwoDPosition(5, 3), RubiksDirection.Front},
                {new TwoDPosition(6, 3), RubiksDirection.Right},
                {new TwoDPosition(5, 2), RubiksDirection.Up},
                {new TwoDPosition(3, 3), RubiksDirection.Front},
                {new TwoDPosition(2, 3), RubiksDirection.Left},
                {new TwoDPosition(3, 2), RubiksDirection.Up},
                {new TwoDPosition(3, 0), RubiksDirection.Up},
                {new TwoDPosition(0, 3), RubiksDirection.Left},
                {new TwoDPosition(11, 3), RubiksDirection.Back},
                {new TwoDPosition(5, 5), RubiksDirection.Front},
                {new TwoDPosition(5, 6), RubiksDirection.Down},
                {new TwoDPosition(6, 5), RubiksDirection.Right},
                {new TwoDPosition(3, 5), RubiksDirection.Front},
                {new TwoDPosition(2, 5), RubiksDirection.Left},
                {new TwoDPosition(3, 6), RubiksDirection.Down},

                {new TwoDPosition(4, 8), RubiksDirection.Down},
                {new TwoDPosition(10, 5), RubiksDirection.Back},
                {new TwoDPosition(8, 4), RubiksDirection.Right},
                {new TwoDPosition(9, 4), RubiksDirection.Back},
                {new TwoDPosition(4, 0), RubiksDirection.Up},
                {new TwoDPosition(10, 3), RubiksDirection.Back},
                {new TwoDPosition(0, 4), RubiksDirection.Left},
                {new TwoDPosition(11, 4), RubiksDirection.Back},
                {new TwoDPosition(4, 5), RubiksDirection.Front},
                {new TwoDPosition(4, 6), RubiksDirection.Down},
                {new TwoDPosition(3, 4), RubiksDirection.Front},
                {new TwoDPosition(2, 4), RubiksDirection.Left},
                {new TwoDPosition(4, 3), RubiksDirection.Front},
                {new TwoDPosition(4, 2), RubiksDirection.Up},
                {new TwoDPosition(5, 4), RubiksDirection.Front},
                {new TwoDPosition(6, 4), RubiksDirection.Right},
                {new TwoDPosition(3, 1), RubiksDirection.Up},
                {new TwoDPosition(1, 3), RubiksDirection.Left},
                {new TwoDPosition(3, 7), RubiksDirection.Down},
                {new TwoDPosition(1, 5), RubiksDirection.Left},
                {new TwoDPosition(5, 1), RubiksDirection.Up},
                {new TwoDPosition(7, 3), RubiksDirection.Right},
                {new TwoDPosition(7, 5), RubiksDirection.Right},
                {new TwoDPosition(5, 7), RubiksDirection.Down},

                {new TwoDPosition(4, 4), RubiksDirection.Front},
                {new TwoDPosition(10, 4), RubiksDirection.Back},
                {new TwoDPosition(7, 4), RubiksDirection.Right},
                {new TwoDPosition(1, 4), RubiksDirection.Left},
                {new TwoDPosition(4, 1), RubiksDirection.Up},
                {new TwoDPosition(4, 7), RubiksDirection.Down},

            };

        public static Color GetColor(this RubiksCube cube, TwoDPosition pos)
        {
            if(cube.CubeSize != 3)
            {
                throw new NotSupportedException("Currently we only draw 3x3x3 cubes two dimensionally :(");
            }

            Position threeDPosition = default(Position);
            RubiksDirection direction = default(RubiksDirection);
            if(_positionFaceMappings.ContainsKey(pos) && _positionMappings.ContainsKey(pos))
            {
                threeDPosition = _positionMappings[pos];
                direction = _positionFaceMappings[pos];
            }
            

            RubiksColor? positionColor = cube[threeDPosition].GetColor(direction);

            if(positionColor == null)
            {
                //oops
                return Colors.Gray;
            }

            switch (positionColor.Value)
            {
                case RubiksColor.Blue:
                    return Colors.Blue;
                case RubiksColor.Green:
                    return Colors.Green;
                case RubiksColor.Orange:
                    return Colors.Orange;
                case RubiksColor.Red:
                    return Colors.Red;
                case RubiksColor.White:
                    return Colors.White;
                case RubiksColor.Yellow:
                    return Colors.Yellow;
                default:
                    return Colors.Gray;
            }
        }
    }
}
