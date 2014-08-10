using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RubiksCore;
using Moq;
using RubiksApp.RubiksAlgorithmToolset;
using RubiksApp.CubeSolverModule;

namespace CubeSolverModule.Test
{
    [TestClass]
    public class CubeRunnerTest
    {
        [TestMethod]
        public void Construct_ThenRunnerStateIsStopped()
        {
            RubiksCube cube = new RubiksCube();
            Mock<ICubeSolvingAlgorithm> algMock = new Mock<ICubeSolvingAlgorithm>();

            CubeRunner cubeRunner = new CubeRunner(cube, algMock.Object);

            Assert.AreEqual(cubeRunner.RunnerState, CubeRunnerState.Stopped);
        }

        [TestMethod]
        public void Run_WhenAlgorithmRunsToCompletion_ThenCubeStateGoesToRunningAndThenStopped()
        {
            RubiksCube cube = new RubiksCube();
            Mock<ICubeSolvingAlgorithm> algMock = new Mock<ICubeSolvingAlgorithm>();

            CubeRunner cubeRunner = new CubeRunner(cube, algMock.Object);

            bool wentToRunning = false;
            bool wentToStopped = false;
            cubeRunner.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler((sender, args) => 
            {
                if(cubeRunner.RunnerState == CubeRunnerState.Running)
                {
                    wentToRunning = true;
                }
                if(cubeRunner.RunnerState == CubeRunnerState.Stopped)
                {
                    wentToStopped = true;
                }
            });

            cubeRunner.Run();

            Assert.IsTrue(wentToRunning && wentToStopped);
        }

        [TestMethod]
        public void Run_WhenAlgorithmSolvesCube_ThenResultShowThatTheCubeWasSolved()
        {
            RubiksCube cube = new RubiksCube();
            cube.TurnLeft();
            cube.TurnUp();
            Mock<ICubeSolvingAlgorithm> algMock = new Mock<ICubeSolvingAlgorithm>();
            algMock.Setup(alg => alg.Solve(cube)).Callback(new Action(() =>
            {
                cube.TurnUp(TurningDirection.NineoClock);
                cube.TurnLeft(TurningDirection.NineoClock);
            }));

            CubeRunner runner = new CubeRunner(cube, algMock.Object);

            SolverResult result = runner.Run();

            Assert.IsTrue(result.WasCubeSolved);
        }

        [TestMethod]
        public void Run_WhenAlgorithmFailsToSolveCube_ThenResultShowThatTheCubeWasSolved()
        {
            RubiksCube cube = new RubiksCube();
            cube.TurnLeft();
            cube.TurnUp();
            Mock<ICubeSolvingAlgorithm> algMock = new Mock<ICubeSolvingAlgorithm>();
            algMock.Setup(alg => alg.Solve(cube)).Callback(new Action(() =>
            {
                cube.TurnUp(TurningDirection.NineoClock);
            }));

            CubeRunner runner = new CubeRunner(cube, algMock.Object);

            SolverResult result = runner.Run();

            Assert.IsFalse(result.WasCubeSolved);
        }

        [TestMethod]
        public void Run_WhenNoExceptionThrown_ThenTheErrorStringIsNullAndWasThereAnErrorIsFalse()
        {
            RubiksCube cube = new RubiksCube();
            Mock<ICubeSolvingAlgorithm> algMock = new Mock<ICubeSolvingAlgorithm>();
            algMock.Setup(alg => alg.Solve(cube)).Callback(new Action(() =>
            {
                cube.TurnUp(TurningDirection.NineoClock);
            }));

            CubeRunner runner = new CubeRunner(cube, algMock.Object);

            SolverResult result = runner.Run();

            Assert.IsFalse(result.WasThereAnError);
            Assert.IsNull(result.ErrorMessage);
        }

