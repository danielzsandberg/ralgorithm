using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCore
{
    /// <summary>
    /// Returns cubies in their solved state
    /// </summary>
    public class SolvedPuzzleCubieConfigurator : ICubieConfigurator
    {
        readonly RubiksColor _frontColor;
        readonly RubiksColor _backColor;
        readonly RubiksColor _rightColor;
        readonly RubiksColor _leftColor;
        readonly RubiksColor _upColor;
        readonly RubiksColor _downColor;
        readonly IDictionary<RubiksDirection,Func<RelativePosition, Position, Cubie>> _cubieCreators;

        public SolvedPuzzleCubieConfigurator(RubiksColor frontColor = RubiksColor.White, RubiksColor backColor = RubiksColor.Yellow, RubiksColor rightColor = RubiksColor.Green, RubiksColor leftColor = RubiksColor.Blue, RubiksColor upColor = RubiksColor.Red, RubiksColor downColor = RubiksColor.Orange)
        {
            _frontColor = frontColor;
            _backColor = backColor;
            _rightColor = rightColor;
            _leftColor = leftColor;
            _upColor = upColor;
            _downColor = downColor;

            _cubieCreators = new Dictionary<RubiksDirection,Func<RelativePosition, Position, Cubie>>()
            {
                {RubiksDirection.Front, CreateFrontCubie},
                {RubiksDirection.Back, CreateBackCubie},
                {RubiksDirection.Right, CreateRightCubie},
                {RubiksDirection.Left, CreateLeftCubie},
                {RubiksDirection.Up, CreateUpCubie},
                {RubiksDirection.Down, CreateDownCubie}
            };
        }

        public IEnumerable<Cubie> CreateCubies(int cubeSize)
        {
            CubeFace frontFace = new CubeFace(RubiksDirection.Front, cubeSize);
            CubeFace backFace = new CubeFace(RubiksDirection.Back, cubeSize);
            CubeFace rightFace = new CubeFace(RubiksDirection.Right, cubeSize);
            CubeFace leftFace = new CubeFace(RubiksDirection.Left, cubeSize);
            CubeFace upFace = new CubeFace(RubiksDirection.Up, cubeSize);
            CubeFace downFace = new CubeFace(RubiksDirection.Down, cubeSize);

            HashSet<Cubie> cubies = new HashSet<Cubie>();

            PopulateSingleFaceCubies(frontFace, ref cubies);
            PopulateDoubleAndTripleFaceCubies(frontFace, ref cubies);

            PopulateSingleFaceCubies(backFace, ref cubies);
            PopulateDoubleAndTripleFaceCubies(backFace, ref cubies);

            PopulateSingleFaceCubies(rightFace, ref cubies);
            PopulateDoubleAndTripleFaceCubies(rightFace, ref cubies);

            PopulateSingleFaceCubies(leftFace, ref cubies);
            PopulateDoubleAndTripleFaceCubies(leftFace, ref cubies);

            PopulateSingleFaceCubies(upFace, ref cubies);
            //PopulateDoubleAndTripleFaceCubies(upFace, ref cubies); //Unnecessary computation

            PopulateSingleFaceCubies(downFace, ref cubies);
            //PopulateDoubleAndTripleFaceCubies(downFace, ref cubies); //Unnecessary computation

            HashSet<Position> allPositions = new HashSet<Position>(frontFace.GetPositionsOfLayersBeneathFace(cubeSize - 1));
            IEnumerable<Position> existingPositions = cubies.Select(cube => cube.Position);

            allPositions.ExceptWith(existingPositions);

            foreach(Position position in allPositions)
            {
                cubies.Add
                    (   
                        new Cubie
                        (
                            frontSide: null,
                            backSide: null,
                            rightSide: null,
                            leftSide: null,
                            upSide: null,
                            downSide: null,
                            postion: position
                        )
                    );
            }

            return cubies;
        }

        private void PopulateSingleFaceCubies(CubeFace face, ref HashSet<Cubie> cubies)
        {
            Square square = face.GetSquares(0).First();

            HashSet<Position> allFacePositions = new HashSet<Position>(face.CubiePositions);
            allFacePositions.ExceptWith(square.PositionsInSquare);

            foreach (Position position in allFacePositions)
            {
                Cubie singleFacedCubie = null;
                switch (face.FaceDirection)
                {
                    case RubiksDirection.Front:
                        singleFacedCubie = new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: null,
                            leftSide: null,
                            upSide: null,
                            downSide: null,
                            postion: position
                        );
                        break;
                    case RubiksDirection.Back:
                        singleFacedCubie = new Cubie
                        (
                            frontSide: null,
                            backSide: _backColor,
                            rightSide: null,
                            leftSide: null,
                            upSide: null,
                            downSide: null,
                            postion: position
                        );
                        break;
                    case RubiksDirection.Up:
                        singleFacedCubie = new Cubie
                        (
                            frontSide: null,
                            backSide: null,
                            rightSide: null,
                            leftSide: null,
                            upSide: _upColor,
                            downSide: null,
                            postion: position
                        );
                        break;
                    case RubiksDirection.Down:
                        singleFacedCubie = new Cubie
                        (
                            frontSide: null,
                            backSide: null,
                            rightSide: null,
                            leftSide: null,
                            upSide: null,
                            downSide: _downColor,
                            postion: position
                        );
                        break;
                    case RubiksDirection.Left:
                        singleFacedCubie = new Cubie
                        (
                            frontSide: null,
                            backSide: null,
                            rightSide: null,
                            leftSide: _leftColor,
                            upSide: null,
                            downSide: null,
                            postion: position
                        );
                        break;
                    case RubiksDirection.Right:
                        singleFacedCubie = new Cubie
                        (
                            frontSide: null,
                            backSide: null,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: null,
                            downSide: null,
                            postion: position
                        );
                        break;
                    default:
                        break;
                }

                cubies.Add(singleFacedCubie);
            }
        }

        private void PopulateDoubleAndTripleFaceCubies(CubeFace face, ref HashSet<Cubie> cubies)
        {
            PositionMover faceMover = new PositionMover(face.GetSquares(0).First());
            Func<RelativePosition, Position, Cubie> cubieCreator = _cubieCreators[face.FaceDirection];
            do
            {
                faceMover.Move(1);
                cubies.Add(cubieCreator(faceMover.CurrentRelativePosition, faceMover.CurrentPosition));
            }
            while (faceMover.CurrentRelativePosition != RelativePosition.OnPointOne);
        }

        private Cubie CreateFrontCubie(RelativePosition relativePosition, Position cubiePosition)
        {
            switch (relativePosition)
            {
                case RelativePosition.OnPointOne:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: null,
                            leftSide: _leftColor,
                            upSide: null,
                            downSide: _downColor,
                            postion: cubiePosition
                        );
                case RelativePosition.Between1and2:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: null,
                            leftSide: _leftColor,
                            upSide: null,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.OnPointTwo:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: null,
                            leftSide: _leftColor,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.Between2and3:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: null,
                            leftSide: null,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.OnPointThree:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.Between3and4:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: null,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.OnPointFour:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: null,
                            downSide: _downColor,
                            postion: cubiePosition
                        );
                case RelativePosition.Between4and1:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: null,
                            leftSide: null,
                            upSide: null,
                            downSide: _downColor,
                            postion: cubiePosition
                        );
                default:
                    return null;
            }
        }

        private Cubie CreateBackCubie(RelativePosition relativePosition, Position cubiePosition)
        {
            Cubie frontCubie = CreateFrontCubie(relativePosition, cubiePosition);
            return new Cubie
                        (
                            frontSide: null,
                            backSide: _backColor,
                            rightSide: frontCubie.RightSide,
                            leftSide: frontCubie.LeftSide,
                            upSide: frontCubie.UpSide,
                            downSide: frontCubie.DownSide,
                            postion: cubiePosition
                        );
        }
        
        private Cubie CreateRightCubie(RelativePosition relativePosition, Position cubiePosition)
        {
            switch (relativePosition)
            {
                case RelativePosition.OnPointOne:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: null,
                            downSide: _downColor,
                            postion: cubiePosition
                        );
                case RelativePosition.Between1and2:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: null,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.OnPointTwo:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.Between2and3:
                    return new Cubie
                        (
                            frontSide: null,
                            backSide: null,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.OnPointThree:
                    return new Cubie
                        (
                            frontSide: null,
                            backSide: _backColor,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.Between3and4:
                    return new Cubie
                        (
                            frontSide: null,
                            backSide: _backColor,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: null,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.OnPointFour:
                    return new Cubie
                        (
                            frontSide: null,
                            backSide: _backColor,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: null,
                            downSide: _downColor,
                            postion: cubiePosition
                        );
                case RelativePosition.Between4and1:
                    return new Cubie
                        (
                            frontSide: null,
                            backSide: null,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: null,
                            downSide: _downColor,
                            postion: cubiePosition
                        );
                default:
                    return null;
            }
        }

        private Cubie CreateLeftCubie(RelativePosition relativePosition, Position cubiePosition)
        {
            Cubie rightCubie = CreateRightCubie(relativePosition, cubiePosition);
            return new Cubie
                        (
                            frontSide: rightCubie.FrontSide,
                            backSide: rightCubie.BackSide,
                            rightSide: null,
                            leftSide: _leftColor,
                            upSide: rightCubie.UpSide,
                            downSide: rightCubie.DownSide,
                            postion: cubiePosition
                        );
        }

        private Cubie CreateUpCubie(RelativePosition relativePosition, Position cubiePosition)
        {
            switch (relativePosition)
            {
                case RelativePosition.OnPointOne:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: null,
                            leftSide: _leftColor,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.Between1and2:
                    return new Cubie
                        (
                            frontSide: null,
                            backSide: null,
                            rightSide: null,
                            leftSide: _leftColor,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.OnPointTwo:
                    return new Cubie
                        (
                            frontSide: null,
                            backSide: _backColor,
                            rightSide: null,
                            leftSide: _leftColor,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.Between2and3:
                    return new Cubie
                        (
                            frontSide: null,
                            backSide: _backColor,
                            rightSide: null,
                            leftSide: null,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.OnPointThree:
                    return new Cubie
                        (
                            frontSide: null,
                            backSide: _backColor,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.Between3and4:
                    return new Cubie
                        (
                            frontSide: null,
                            backSide: null,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.OnPointFour:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: _rightColor,
                            leftSide: null,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                case RelativePosition.Between4and1:
                    return new Cubie
                        (
                            frontSide: _frontColor,
                            backSide: null,
                            rightSide: null,
                            leftSide: null,
                            upSide: _upColor,
                            downSide: null,
                            postion: cubiePosition
                        );
                default:
                    return null;
            }
        }

        private Cubie CreateDownCubie(RelativePosition relativePosition, Position cubiePosition)
        {
            Cubie upCubie = CreateUpCubie(relativePosition, cubiePosition);
            return new Cubie
                        (
                            frontSide: upCubie.FrontSide,
                            backSide: upCubie.BackSide,
                            rightSide: upCubie.RightSide,
                            leftSide: upCubie.LeftSide,
                            upSide: null,
                            downSide: _downColor,
                            postion: cubiePosition
                        );
        }
    }
}