using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCore
{
    internal class CubeFace
    {
        #region Instance Variables

        private Dictionary<RubiksDirection, Position> _startingPointsForVariousFaces =
            new Dictionary<RubiksDirection, Position>();
        private List<Position> _positions = new List<Position>();
        private int _parentCubeSize; 

        #endregion

        #region Properties

        internal IEnumerable<Position> CubiePositions
        {
            get
            {
                return _positions;
            }
        }

        internal RubiksDirection FaceDirection
        {
            get;
            private set;
        } 

        #endregion

        #region Constructors

        internal CubeFace(RubiksDirection direction, int parentCubeSize = 3)
        {
            _parentCubeSize = parentCubeSize;
            FaceDirection = direction;
            InitializeStartingPoints(parentCubeSize);
            InitializeCubiePositions(parentCubeSize);
        } 

        #endregion

        #region Methods

        /// <summary>
        /// Gets CubiePositions for this face in addition to any number of layers deep.
        /// </summary>
        /// <param name="numberOfLayersDeep">The number of layers beneath the face to get positions for.</param>
        /// <returns>The cumulative positions for this face and the layers beneath it.</returns>
        public IEnumerable<Position> GetPositionsOfLayersBeneathFace(int numberOfLayersDeep)
        {
            List<Position> aggregateList = new List<Position>();
            aggregateList.AddRange(CubiePositions);

            for(int layerNumber = 1; layerNumber <= numberOfLayersDeep; layerNumber++)
            {
                foreach(Position pos in CubiePositions)
                {
                    Position transformedPosition = pos;
                    int transformation = layerNumber;
                    switch (FaceDirection)
                    {
                        case RubiksDirection.Front:
                            transformation *= -1;
                            transformedPosition.Y += transformation;
                            break;
                        case RubiksDirection.Back:
                            transformedPosition.Y += transformation;
                            break;
                        case RubiksDirection.Up:
                            transformation *= -1;
                            transformedPosition.Z += transformation;
                            break;
                        case RubiksDirection.Down:
                            transformedPosition.Z += transformation;
                            break;
                        case RubiksDirection.Left:
                            transformedPosition.X += transformation;
                            break;
                        case RubiksDirection.Right:
                            transformation *= -1;
                            transformedPosition.X += transformation;
                            break;
                        default:
                            break;
                    }

                    aggregateList.Add(transformedPosition);
                }
            }

            return aggregateList;
        }

        public IDictionary<Position, Position> Move(TurningDirection direction, int numberOfLayersDeep = 0)
        {
            Dictionary<Position, Position> _positions = new Dictionary<Position,Position>();

            foreach(Square square in GetSquares(numberOfLayersDeep))
            {
                foreach(Position pos in square.PositionsInSquare)
                {
                    PositionMover mover = new PositionMover(pos, square.PositionOne, square.PositionTwo, square.PositionThree, square.PositionFour);
                    int numberOfPositionsToMoveForThreeOClock = _parentCubeSize - 1;
                    int numberOfPositionToMove = numberOfPositionsToMoveForThreeOClock;
                    switch (direction)
                    {
                        case TurningDirection.ThreeoClock:
                            numberOfPositionToMove *= 1;
                            break;
                        case TurningDirection.SixoClock:
                            numberOfPositionToMove *= 2;
                            break;
                        case TurningDirection.NineoClock:
                            numberOfPositionToMove *= 3;
                            break;
                        default:
                            break;
                    }
                    _positions.Add(pos, mover.Move(numberOfPositionToMove));
                }
            }

            return _positions;
        }

        public IEnumerable<Square> GetSquares(int numberOfLayersDeep)
        {
            int max = _parentCubeSize - 1;
            List<Square> squares = new List<Square>();
            for (int layer = 0; layer <= numberOfLayersDeep; layer++)
            {
                Position positionOne = default(Position);
                Position positionTwo = default(Position);
                Position positionThree = default(Position);
                Position positionFour = default(Position);
                int fixedValue = 0;
                switch (FaceDirection)
                {
                    case RubiksDirection.Front:
                        fixedValue = _parentCubeSize - 1 - layer;
                        positionOne = new Position() { X = 0, Y = fixedValue, Z = 0 };
                        positionTwo = new Position() { X = 0, Y = fixedValue, Z = max };
                        positionThree = new Position() { X = max, Y = fixedValue, Z = max };
                        positionFour = new Position() { X = max, Y = fixedValue, Z = 0 };
                        break;
                    case RubiksDirection.Back:
                        fixedValue = layer;
                        positionOne = new Position() { X = 0, Y = fixedValue, Z = 0 };
                        positionTwo = new Position() { X = 0, Y = fixedValue, Z = max };
                        positionThree = new Position() { X = max, Y = fixedValue, Z = max };
                        positionFour = new Position() { X = max, Y = fixedValue, Z = 0 };
                        break;
                    case RubiksDirection.Up:
                        fixedValue = _parentCubeSize - 1 - layer;
                        positionOne = new Position() { X = 0, Y = max, Z = fixedValue };
                        positionTwo = new Position() { X = 0, Y = 0, Z = fixedValue };
                        positionThree = new Position() { X = max, Y = 0, Z = fixedValue };
                        positionFour = new Position() { X = max, Y = max, Z = fixedValue };
                        break;
                    case RubiksDirection.Down:
                        fixedValue = layer;
                        positionOne = new Position() { X = 0, Y = max, Z = fixedValue };
                        positionTwo = new Position() { X = 0, Y = 0, Z = fixedValue };
                        positionThree = new Position() { X = max, Y = 0, Z = fixedValue };
                        positionFour = new Position() { X = max, Y = max, Z = fixedValue };
                        break;
                    case RubiksDirection.Left:
                        fixedValue = layer;
                        positionOne = new Position() { X = fixedValue, Y = max, Z = 0 };
                        positionTwo = new Position() { X = fixedValue, Y = max, Z = max };
                        positionThree = new Position() { X = fixedValue, Y = 0, Z = max };
                        positionFour = new Position() { X = fixedValue, Y = 0, Z = 0 };
                        break;
                    case RubiksDirection.Right:
                        fixedValue = _parentCubeSize - 1 - layer;
                        positionOne = new Position() { X = fixedValue, Y = max, Z = 0 };
                        positionTwo = new Position() { X = fixedValue, Y = max, Z = max };
                        positionThree = new Position() { X = fixedValue, Y = 0, Z = max };
                        positionFour = new Position() { X = fixedValue, Y = 0, Z = 0 };
                        break;
                    default:
                        break;
                }

                HashSet<Position> squarePoints = new HashSet<Position>();
                PositionMover mover = new PositionMover(positionOne, positionOne, positionTwo, positionThree, positionFour);
                squarePoints.Add(positionOne);
                Position next = new Position() { X = -1, Y = -1, Z = -1 };
                while (!next.Equals(positionOne))
                {
                    next = mover.Move(1);
                    if (!next.Equals(positionOne))
                        squarePoints.Add(next);
                }
                squares.Add
                    (
                        new Square()
                        {
                            PositionOne = positionOne,
                            PositionTwo = positionTwo,
                            PositionThree = positionThree,
                            PositionFour = positionFour,
                            PositionsInSquare = squarePoints
                        }
                    );
            }
            return squares;
        }

        #endregion

        #region Methods\\Helpers

        private void InitializeStartingPoints(int cubeSize)
        {
            _startingPointsForVariousFaces.Add(RubiksDirection.Back, new Position() { X = 0, Y = 0, Z = 0 });
            _startingPointsForVariousFaces.Add(RubiksDirection.Front, new Position() { X = 0, Y = cubeSize - 1, Z = 0 });
            _startingPointsForVariousFaces.Add(RubiksDirection.Left, new Position() { X = 0, Y = 0, Z = 0 });
            _startingPointsForVariousFaces.Add(RubiksDirection.Right, new Position() { X = cubeSize - 1, Y = 0, Z = 0 });
            _startingPointsForVariousFaces.Add(RubiksDirection.Up, new Position() { X = 0, Y = 0, Z = cubeSize - 1 });
            _startingPointsForVariousFaces.Add(RubiksDirection.Down, new Position() { X = 0, Y = 0, Z = 0 });

        }

        private void InitializeCubiePositions(int parentCubeSize)
        {
            List<Axes> includedAxes = new List<Axes>();

            switch (FaceDirection)
            {
                case RubiksDirection.Front:
                    includedAxes.Add(Axes.X);
                    includedAxes.Add(Axes.Z);
                    break;
                case RubiksDirection.Back:
                    includedAxes.Add(Axes.X);
                    includedAxes.Add(Axes.Z);
                    break;
                case RubiksDirection.Up:
                    includedAxes.Add(Axes.X);
                    includedAxes.Add(Axes.Y);
                    break;
                case RubiksDirection.Down:
                    includedAxes.Add(Axes.X);
                    includedAxes.Add(Axes.Y);
                    break;
                case RubiksDirection.Left:
                    includedAxes.Add(Axes.Y);
                    includedAxes.Add(Axes.Z);
                    break;
                case RubiksDirection.Right:
                    includedAxes.Add(Axes.Y);
                    includedAxes.Add(Axes.Z);
                    break;
                default:
                    break;
            }

            Position startingPoint = _startingPointsForVariousFaces[FaceDirection];

            for (int i = 0; i < parentCubeSize; i++)
            {
                for (int j = 0; j < parentCubeSize; j++)
                {
                    Queue<int> coordinates = new Queue<int>();
                    coordinates.Enqueue(i);
                    coordinates.Enqueue(j);
                    Position position = new Position();

                    if (includedAxes.Contains(Axes.X))
                    {
                        position.X = coordinates.Dequeue();
                    }
                    else
                    {
                        position.X = startingPoint.X;
                    }
                    if (includedAxes.Contains(Axes.Y))
                    {
                        position.Y = coordinates.Dequeue();
                    }
                    else
                    {
                        position.Y = startingPoint.Y;
                    }
                    if (includedAxes.Contains(Axes.Z))
                    {
                        position.Z = coordinates.Dequeue();
                    }
                    else
                    {
                        position.Z = startingPoint.Z;
                    }
                    _positions.Add(position);
                }
            }
        } 

        #endregion
    }
}