        [TestMethod]
        public void Run_WhenExceptionThrown_ThenTheErrorStringIsNotNullAndWasThereAnErrorIsTrue()
        {
            RubiksCube cube = new RubiksCube();
            Mock<ICubeSolvingAlgorithm> algMock = new Mock<ICubeSolvingAlgorithm>();
            algMock.Setup(alg => alg.Solve(cube)).Callback(new Action(() =>
            {
                cube.TurnUp(TurningDirection.NineoClock);
                throw new Exception();
            }));

            CubeRunner runner = new CubeRunner(cube, algMock.Object);

            SolverResult result = runner.Run();

            Assert.IsTrue(result.WasThereAnError);
            Assert.IsNotNull(result.ErrorMessage);
        }

        [TestMethod]
        public void Run_WhenAlgorithmRunsForOneSecond_ThenTimeToCompletionIsOneSecondPlusOrMinusPointTwoSeconds()
        {
            RubiksCube cube = new RubiksCube();
            Mock<ICubeSolvingAlgorithm> algMock = new Mock<ICubeSolvingAlgorithm>();
            algMock.Setup(alg => alg.Solve(cube)).Callback(new Action(() =>
            {
                System.Threading.Thread.Sleep(1000);
            }));

            CubeRunner runner = new CubeRunner(cube, algMock.Object);

            SolverResult result = runner.Run();

            Assert.IsTrue(TimeSpan.FromSeconds(1) + TimeSpan.FromSeconds(.2) > result.TimeToCompletion 
                || TimeSpan.FromSeconds(1) - TimeSpan.FromSeconds(.2) < result.TimeToCompletion, string.Format("Actual time to completion {0}", result.TimeToCompletion));
        }

        [TestMethod]
        public void Run_WhenAlgorithmTurnsCubeTwice_ThenMovesToCompletionIsTwo()
        {
            RubiksCube cube = new RubiksCube();
            Mock<ICubeSolvingAlgorithm> algMock = new Mock<ICubeSolvingAlgorithm>();
            algMock.Setup(alg => alg.Solve(cube)).Callback(new Action(() =>
            {
                cube.TurnUp(TurningDirection.NineoClock);
                cube.TurnLeft(TurningDirection.NineoClock);
            }));

            CubeRunner runner = new CubeRunner(cube, algMock.Object);

            SolverResult result = runner.Run();

            Assert.AreEqual<int>(2, result.MovesToCompletion);
        }

        [TestMethod]
        public void Run_WhenAlgorithmDoesATotalMoveThenMovesToCompletionIsZero()
        {
            RubiksCube cube = new RubiksCube();
            Mock<ICubeSolvingAlgorithm> algMock = new Mock<ICubeSolvingAlgorithm>();
            algMock.Setup(alg => alg.Solve(cube)).Callback(new Action(() =>
            {
                cube.TurnUp(TurningDirection.NineoClock, 2);
            }));

            CubeRunner runner = new CubeRunner(cube, algMock.Object);

            SolverResult result = runner.Run();

            Assert.AreEqual<int>(0, result.MovesToCompletion);
        }

        [TestMethod]
        public void Run_WhenAlgorithmOnSecondRunTurnsCubeThreeTimes_ThenMovesToCompletionIsThree()
        {
            RubiksCube cube = new RubiksCube();
            Mock<ICubeSolvingAlgorithm> algMock = new Mock<ICubeSolvingAlgorithm>();
            algMock.Setup(alg => alg.Solve(cube)).Callback(new Action(() =>
            {
                cube.TurnUp(TurningDirection.NineoClock);
                cube.TurnLeft(TurningDirection.NineoClock);
            }));
            algMock.Setup(alg => alg.Solve(cube)).Callback(new Action(() =>
            {
                cube.TurnUp(TurningDirection.NineoClock);
                cube.TurnLeft(TurningDirection.NineoClock);
                cube.TurnBack();
            }));

            CubeRunner runner = new CubeRunner(cube, algMock.Object);

            SolverResult result = runner.Run();

            Assert.AreEqual<int>(3, result.MovesToCompletion);
        }

        
    }
}
