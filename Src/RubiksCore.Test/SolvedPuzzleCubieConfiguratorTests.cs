using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RubiksCore.Test
{
    [TestClass]
    public class SolvedPuzzleCubieConfiguratorTests
    {
        [TestMethod]
        public void CreateCubies_WhenUsingCustomColorConfiguration_ThenItReturnsCubiesInASolvedState()
        {
            //setup
            SolvedPuzzleCubieConfigurator configurator = new SolvedPuzzleCubieConfigurator
                (
                    frontColor: RubiksColor.Blue,
                    backColor: RubiksColor.Green,
                    rightColor: RubiksColor.White,
                    leftColor: RubiksColor.Yellow,
                    upColor: RubiksColor.Red,
                    downColor: RubiksColor.Orange
                );

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

            List<Cubie> expectedCubies = new List<Cubie>() 
            { 
                //z=0
                cubie000, cubie100, cubie200, cubie010, cubie110, cubie210, cubie020, cubie120, cubie220,
 
                //z=1
                cubie001, cubie101, cubie201, cubie011, cubie111, cubie211, cubie021, cubie121, cubie221,

                //z = 2
                cubie002, cubie102, cubie202, cubie012, cubie112, cubie212, cubie022, cubie122, cubie222
            };
            //exercise
            HashSet<Cubie> cubies = new HashSet<Cubie>(configurator.CreateCubies(3));

            //verification
            Assert.AreEqual<int>(27, cubies.Count());
            Assert.IsTrue(cubies.SetEquals(expectedCubies));
        }

        [TestMethod]
        public void CreateCubies_WhenUsingDefaultColorConfiguration_ThenItReturnsCubiesInASolvedState()
        {
            //Setup
            SolvedPuzzleCubieConfigurator configurator = new SolvedPuzzleCubieConfigurator();
            #region 27 Cube Configuration

            Cubie cubie000 = new Cubie
                    (
                        frontSide: null,
                        backSide: RubiksColor.Yellow, //formerly Green
                        rightSide: null,
                        leftSide: RubiksColor.Blue, //formerly Yellow
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
                    backSide: RubiksColor.Yellow, //formerly Green
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
                    backSide: RubiksColor.Yellow, //formerly Green
                    rightSide: RubiksColor.Green, //formerly White,
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
                    leftSide: RubiksColor.Blue, //formerly Yellow
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
                    rightSide: RubiksColor.Green, //formerly White,
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
                    frontSide: RubiksColor.White, //formerly Blue,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.Blue, //formerly Yellow
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
                    frontSide: RubiksColor.White, //formerly Blue,Blue,
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
                    frontSide: RubiksColor.White, //formerly Blue,
                    backSide: null,
                    rightSide: RubiksColor.Green, //formerly White,
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
                    backSide: RubiksColor.Yellow, //formerly Green
                    rightSide: null,
                    leftSide: RubiksColor.Blue, //formerly Yellow
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
                    backSide: RubiksColor.Yellow, //formerly Green
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
                    backSide: RubiksColor.Yellow, //formerly Green
                    rightSide: RubiksColor.Green, //formerly White,
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
                    leftSide: RubiksColor.Blue, //formerly Yellow
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
                    rightSide: RubiksColor.Green, //formerly White,
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
                    frontSide: RubiksColor.White, //formerly Blue,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.Blue, //formerly Yellow
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
                    frontSide: RubiksColor.White, //formerly Blue,
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
                    frontSide: RubiksColor.White, //formerly Blue,
                    backSide: null,
                    rightSide: RubiksColor.Green, //formerly White,
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
                    backSide: RubiksColor.Yellow, //formerly Green
                    rightSide: null,
                    leftSide: RubiksColor.Blue, //formerly Yellow
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
                    backSide: RubiksColor.Yellow, //formerly Green
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
                    backSide: RubiksColor.Yellow, //formerly Green
                    rightSide: RubiksColor.Green, //formerly White,
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
                    leftSide: RubiksColor.Blue, //formerly Yellow
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
                    rightSide: RubiksColor.Green, //formerly White,
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
                    frontSide: RubiksColor.White, //formerly Blue,
                    backSide: null,
                    rightSide: null,
                    leftSide: RubiksColor.Blue, //formerly Yellow
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
                    frontSide: RubiksColor.White, //formerly Blue,
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
                    frontSide: RubiksColor.White, //formerly Blue,
                    backSide: null,
                    rightSide: RubiksColor.Green, //formerly White,
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

            List<Cubie> expectedCubies = new List<Cubie>() 
            { 
                //z=0
                cubie000, cubie100, cubie200, cubie010, cubie110, cubie210, cubie020, cubie120, cubie220,
 
                //z=1
                cubie001, cubie101, cubie201, cubie011, cubie111, cubie211, cubie021, cubie121, cubie221,

                //z = 2
                cubie002, cubie102, cubie202, cubie012, cubie112, cubie212, cubie022, cubie122, cubie222
            };

            //exercise
            HashSet<Cubie> cubies = new HashSet<Cubie>(configurator.CreateCubies(3));

            //verification
            Assert.AreEqual<int>(27, cubies.Count());
            Assert.IsTrue(cubies.SetEquals(expectedCubies));
        }
    }
}
