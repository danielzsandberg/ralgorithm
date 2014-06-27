using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace RubiksCore
{
    public class RubiksCube
    {
        #region Instance Variables

        private IDictionary<RubiksDirection, CubeFace> _faces;
        private INotationParser _parser = null;
        private IEnumerable<Cubie> _cubies;
        private int _cubeSize;

        #endregion

        #region Properties

        public Cubie this[int x, int y, int z]
        {
            get
            {
                Position requestedPosition = new Position() { X = x, Y = y, Z = z };

                Cubie cubie = _cubies.FirstOrDefault(cub => cub.Position.Equals(requestedPosition));

                if(cubie == null)
                {
                    throw new InvalidOperationException(string.Format("Could not find requested cube at {0}", requestedPosition));
                }
                else
                {
                    return cubie;
                }
            }
        }

        public Cubie this[Position pos]
        {
            get
            {
                return this[pos.X, pos.Y, pos.Z];
            }
        }

        public IEnumerable<Cubie> Cubies
        {
            get
            {
                return _cubies;
            }
        }

        public int CubeSize
        {
            get
            {
                return _cubeSize;
            }
        }

        #endregion

        #region Events

        public event EventHandler<GenericEventArgs<CubeTurnedEvent>> CubeTurned;

        private void OnCubeTurned(RubiksDirection side, TurningDirection direction, int numberOfLayersDeep)
        {
            EventHandler<GenericEventArgs<CubeTurnedEvent>> handler = CubeTurned;
            if(handler != null)
            {
                handler(this, new GenericEventArgs<CubeTurnedEvent>(new CubeTurnedEvent(side, direction, numberOfLayersDeep)));
            }
        }

        #endregion

        #region Methods \\ Basic Moves

        public void TurnFront(TurningDirection direction = TurningDirection.ThreeoClock, int layersDeep = 0)
        {
            Turn(RubiksDirection.Front, direction, layersDeep);
        }

        public void TurnBack(TurningDirection direction = TurningDirection.ThreeoClock, int layersDeep = 0)
        {
            Turn(RubiksDirection.Back, direction, layersDeep);
        }

        public void TurnRight(TurningDirection direction = TurningDirection.ThreeoClock, int layersDeep = 0)
        {
            Turn(RubiksDirection.Right, direction, layersDeep);
        }

        public void TurnLeft(TurningDirection direction = TurningDirection.ThreeoClock, int layersDeep = 0)
        {
            Turn(RubiksDirection.Left, direction, layersDeep);
        }

        public void TurnUp(TurningDirection direction = TurningDirection.ThreeoClock, int layersDeep = 0)
        {
            Turn(RubiksDirection.Up, direction, layersDeep);
        }

        public void TurnDown(TurningDirection direction = TurningDirection.ThreeoClock, int layersDeep = 0)
        {
            Turn(RubiksDirection.Down, direction, layersDeep);
        }

        #endregion

        #region Methods \\ Generic Turning Methods

        public void Turn(string turnNotation)
        {
            if(_parser == null)
            {
                throw new NotSupportedException();
            }
            else
            {
                KeyValuePair<RubiksDirection, TurningDirection>[] turns = _parser.ParseNotation(turnNotation);
                foreach(var turn in turns)
                {
                    Turn(turn.Key, turn.Value);
                }
            }
        }

        public void Turn(RubiksDirection side, TurningDirection direction = TurningDirection.ThreeoClock, int numberOfLayersDeep = 0)
        {
            TurningDirection modifiedDirection = direction;
            if(side == RubiksDirection.Back || side == RubiksDirection.Left || side == RubiksDirection.Down)
            {
                modifiedDirection = direction.InvertTurningDirection();
            }

            IDictionary<Position, Position> oldNewPositions = _faces[side].Move(modifiedDirection, numberOfLayersDeep);
            IEnumerable<KeyValuePair<Cubie, Position>> cubieToNewPositionPairs = oldNewPositions.Select
                (pair => new KeyValuePair<Cubie, Position>(this[pair.Key], pair.Value)).ToList();

            foreach (KeyValuePair<Cubie, Position> cubieToNewPositionPair in cubieToNewPositionPairs)
            {
                Cubie cubieToMove = cubieToNewPositionPair.Key;
                switch (side)
                {
                    case RubiksDirection.Front:
                        cubieToMove.Move(cubieToNewPositionPair.Value, Axes.Y, modifiedDirection);
                        break;
                    case RubiksDirection.Back:
                        cubieToMove.Move(cubieToNewPositionPair.Value, Axes.Y, modifiedDirection);
                        break;
                    case RubiksDirection.Up:
                        cubieToMove.Move(cubieToNewPositionPair.Value, Axes.Z, modifiedDirection);
                        break;
                    case RubiksDirection.Down:
                        cubieToMove.Move(cubieToNewPositionPair.Value, Axes.Z, modifiedDirection);
                        break;
                    case RubiksDirection.Left:
                        cubieToMove.Move(cubieToNewPositionPair.Value, Axes.X, modifiedDirection);
                        break;
                    case RubiksDirection.Right:
                        cubieToMove.Move(cubieToNewPositionPair.Value, Axes.X, modifiedDirection);
                        break;
                    default:
                        break;
                }
            }

            OnCubeTurned(side, direction, numberOfLayersDeep);
        }

        #endregion

        #region Methods\\Shuffle

        public void Shuffle(int numberOfTurns = 100)
        {
            Random rnd = new Random();

            for (int i = 0; i < numberOfTurns; i++)
            {
                int faceInt = rnd.Next(6);
                RubiksDirection face = default(RubiksDirection);
                if (faceInt == 0)
                    face = RubiksDirection.Back;
                else if (faceInt == 1)
                    face = RubiksDirection.Down;
                else if (faceInt == 2)
                    face = RubiksDirection.Front;
                else if (faceInt == 3)
                    face = RubiksDirection.Left;
                else if (faceInt == 4)
                    face = RubiksDirection.Right;
                else if (faceInt == 5)
                    face = RubiksDirection.Up;

                int turningDirectionInt = rnd.Next(3);
                TurningDirection turningDirection = default(TurningDirection);
                if (turningDirectionInt == 0)
                    turningDirection = TurningDirection.ThreeoClock;
                else if (turningDirectionInt == 1)
                    turningDirection = TurningDirection.SixoClock;
                else if (turningDirectionInt == 2)
                    turningDirection = TurningDirection.NineoClock;

                int numberOfLayersDeep = rnd.Next(CubeSize - 1);

                Turn(face, turningDirection, numberOfLayersDeep);
            }
        }

        #endregion

        #region Constructors

        public RubiksCube(int cubeSize = 3)
            : this(null, cubeSize)
        {

        }

        public RubiksCube(INotationParser parser, int cubeSize = 3)
            : this(parser, new SolvedPuzzleCubieConfigurator(), cubeSize)
        {
            
        }

        internal RubiksCube(INotationParser parser, ICubieConfigurator configurator, int cubeSize)
        {
            _faces = new Dictionary<RubiksDirection, CubeFace>();
            _faces.Add(RubiksDirection.Front, new CubeFace(RubiksDirection.Front, cubeSize));
            _faces.Add(RubiksDirection.Back, new CubeFace(RubiksDirection.Back, cubeSize));
            _faces.Add(RubiksDirection.Up, new CubeFace(RubiksDirection.Up, cubeSize));
            _faces.Add(RubiksDirection.Down, new CubeFace(RubiksDirection.Down, cubeSize));
            _faces.Add(RubiksDirection.Left, new CubeFace(RubiksDirection.Left, cubeSize));
            _faces.Add(RubiksDirection.Right, new CubeFace(RubiksDirection.Right, cubeSize));
            _cubeSize = cubeSize;

            _parser = parser;

            _cubies = configurator.CreateCubies(cubeSize);
        }

        #endregion

        #region Methods \\ Overrides

        public override string ToString()
        {
            StringBuilder cubeString = new StringBuilder();
            for(int z = 0; z < _cubeSize; z++)
            {
                for(int y = 0; y < _cubeSize; y++)
                {
                    for(int x = 0; x < _cubeSize; x++)
                    {
                        cubeString.AppendLine(this[x, y, z].ToString());
                    }
                }
            }
            return cubeString.ToString();
        }

        #endregion
    }
}

