using RubiksCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.CubeSolverModule
{
    /// <summary>
    /// Provides extensions for the RubiksCube class.
    /// </summary>
    static class RubiksCubeExtensions
    {
        /// <summary>
        /// Gets a color for a TwoDPosition on a two dimensional projection of the RubiksCube.
        /// </summary>
        /// <param name="cube">The cube</param>
        /// <param name="pos">The two dimensional position</param>
        /// <returns>A string representing the color.</returns>
        private static string GetColor(this RubiksCube cube, TwoDPosition pos)
        {
            Dictionary<TwoDPosition, Position> positionMappings =
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

            Dictionary<TwoDPosition, RubiksDirection> positionFaceMappings =
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

            if (cube.CubeSize != 3)
            {
                throw new NotSupportedException("Currently we only draw 3x3x3 cubes two dimensionally :(");
            }

            Position threeDPosition = default(Position);
            RubiksDirection direction = default(RubiksDirection);
            if (positionFaceMappings.ContainsKey(pos) && positionMappings.ContainsKey(pos))
            {
                threeDPosition = positionMappings[pos];
                direction = positionFaceMappings[pos];
            }


            RubiksColor? positionColor = cube[threeDPosition].GetColor(direction);

            if (positionColor == null)
            {
                //oops
                return "?";
            }

            switch (positionColor.Value)
            {
                case RubiksColor.Blue:
                    return "B";
                case RubiksColor.Green:
                    return "G";
                case RubiksColor.Orange:
                    return "O";
                case RubiksColor.Red:
                    return "R";
                case RubiksColor.White:
                    return "W";
                case RubiksColor.Yellow:
                    return "Y";
                default:
                    return "?";
            }
        }

        /// <summary>
        /// Gets a color for a TwoDPosition on a two dimensional projection of the RubiksCube.
        /// </summary>
        /// <param name="cube">The cube</param>
        /// <param name="x">The x coordinate of the two dimensional position</param>
        /// <param name="y">The y coordinate of the two dimensional position</param>
        /// <returns> string representing the color.</returns>
        public static string GetColor(this RubiksCube cube, int x, int y)
        {
            return GetColor(cube, new TwoDPosition(x, y));
        }
    }


}
