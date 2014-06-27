using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCore
{
    class PositionMover
    {
        #region Instance Variables

        private Position _pointToMove;
        private Position _squarePointOne;
        private Position _squarePointTwo;
        private Position _squarePointThree;
        private Position _squarePointFour;
        private Axes _axisOfRotation;

        #endregion

        #region Properties

        public Position CurrentPosition
        {
            get
            {
                return _pointToMove;
            }
        }

        public RelativePosition CurrentRelativePosition
        {
            get
            {
                return DetermineRelativePosition(_pointToMove);
            }
        }

        #endregion

        #region Constructors

        public PositionMover(Position pointToMove, Position squarePointOne, Position squarePointTwo, Position squarePointThree, Position squarePointFour)
        {
            _pointToMove = pointToMove;
            _squarePointOne = squarePointOne;
            _squarePointTwo = squarePointTwo;
            _squarePointThree = squarePointThree;
            _squarePointFour = squarePointFour;

            if (squarePointOne.X == _squarePointTwo.X && squarePointTwo.X == squarePointThree.X && squarePointThree.X == squarePointFour.X)
            {
                _axisOfRotation = Axes.X;
            }

            if (squarePointOne.Y == _squarePointTwo.Y && squarePointTwo.Y == squarePointThree.Y && squarePointThree.Y == squarePointFour.Y)
            {
                _axisOfRotation = Axes.Y;
            }

            if (squarePointOne.Z == _squarePointTwo.Z && squarePointTwo.Z == squarePointThree.Z && squarePointThree.Z == squarePointFour.Z)
            {
                _axisOfRotation = Axes.Z;
            }


        }

        public PositionMover(Square square)
            : this(square.PositionOne, square.PositionOne, square.PositionTwo, square.PositionThree, square.PositionFour)
        {

        }
        #endregion

        #region Methods

        public Position Move(int positionsToMove)
        {
            for (int i = 0; i < positionsToMove; i++)
            {
                Move();
            }

            return _pointToMove;
        }

        private void Move()
        {
            RelativePosition currentRelativePosition = DetermineRelativePosition(_pointToMove);
            switch (currentRelativePosition)
            {
                case RelativePosition.OnPointOne:
                    MoveUp();
                    break;
                case RelativePosition.Between1and2:
                    MoveUp();
                    break;
                case RelativePosition.OnPointTwo:
                    MoveRight();
                    break;
                case RelativePosition.Between2and3:
                    MoveRight();
                    break;
                case RelativePosition.OnPointThree:
                    MoveDown();
                    break;
                case RelativePosition.Between3and4:
                    MoveDown();
                    break;
                case RelativePosition.OnPointFour:
                    MoveLeft();
                    break;
                case RelativePosition.Between4and1:
                    MoveLeft();
                    break;
                default:
                    break;
            }
        }

        private void MoveUp()
        {
            switch (_axisOfRotation)
            {
                case Axes.X:
                    _pointToMove.Z++;
                    break;
                case Axes.Y:
                    _pointToMove.Z++;
                    break;
                case Axes.Z:
                    _pointToMove.Y--;
                    break;
                default:
                    break;
            }
        }

        private void MoveRight()
        {
            switch (_axisOfRotation)
            {
                case Axes.X:
                    _pointToMove.Y--;
                    break;
                case Axes.Y:
                    _pointToMove.X++;
                    break;
                case Axes.Z:
                    _pointToMove.X++;
                    break;
                default:
                    break;
            }
        }

        private void MoveDown()
        {
            switch (_axisOfRotation)
            {
                case Axes.X:
                    _pointToMove.Z--;
                    break;
                case Axes.Y:
                    _pointToMove.Z--;
                    break;
                case Axes.Z:
                    _pointToMove.Y++;
                    break;
                default:
                    break;
            }
        }

        private void MoveLeft()
        {
            switch (_axisOfRotation)
            {
                case Axes.X:
                    _pointToMove.Y++;
                    break;
                case Axes.Y:
                    _pointToMove.X--;
                    break;
                case Axes.Z:
                    _pointToMove.X--;
                    break;
                default:
                    break;
            }
        }

        private RelativePosition DetermineRelativePosition(Position position)
        {
            if(position.Equals(_squarePointOne))
            {
                return RelativePosition.OnPointOne;
            }
            else if(position.Equals(_squarePointTwo))
            {
                return RelativePosition.OnPointTwo;
            }
            else if(position.Equals(_squarePointThree))
            {
                return RelativePosition.OnPointThree;
            }
            else if (position.Equals(_squarePointFour))
            {
                return RelativePosition.OnPointFour;
            }
            else
            {
                switch (_axisOfRotation)
                {
                    case Axes.X:
                        if (position.Z > _squarePointOne.Z && position.Z < _squarePointTwo.Z && position.Y == _squarePointOne.Y)
                        {
                            return RelativePosition.Between1and2;
                        }
                        else if (position.Y < _squarePointTwo.Y && position.Y > _squarePointThree.Y && position.Z == _squarePointTwo.Z)
                        {
                            return RelativePosition.Between2and3;
                        }
                        else if (position.Z < _squarePointThree.Z && position.Z > _squarePointFour.Z && position.Y == _squarePointThree.Y)
                        {
                            return RelativePosition.Between3and4;
                        }
                        else if (position.Y > _squarePointFour.Y && position.Y < _squarePointOne.Y && position.Z == _squarePointFour.Z)
                        {
                            return RelativePosition.Between4and1;
                        }
                        else
                        {
                            throw new InvalidOperationException("Cannot determine where point is.");
                        }
                    case Axes.Y:
                        if (position.Z > _squarePointOne.Z && position.Z < _squarePointTwo.Z && position.X == _squarePointOne.X)
                        {
                            return RelativePosition.Between1and2;
                        }
                        else if (position.X > _squarePointTwo.X && position.X < _squarePointThree.X && position.Z == _squarePointTwo.Z)
                        {
                            return RelativePosition.Between2and3;
                        }
                        else if (position.Z < _squarePointThree.Z && position.Z > _squarePointFour.Z && position.X == _squarePointThree.X)
                        {
                            return RelativePosition.Between3and4;
                        }
                        else if (position.X < _squarePointFour.X && position.X > _squarePointOne.X && _squarePointOne.Z == _squarePointFour.Z)
                        {
                            return RelativePosition.Between4and1;
                        }
                        else
                        {
                            throw new InvalidOperationException("Cannot determine where point is.");
                        }
                    case Axes.Z:
                        if (position.Y < _squarePointOne.Y && position.Y > _squarePointTwo.Y && position.X == _squarePointOne.X)
                        {
                            return RelativePosition.Between1and2;
                        }
                        else if (position.X > _squarePointTwo.X && position.X < _squarePointThree.X && position.Y == _squarePointTwo.Y)
                        {
                            return RelativePosition.Between2and3;
                        }
                        else if (position.Y > _squarePointThree.Y && position.Y < _squarePointFour.Y && position.X == _squarePointThree.X)
                        {
                            return RelativePosition.Between3and4;
                        }
                        else if (position.X < _squarePointFour.X && position.X > _squarePointOne.X && position.Y == _squarePointFour.Y)
                        {
                            return RelativePosition.Between4and1;
                        }
                        else
                        {
                            throw new InvalidOperationException("Cannot determine where point is");
                        }
                    default:
                        throw new InvalidOperationException("Cannot determine range with unknown axis of rotation.");
                }
            }
        }

        #endregion
    }
}