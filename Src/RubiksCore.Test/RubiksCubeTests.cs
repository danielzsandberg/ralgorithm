using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RubiksCore.Test
{
    [TestClass]
    public class RubiksCubeTests
    {
        [TestMethod]
        public void TurnFront_WhenTurningDirectionIsThreeoClock_ThenAllCubesOnThatFaceShouldMove()
        {
            //setup
            int cubeSize = 3;
            RubiksCube cube = new RubiksCube(null, new TestConfigurator(), cubeSize);

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

            //exercise
            cube.TurnFront(TurningDirection.ThreeoClock);

            Assert.AreEqual<int>(27, cube.Cubies.Count(), "Cubie count is wrong");
            Assert.IsTrue(expectedCubies.SetEquals(cube.Cubies));
        }

        [TestMethod]
        public void TurnRight_WhenTurningDirectionIsThreeoClock_ThenAllCubesOnThatFaceShouldMove()
        {
            //setup
            int cubeSize = 3;
            RubiksCube cube = new RubiksCube(null, new TestConfigurator(), cubeSize);

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
                    backSide: RubiksColor.Red,
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Green,
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
                    downSide: RubiksColor.Green,
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
                    leftSide: RubiksColor.Yellow,
                    upSide: null,
                    downSide: RubiksColor.Orange,
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
                    downSide: RubiksColor.Orange,
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
                    frontSide: RubiksColor.Orange,
                    backSide: null,
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Green,
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
                    backSide: RubiksColor.Red,
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
                    leftSide: RubiksColor.Yellow,
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
                    frontSide: RubiksColor.Orange,
                    backSide: null,
                    rightSide: RubiksColor.White,
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
                    backSide: RubiksColor.Red,
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: RubiksColor.Blue,
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
                    upSide: RubiksColor.Blue,
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
                    leftSide: RubiksColor.Yellow,
                    upSide: RubiksColor.Red,
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
                    upSide: RubiksColor.Red,
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
                    frontSide: RubiksColor.Orange,
                    backSide: null,
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: RubiksColor.Blue,
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
                //x = 0
                cubie000,
                cubie010,
                cubie020,
                cubie001,
                cubie011,
                cubie021,
                cubie002,
                cubie012,
                cubie022,
                //x = 1
                cubie100,
                cubie110,
                cubie120,
                cubie101,
                cubie111,
                cubie121,
                cubie102,
                cubie112,
                cubie122,
                //x = 2
                cubie200,
                cubie210,
                cubie220,
                cubie201,
                cubie211,
                cubie221,
                cubie202,
                cubie212,
                cubie222
            };

            //exercise
            cube.TurnRight(TurningDirection.ThreeoClock);

            //verification
            Assert.IsTrue(expectedCubies.SetEquals(cube.Cubies));
        }

        [TestMethod]
        public void TurnLeft_WhenLayersDeepIsOne_ThenAllCubesOnThatFaceAndTheOneNextToItShouldMove()
        {
            //setup
            int cubeSize = 3;
            RubiksCube cube = new RubiksCube(null, new TestConfigurator(), cubeSize);

            #region 27 Cube Configuration

            Cubie cubie000 = new Cubie
                    (
                        frontSide: null,
                        backSide: RubiksColor.Orange,
                        rightSide: null,
                        leftSide: RubiksColor.Yellow,
                        upSide: null,
                        downSide: RubiksColor.Blue,
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
                    backSide: RubiksColor.Orange,
                    rightSide: null,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Blue,
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
                    downSide: RubiksColor.Blue,
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
                    downSide: RubiksColor.Blue,
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
                    frontSide: RubiksColor.Red,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.Yellow,
                    upSide: null,
                    downSide: RubiksColor.Blue,
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
                    frontSide: RubiksColor.Red,
                    backSide: null,
                    rightSide: null,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Blue,
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
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Orange,
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
                    backSide: RubiksColor.Orange,
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
                    backSide: RubiksColor.Orange,
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
                    frontSide: RubiksColor.Red,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.Yellow,
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
                    frontSide: RubiksColor.Red,
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
                    rightSide: RubiksColor.White,
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
                    backSide: RubiksColor.Orange,
                    rightSide: null,
                    leftSide: RubiksColor.Yellow,
                    upSide: RubiksColor.Green,
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
                    backSide: RubiksColor.Orange,
                    rightSide: null,
                    leftSide: null,
                    upSide: RubiksColor.Green,
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
                    upSide: RubiksColor.Green,
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
                    upSide: RubiksColor.Green,
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
                    frontSide: RubiksColor.Red,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.Yellow,
                    upSide: RubiksColor.Green,
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
                    frontSide: RubiksColor.Red,
                    backSide: null,
                    rightSide: null,
                    leftSide: null,
                    upSide: RubiksColor.Green,
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
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: RubiksColor.Red,
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
                //x = 0
                cubie000,
                cubie010,
                cubie020,
                cubie001,
                cubie011,
                cubie021,
                cubie002,
                cubie012,
                cubie022,
                //x = 1
                cubie100,
                cubie110,
                cubie120,
                cubie101,
                cubie111,
                cubie121,
                cubie102,
                cubie112,
                cubie122,
                //x = 2
                cubie200,
                cubie210,
                cubie220,
                cubie201,
                cubie211,
                cubie221,
                cubie202,
                cubie212,
                cubie222
            };

            //exercise
            cube.TurnLeft(TurningDirection.ThreeoClock, 1);

            Assert.IsTrue(expectedCubies.SetEquals(cube.Cubies));
        }

        [TestMethod]
        public void TurnUp_WhenTurningDirectionIsSixoClock_ThenAllCubesOnThatFaceShouldMove()
        {
            //setup
            int cubeSize = 3;
            RubiksCube cube = new RubiksCube(null, new TestConfigurator(), cubeSize);

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
                    leftSide: RubiksColor.Yellow,
                    upSide: null,
                    downSide: RubiksColor.Orange,
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
                    downSide: RubiksColor.Orange,
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
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Orange,
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
                    leftSide: RubiksColor.Yellow,
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
                    rightSide: RubiksColor.White,
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
                    backSide: RubiksColor.Blue,
                    rightSide: null,
                    leftSide: RubiksColor.White,
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
                    backSide: RubiksColor.Blue,
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
                    backSide: RubiksColor.Blue,
                    rightSide: RubiksColor.Yellow,
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
                    leftSide: RubiksColor.White,
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
                    rightSide: RubiksColor.Yellow,
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
                    frontSide: RubiksColor.Green,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.White,
                    upSide: RubiksColor.Red,
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
                    frontSide: RubiksColor.Green,
                    backSide: null,
                    rightSide: null,
                    leftSide: null,
                    upSide: RubiksColor.Red,
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
                    frontSide: RubiksColor.Green,
                    backSide: null,
                    rightSide: RubiksColor.Yellow,
                    leftSide: null,
                    upSide: RubiksColor.Red,
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
                cubie002, 
                cubie102, 
                cubie202, 
                cubie012, 
                cubie112, 
                cubie212, 
                cubie022, 
                cubie122, 
                cubie222
            };

            //exercise
            cube.TurnUp(TurningDirection.SixoClock);

            //verification
            Assert.IsTrue(expectedCubies.SetEquals(cube.Cubies));
        }

        [TestMethod]
        public void TurnBack_WhenTurningDirectionIsThreeoClock_ThenAllCubesOnThatFaceShouldMove()
        {
            //setup
            int cubeSize = 3;
            RubiksCube cube = new RubiksCube(null, new TestConfigurator(), cubeSize);

            #region 27 Cube Configuration

            Cubie cubie000 = new Cubie
                    (
                        frontSide: null,
                        backSide: RubiksColor.Green,
                        rightSide: null,
                        leftSide: RubiksColor.Red,
                        upSide: null,
                        downSide: RubiksColor.Yellow,
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
                    downSide: RubiksColor.Yellow,
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
                    rightSide: RubiksColor.Orange,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Yellow,
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
                    leftSide: RubiksColor.Yellow,
                    upSide: null,
                    downSide: RubiksColor.Orange,
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
                    downSide: RubiksColor.Orange,
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
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Orange,
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
                    leftSide: RubiksColor.Red,
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
                    rightSide: RubiksColor.Orange,
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
                    leftSide: RubiksColor.Yellow,
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
                    rightSide: RubiksColor.White,
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
                    leftSide: RubiksColor.Red,
                    upSide: RubiksColor.White,
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
                    upSide: RubiksColor.White,
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
                    rightSide: RubiksColor.Orange,
                    leftSide: null,
                    upSide: RubiksColor.White,
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
                    leftSide: RubiksColor.Yellow,
                    upSide: RubiksColor.Red,
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
                    upSide: RubiksColor.Red,
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
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: RubiksColor.Red,
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

            HashSet<Cubie> threeByThreeByThreeCube = new HashSet<Cubie>() 
            { 
                //z=0
                cubie000, cubie100, cubie200, cubie010, cubie110, cubie210, cubie020, cubie120, cubie220,
 
                //z=1
                cubie001, cubie101, cubie201, cubie011, cubie111, cubie211, cubie021, cubie121, cubie221,

                //z = 2
                cubie002, cubie102, cubie202, cubie012, cubie112, cubie212, cubie022, cubie122, cubie222
            };

            cube.TurnBack(TurningDirection.ThreeoClock);

            System.Diagnostics.Trace.WriteLine(cube);

            Assert.IsTrue(threeByThreeByThreeCube.SetEquals(cube.Cubies));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CubieIndexer_WhenRequestingANonExistentCubie_ThenInvalidOperationIsThrown()
        {
            //setup
            int cubeSize = 3;
            RubiksCube cube = new RubiksCube(null, new TestConfigurator(), cubeSize);

            //exercise
            Cubie cubie = cube[4, 4, 4];
        }

        [TestMethod]
        public void Shuffle_WhenNumberOfRandomTurnsIs1000_ThenAllCubiesCoordinatesAreValid()
        {
            //setup
            RubiksCube cube = new RubiksCube(null,new TestConfigurator(), 3);
            cube.Shuffle(numberOfTurns:1000);

            bool areAllCubiesInRange = cube.Cubies.All(cubie => cubie.Position.X <= 2 && cubie.Position.Y <= 2 && cubie.Position.Z <= 2);

            List<RubiksColor> colorsOfCube = new List<RubiksColor>();
            foreach(Cubie cubie in cube.Cubies)
            {
                if(cubie.BackSide != null)
                {
                    colorsOfCube.Add(cubie.BackSide.Value);
                }
                if(cubie.FrontSide != null)
                {
                    colorsOfCube.Add(cubie.FrontSide.Value);
                }
                if(cubie.LeftSide != null)
                {
                    colorsOfCube.Add(cubie.LeftSide.Value);
                }
                if(cubie.RightSide != null)
                {
                    colorsOfCube.Add(cubie.RightSide.Value);
                }
                if(cubie.UpSide != null)
                {
                    colorsOfCube.Add(cubie.UpSide.Value);
                }
                if(cubie.DownSide != null)
                {
                    colorsOfCube.Add(cubie.DownSide.Value);
                }
            }

            Assert.IsTrue(areAllCubiesInRange);
            Assert.AreEqual<int>(9, colorsOfCube.Count(color => color == RubiksColor.Blue), "Blue colors are incorrect");
            Assert.AreEqual<int>(9, colorsOfCube.Count(color => color == RubiksColor.Green), "Green colors are incorrect");
            Assert.AreEqual<int>(9, colorsOfCube.Count(color => color == RubiksColor.Orange), "Orange colors are incorrect");
            Assert.AreEqual<int>(9, colorsOfCube.Count(color => color == RubiksColor.Red), "Red colors are incorrect");
            Assert.AreEqual<int>(9, colorsOfCube.Count(color => color == RubiksColor.White), "White colors are incorrect");
            Assert.AreEqual<int>(9, colorsOfCube.Count(color => color == RubiksColor.Yellow), "Yellow colors are incorrect");
        }
    }

    class TestConfigurator : ICubieConfigurator
    {
        public IEnumerable<Cubie> CreateCubies(int cubeSize)
        {
            if (cubeSize != 3)
            {
                throw new NotSupportedException("Currently we are only supporting the standard 3x3x3 rubiks cube.");
            }

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
                    leftSide: RubiksColor.Yellow,
                    upSide: null,
                    downSide: RubiksColor.Orange,
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
                    downSide: RubiksColor.Orange,
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
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: null,
                    downSide: RubiksColor.Orange,
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
                    leftSide: RubiksColor.Yellow,
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
                    rightSide: RubiksColor.White,
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
                    leftSide: RubiksColor.Yellow,
                    upSide: RubiksColor.Red,
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
                    upSide: RubiksColor.Red,
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
                    rightSide: RubiksColor.White,
                    leftSide: null,
                    upSide: RubiksColor.Red,
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

            List<Cubie> threeByThreeByThreeCube = new List<Cubie>() 
            { 
                //z=0
                cubie000, cubie100, cubie200, cubie010, cubie110, cubie210, cubie020, cubie120, cubie220,
 
                //z=1
                cubie001, cubie101, cubie201, cubie011, cubie111, cubie211, cubie021, cubie121, cubie221,

                //z = 2
                cubie002, cubie102, cubie202, cubie012, cubie112, cubie212, cubie022, cubie122, cubie222
            };

            return threeByThreeByThreeCube;
        }
    }

}
