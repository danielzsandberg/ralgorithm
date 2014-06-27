using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RubiksCore.Test
{
    [TestClass]
    public class CubieTests
    {
        [TestMethod]
        public void Move_WhenAxisOfRotationIsYAndDirectionIs3oClock_ThenTheAppropriateFaceAreShifted()
        {
            Cubie cubie = new Cubie
                    (
                        frontSide: RubiksColor.White,
                        backSide: null,
                        rightSide: RubiksColor.Red,
                        leftSide: null,
                        upSide: RubiksColor.Blue,
                        downSide: null,
                        postion:
                            new Position()
                            {
                                X = 3,
                                Y = 3,
                                Z = 3
                            }
                    );

            cubie.Move(new Position() { X = 3, Y = 3, Z = 0 }, Axes.Y, TurningDirection.ThreeoClock);

            Cubie expectedCubie = new Cubie
                    (
                        frontSide: RubiksColor.White,
                        backSide: null,
                        rightSide: RubiksColor.Blue,
                        leftSide: null,
                        upSide: null,
                        downSide: RubiksColor.Red,
                        postion:
                            new Position()
                            {
                                X = 3,
                                Y = 3,
                                Z = 0
                            }
                    );

            Assert.AreEqual<Cubie>(expectedCubie, cubie);
        }

        [TestMethod]
        public void Move_WhenAxisOfRotationIsYAndDirectionIs6oClock_ThenTheAppropriateFaceAreShifted()
        {
            Cubie cubie = new Cubie
                    (
                        frontSide: RubiksColor.White,
                        backSide: null,
                        rightSide: RubiksColor.Red,
                        leftSide: null,
                        upSide: RubiksColor.Blue,
                        downSide: null,
                        postion:
                            new Position()
                            {
                                X = 3,
                                Y = 3,
                                Z = 3
                            }
                    );

            cubie.Move(new Position() { X = 0, Y = 3, Z = 0 }, Axes.Y, TurningDirection.SixoClock);

            Cubie expectedCubie = new Cubie
                    (
                        frontSide: RubiksColor.White,
                        backSide: null,
                        rightSide: null,
                        leftSide: RubiksColor.Red,
                        upSide: null,
                        downSide: RubiksColor.Blue,
                        postion:
                            new Position()
                            {
                                X = 0,
                                Y = 3,
                                Z = 0
                            }
                    );

            Assert.AreEqual<Cubie>(expectedCubie, cubie);
        }

        [TestMethod]
        public void Move_WhenAxisOfRotationIsYAndDirectionIs9oClock_ThenTheAppropriateFaceAreShifted()
        {
            Cubie cubie = new Cubie
                    (
                        frontSide: RubiksColor.White,
                        backSide: null,
                        rightSide: RubiksColor.Red,
                        leftSide: null,
                        upSide: RubiksColor.Blue,
                        downSide: null,
                        postion:
                            new Position()
                            {
                                X = 3,
                                Y = 3,
                                Z = 3
                            }
                    );

            cubie.Move(new Position() { X = 0, Y = 3, Z = 3 }, Axes.Y, TurningDirection.NineoClock);

            Cubie expectedCubie = new Cubie
                    (
                        frontSide: RubiksColor.White,
                        backSide: null,
                        rightSide: null,
                        leftSide: RubiksColor.Blue,
                        upSide: RubiksColor.Red,
                        downSide: null,
                        postion:
                            new Position()
                            {
                                X = 0,
                                Y = 3,
                                Z = 3
                            }
                    );

            Assert.AreEqual<Cubie>(expectedCubie, cubie);
        }

        [TestMethod]
        public void Move_WhenAxisOfRotationIsXAndDirectionIs3oClock_ThenTheAppropriateFaceAreShifted()
        {
            Cubie cubie = new Cubie
                    (
                        frontSide: RubiksColor.White,
                        backSide: null,
                        rightSide: RubiksColor.Red,
                        leftSide: null,
                        upSide: RubiksColor.Blue,
                        downSide: null,
                        postion:
                            new Position()
                            {
                                X = 3,
                                Y = 3,
                                Z = 3
                            }
                    );

            cubie.Move(new Position() { X = 3, Y = 0, Z = 3 }, Axes.X, TurningDirection.ThreeoClock);

            Cubie expectedCubie = new Cubie
                    (
                        frontSide: null,
                        backSide: RubiksColor.Blue,
                        rightSide: RubiksColor.Red,
                        leftSide: null,
                        upSide: RubiksColor.White,
                        downSide: null,
                        postion:
                            new Position()
                            {
                                X = 3,
                                Y = 0,
                                Z = 3
                            }
                    );

            Assert.AreEqual<Cubie>(expectedCubie, cubie);
        }

        [TestMethod]
        public void Move_WhenAxisOfRotationIsXAndDirectionIs6oClock_ThenTheAppropriateFaceAreShifted()
        {
            Cubie cubie = new Cubie
                       (
                           frontSide: RubiksColor.White,
                           backSide: null,
                           rightSide: RubiksColor.Red,
                           leftSide: null,
                           upSide: RubiksColor.Blue,
                           downSide: null,
                           postion:
                               new Position()
                               {
                                   X = 3,
                                   Y = 3,
                                   Z = 3
                               }
                       );

            cubie.Move(new Position() { X = 3, Y = 0, Z = 0 }, Axes.X, TurningDirection.SixoClock);

            Cubie expectedCubie = new Cubie
                    (
                        frontSide: null,
                        backSide: RubiksColor.White,
                        rightSide: RubiksColor.Red,
                        leftSide: null,
                        upSide: null,
                        downSide: RubiksColor.Blue,
                        postion:
                            new Position()
                            {
                                X = 3,
                                Y = 0,
                                Z = 0
                            }
                    );

            Assert.AreEqual<Cubie>(expectedCubie, cubie);
        }

        [TestMethod]
        public void Move_WhenAxisOfRotationIsXAndDirectionIs9oClock_ThenTheAppropriateFaceAreShifted()
        {
            Cubie cubie = new Cubie
                       (
                           frontSide: RubiksColor.White,
                           backSide: null,
                           rightSide: RubiksColor.Red,
                           leftSide: null,
                           upSide: RubiksColor.Blue,
                           downSide: null,
                           postion:
                               new Position()
                               {
                                   X = 3,
                                   Y = 3,
                                   Z = 3
                               }
                       );

            cubie.Move(new Position() { X = 3, Y = 3, Z = 0 }, Axes.X, TurningDirection.NineoClock);

            Cubie expectedCubie = new Cubie
                    (
                        frontSide: RubiksColor.Blue,
                        backSide: null,
                        rightSide: RubiksColor.Red,
                        leftSide: null,
                        upSide: null,
                        downSide: RubiksColor.White,
                        postion:
                            new Position()
                            {
                                X = 3,
                                Y = 3,
                                Z = 0
                            }
                    );

            Assert.AreEqual<Cubie>(expectedCubie, cubie);
        }

        [TestMethod]
        public void Move_WhenAxisOfRotationIsZAndDirectionIs3oClock_ThenTheAppropriateFaceAreShifted()
        {
            Cubie cubie = new Cubie
                       (
                           frontSide: RubiksColor.White,
                           backSide: null,
                           rightSide: RubiksColor.Red,
                           leftSide: null,
                           upSide: RubiksColor.Blue,
                           downSide: null,
                           postion:
                               new Position()
                               {
                                   X = 3,
                                   Y = 3,
                                   Z = 3
                               }
                       );

            cubie.Move(new Position() { X = 0, Y = 3, Z = 3 }, Axes.Z, TurningDirection.ThreeoClock);

            Cubie expectedCubie = new Cubie
                    (
                        frontSide: RubiksColor.Red,
                        backSide: null,
                        rightSide: null,
                        leftSide: RubiksColor.White,
                        upSide: RubiksColor.Blue,
                        downSide: null,
                        postion:
                            new Position()
                            {
                                X = 0,
                                Y = 3,
                                Z = 3
                            }
                    );

            Assert.AreEqual<Cubie>(expectedCubie, cubie);
        }

        [TestMethod]
        public void Move_WhenAxisOfRotationIsZAndDirectionIs6oClock_ThenTheAppropriateFaceAreShifted()
        {
            Cubie cubie = new Cubie
                       (
                           frontSide: RubiksColor.White,
                           backSide: null,
                           rightSide: RubiksColor.Red,
                           leftSide: null,
                           upSide: RubiksColor.Blue,
                           downSide: null,
                           postion:
                               new Position()
                               {
                                   X = 3,
                                   Y = 3,
                                   Z = 3
                               }
                       );

            cubie.Move(new Position() { X = 0, Y = 0, Z = 3 }, Axes.Z, TurningDirection.SixoClock);

            Cubie expectedCubie = new Cubie
                    (
                        frontSide: null,
                        backSide: RubiksColor.White,
                        rightSide: null,
                        leftSide: RubiksColor.Red,
                        upSide: RubiksColor.Blue,
                        downSide: null,
                        postion:
                            new Position()
                            {
                                X = 0,
                                Y = 0,
                                Z = 3
                            }
                    );

            Assert.AreEqual<Cubie>(expectedCubie, cubie);
        }

        [TestMethod]
        public void Move_WhenAxisOfRotationIsZAndDirectionIs9oClock_ThenTheAppropriateFaceAreShifted()
        {
            Cubie cubie = new Cubie
                       (
                           frontSide: RubiksColor.White,
                           backSide: null,
                           rightSide: RubiksColor.Red,
                           leftSide: null,
                           upSide: RubiksColor.Blue,
                           downSide: null,
                           postion:
                               new Position()
                               {
                                   X = 3,
                                   Y = 3,
                                   Z = 3
                               }
                       );

            cubie.Move(new Position() { X = 3, Y = 0, Z = 3 }, Axes.Z, TurningDirection.NineoClock);

            Cubie expectedCubie = new Cubie
                    (
                        frontSide: null,
                        backSide: RubiksColor.Red,
                        rightSide: RubiksColor.White,
                        leftSide: null,
                        upSide: RubiksColor.Blue,
                        downSide: null,
                        postion:
                            new Position()
                            {
                                X = 3,
                                Y = 0,
                                Z = 3
                            }
                    );

            Assert.AreEqual<Cubie>(expectedCubie, cubie);
        }

        [TestMethod]
        public void Equality_WhenThereIsALargeListOfUniqueCubies_ThenTheFinalCountInTheHashSetShouldBe27()
        {
            #region 27 Cube Configuration

            Cubie cubie000 = new Cubie
                    (
                        frontSide: null,
                        backSide: RubiksColor.Green,
                        rightSide: null,
                        leftSide: RubiksColor.Yellow,
                        upSide: null,
                        downSide: RubiksColor.Orange,
                        postion:
                            new Position()
                            {
                                X = 0,
                                Y = 0,
                                Z = 0
                            }
                    );

            Cubie cubie100 = new Cubie
                (
                    frontSide: null,
                    backSide: RubiksColor.Green,
                    rightSide: null,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Orange,
                    postion:
                        new Position()
                        {
                            X = 1,
                            Y = 0,
                            Z = 0
                        }
                );

            Cubie cubie200 = new Cubie
                (
                    frontSide: null,
                    backSide: RubiksColor.Green,
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Orange,
                    postion:
                        new Position()
                        {
                            X = 2,
                            Y = 0,
                            Z = 0
                        }
                );

            Cubie cubie010 = new Cubie
                (
                    frontSide: null,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.Yellow,
                    upSide: null,
                    downSide: RubiksColor.Orange,
                    postion:
                        new Position()
                        {
                            X = 0,
                            Y = 1,
                            Z = 0
                        }
                );

            Cubie cubie110 = new Cubie
                (
                    frontSide: null,
                    backSide: null,
                    rightSide: null,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Orange,
                    postion:
                        new Position()
                        {
                            X = 1,
                            Y = 1,
                            Z = 0
                        }
                );

            Cubie cubie210 = new Cubie
                (
                    frontSide: null,
                    backSide: null,
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Orange,
                    postion:
                        new Position()
                        {
                            X = 2,
                            Y = 1,
                            Z = 0
                        }
                );

            Cubie cubie020 = new Cubie
                (
                    frontSide: RubiksColor.Blue,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.Orange,
                    upSide: null,
                    downSide: RubiksColor.White,
                    postion:
                        new Position()
                        {
                            X = 0,
                            Y = 2,
                            Z = 0
                        }
                );

            Cubie cubie120 = new Cubie
                (
                    frontSide: RubiksColor.Blue,
                    backSide: null,
                    rightSide: null,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.White,
                    postion:
                        new Position()
                        {
                            X = 1,
                            Y = 2,
                            Z = 0
                        }
                );

            Cubie cubie220 = new Cubie
                (
                    frontSide: RubiksColor.Blue,
                    backSide: null,
                    rightSide: RubiksColor.Red,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.White,
                    postion:
                        new Position()
                        {
                            X = 2,
                            Y = 2,
                            Z = 0
                        }
                );

            //z = 1

            Cubie cubie001 = new Cubie
                (
                    frontSide: null,
                    backSide: RubiksColor.Green,
                    rightSide: null,
                    leftSide: RubiksColor.Yellow,
                    upSide: null,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 0,
                            Y = 0,
                            Z = 1
                        }
                );

            Cubie cubie101 = new Cubie
                (
                    frontSide: null,
                    backSide: RubiksColor.Green,
                    rightSide: null,
                    leftSide: null,
                    upSide: null,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 1,
                            Y = 0,
                            Z = 1
                        }
                );

            Cubie cubie201 = new Cubie
                (
                    frontSide: null,
                    backSide: RubiksColor.Green,
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: null,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 2,
                            Y = 0,
                            Z = 1
                        }
                );

            Cubie cubie011 = new Cubie
                (
                    frontSide: null,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.Yellow,
                    upSide: null,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 0,
                            Y = 1,
                            Z = 1
                        }
                );

            Cubie cubie111 = new Cubie
                (
                    frontSide: null,
                    backSide: null,
                    rightSide: null,
                    leftSide: null,
                    upSide: null,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 1,
                            Y = 1,
                            Z = 1
                        }
                );

            Cubie cubie211 = new Cubie
                (
                    frontSide: null,
                    backSide: null,
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: null,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 2,
                            Y = 1,
                            Z = 1
                        }
                );

            Cubie cubie021 = new Cubie
                (
                    frontSide: RubiksColor.Blue,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.Orange,
                    upSide: null,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 0,
                            Y = 2,
                            Z = 1
                        }
                );

            Cubie cubie121 = new Cubie
                (
                    frontSide: RubiksColor.Blue,
                    backSide: null,
                    rightSide: null,
                    leftSide: null,
                    upSide: null,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 1,
                            Y = 2,
                            Z = 1
                        }
                );

            Cubie cubie221 = new Cubie
                (
                    frontSide: RubiksColor.Blue,
                    backSide: null,
                    rightSide: RubiksColor.Red,
                    leftSide: null,
                    upSide: null,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 2,
                            Y = 2,
                            Z = 1
                        }
                );

            //z = 2
            Cubie cubie002 = new Cubie
                (
                    frontSide: null,
                    backSide: RubiksColor.Green,
                    rightSide: null,
                    leftSide: RubiksColor.Yellow,
                    upSide: RubiksColor.Red,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 0,
                            Y = 0,
                            Z = 2
                        }
                );

            Cubie cubie102 = new Cubie
                (
                    frontSide: null,
                    backSide: RubiksColor.Green,
                    rightSide: null,
                    leftSide: null,
                    upSide: RubiksColor.Red,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 1,
                            Y = 0,
                            Z = 2
                        }
                );

            Cubie cubie202 = new Cubie
                (
                    frontSide: null,
                    backSide: RubiksColor.Green,
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: RubiksColor.Red,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 2,
                            Y = 0,
                            Z = 2
                        }
                );

            Cubie cubie012 = new Cubie
                (
                    frontSide: null,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.Yellow,
                    upSide: RubiksColor.Red,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 0,
                            Y = 1,
                            Z = 2
                        }
                );

            Cubie cubie112 = new Cubie
                (
                    frontSide: null,
                    backSide: null,
                    rightSide: null,
                    leftSide: null,
                    upSide: RubiksColor.Red,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 1,
                            Y = 1,
                            Z = 2
                        }
                );

            Cubie cubie212 = new Cubie
                (
                    frontSide: null,
                    backSide: null,
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: RubiksColor.Red,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 2,
                            Y = 1,
                            Z = 2
                        }
                );

            Cubie cubie022 = new Cubie
                (
                    frontSide: RubiksColor.Blue,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.Orange,
                    upSide: RubiksColor.Yellow,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 0,
                            Y = 2,
                            Z = 2
                        }
                );

            Cubie cubie122 = new Cubie
                (
                    frontSide: RubiksColor.Blue,
                    backSide: null,
                    rightSide: null,
                    leftSide: null,
                    upSide: RubiksColor.Yellow,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 1,
                            Y = 2,
                            Z = 2
                        }
                );

            Cubie cubie222 = new Cubie
                (
                    frontSide: RubiksColor.Blue,
                    backSide: null,
                    rightSide: RubiksColor.Red,
                    leftSide: null,
                    upSide: RubiksColor.Yellow,
                    downSide: null,
                    postion:
                        new Position()
                        {
                            X = 2,
                            Y = 2,
                            Z = 2
                        }
                );

            #endregion

            HashSet<Cubie> expectedCubies = new HashSet<Cubie>() 
            { 
                //z=0
                cubie000, cubie100, cubie200, cubie010, cubie110, cubie210, cubie020, cubie120, cubie220,
 
                //z=1
                cubie001, cubie101, cubie201, cubie011, cubie111, cubie211, cubie021, cubie121, cubie221,

                //z = 2
                cubie002, cubie102, cubie202, cubie012, cubie112, cubie212, cubie022, cubie122, cubie222
            };

            Assert.AreEqual<int>(27, expectedCubies.Count);
        }
    }
}
