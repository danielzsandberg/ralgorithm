using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RubiksApp.CubeSolverModule;
using RubiksApp.RubiksAlgorithmToolset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSolverModule.Test
{
    [TestClass]
    public class CubeRunnerRegistrarTests
    {
        [TestMethod]
        public void Register_WhenAllAlgorithmsAreNew()
        {
            //setup
            Algorithm1 alg1 = new Algorithm1();
            Algorithm2 alg2 = new Algorithm2();
            Mock<ICubeRunnerFactory> cubeRunnerFactoryFake = new Mock<ICubeRunnerFactory>();
            cubeRunnerFactoryFake.Setup(factory => factory.CreateCubeRunners(new List<ICubeSolvingAlgorithm>(){alg1})).Returns(new List<CubeRunner>(){new CubeRunner(new RubiksCore.RubiksCube(), alg1)});
            cubeRunnerFactoryFake.Setup(factory => factory.CreateCubeRunners(new List<ICubeSolvingAlgorithm>() { alg2 })).Returns(new List<CubeRunner>() { new CubeRunner(new RubiksCore.RubiksCube(), alg2) });
            CubeRunnerRegistrar registrar = new CubeRunnerRegistrar(cubeRunnerFactoryFake.Object);

            int addCount = 0;
            IDictionary<Type, CubeRunner> addedRegistrations = new Dictionary<Type,CubeRunner>();
            registrar.RunnersRegistered += (sender, args)
                =>
                {
                    addedRegistrations = args.Event;
                    addCount++;
                };

            int removedCount = 0;
            IDictionary<Type, CubeRunner> removedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnersDeregistered += (sender, args)
                =>
            {
                removedRegistrations = args.Event;
                removedCount++;
            };

            int updatedCount = 0;
            IDictionary<Type, CubeRunner> updatedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnerRegistrationsUpdated += (sender, args)
                =>
            {
                updatedRegistrations = args.Event;
                updatedCount++;
            };

            //exercise
            registrar.Register(alg1);
            registrar.Register(alg2);

            //verification
            Assert.AreEqual<int>(2, addCount);
            Assert.AreEqual<int>(0, updatedCount);
            Assert.AreEqual<int>(0, removedCount);

            Assert.AreEqual<int>(1, addedRegistrations.Count);
            Assert.AreEqual<int>(0, updatedRegistrations.Count);
            Assert.AreEqual<int>(0, removedRegistrations.Count);

            Assert.AreEqual<Type>(alg2.GetType(), addedRegistrations.First().Key);

            Assert.AreEqual<int>(2, registrar.RegistrationsCopy.Length);
            Assert.IsTrue(registrar.RegistrationsCopy.Any(kvp => kvp.Key.Equals(alg1.GetType())));
            Assert.IsTrue(registrar.RegistrationsCopy.Any(kvp => kvp.Key.Equals(alg2.GetType())));
        }

        [TestMethod]
        public void Register_WhenSomeAlgorithmsAreNewAndSomeAreUpdates()
        {
            //setup
            Algorithm1 alg1 = new Algorithm1();
            Algorithm1 alg1V2 = new Algorithm1();
            Mock<ICubeRunnerFactory> cubeRunnerFactoryFake = new Mock<ICubeRunnerFactory>();
            cubeRunnerFactoryFake.Setup(factory => factory.CreateCubeRunners(new List<ICubeSolvingAlgorithm>() { alg1 })).Returns(new List<CubeRunner>() { new CubeRunner(new RubiksCore.RubiksCube(), alg1) });
            cubeRunnerFactoryFake.Setup(factory => factory.CreateCubeRunners(new List<ICubeSolvingAlgorithm>() { alg1V2 })).Returns(new List<CubeRunner>() { new CubeRunner(new RubiksCore.RubiksCube(), alg1V2) });
            CubeRunnerRegistrar registrar = new CubeRunnerRegistrar(cubeRunnerFactoryFake.Object);

            int addCount = 0;
            IDictionary<Type, CubeRunner> addedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnersRegistered += (sender, args)
                =>
            {
                addedRegistrations = args.Event;
                addCount++;
            };

            int removedCount = 0;
            IDictionary<Type, CubeRunner> removedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnersDeregistered += (sender, args)
                =>
            {
                removedRegistrations = args.Event;
                removedCount++;
            };

            int updatedCount = 0;
            IDictionary<Type, CubeRunner> updatedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnerRegistrationsUpdated += (sender, args)
                =>
            {
                updatedRegistrations = args.Event;
                updatedCount++;
            };

            //exercise
            registrar.Register(alg1);
            registrar.Register(alg1V2);

            //verification
            Assert.AreEqual<int>(1, addCount);
            Assert.AreEqual<int>(1, updatedCount);
            Assert.AreEqual<int>(0, removedCount);

            Assert.AreEqual<int>(1, addedRegistrations.Count);
            Assert.AreEqual<int>(1, updatedRegistrations.Count);
            Assert.AreEqual<int>(0, removedRegistrations.Count);

            Assert.AreEqual<Type>(typeof(Algorithm1), addedRegistrations.First().Key);
            Assert.AreEqual<Type>(typeof(Algorithm1), updatedRegistrations.First().Key);

            Assert.AreEqual<int>(1, registrar.RegistrationsCopy.Length);
            Assert.IsTrue(registrar.RegistrationsCopy.Any(kvp => kvp.Key.Equals(alg1.GetType())));
        }

        [TestMethod]
        public void Deregister_WhenTypeIsRegistered()
        {
            //setup
            Algorithm1 alg1 = new Algorithm1();
            Mock<ICubeRunnerFactory> cubeRunnerFactoryFake = new Mock<ICubeRunnerFactory>();
            cubeRunnerFactoryFake.Setup(factory => factory.CreateCubeRunners(new List<ICubeSolvingAlgorithm>() { alg1 })).Returns(new List<CubeRunner>() { new CubeRunner(new RubiksCore.RubiksCube(), alg1) });
            CubeRunnerRegistrar registrar = new CubeRunnerRegistrar(cubeRunnerFactoryFake.Object);

            int addCount = 0;
            IDictionary<Type, CubeRunner> addedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnersRegistered += (sender, args)
                =>
            {
                addedRegistrations = args.Event;
                addCount++;
            };

            int removedCount = 0;
            IDictionary<Type, CubeRunner> removedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnersDeregistered += (sender, args)
                =>
            {
                removedRegistrations = args.Event;
                removedCount++;
            };

            int updatedCount = 0;
            IDictionary<Type, CubeRunner> updatedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnerRegistrationsUpdated += (sender, args)
                =>
            {
                updatedRegistrations = args.Event;
                updatedCount++;
            };

            //exercise
            registrar.Register(alg1);
            registrar.Deregister(typeof(Algorithm1));

            //verification
            Assert.AreEqual<int>(1, addCount);
            Assert.AreEqual<int>(0, updatedCount);
            Assert.AreEqual<int>(1, removedCount);

            Assert.AreEqual<int>(1, addedRegistrations.Count);
            Assert.AreEqual<int>(0, updatedRegistrations.Count);
            Assert.AreEqual<int>(1, removedRegistrations.Count);

            Assert.AreEqual<Type>(typeof(Algorithm1), addedRegistrations.First().Key);
            Assert.AreEqual<Type>(typeof(Algorithm1), removedRegistrations.First().Key);

            Assert.AreEqual<int>(0, registrar.RegistrationsCopy.Length);
        }

        [TestMethod]
        public void Deregister_WhenTypeIsNotRegistered()
        {
            //setup
            Algorithm1 alg1 = new Algorithm1();
            Mock<ICubeRunnerFactory> cubeRunnerFactoryFake = new Mock<ICubeRunnerFactory>();
            cubeRunnerFactoryFake.Setup(factory => factory.CreateCubeRunners(new List<ICubeSolvingAlgorithm>() { alg1 })).Returns(new List<CubeRunner>() { new CubeRunner(new RubiksCore.RubiksCube(), alg1) });
            CubeRunnerRegistrar registrar = new CubeRunnerRegistrar(cubeRunnerFactoryFake.Object);

            int addCount = 0;
            IDictionary<Type, CubeRunner> addedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnersRegistered += (sender, args)
                =>
            {
                addedRegistrations = args.Event;
                addCount++;
            };

            int removedCount = 0;
            IDictionary<Type, CubeRunner> removedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnersDeregistered += (sender, args)
                =>
            {
                removedRegistrations = args.Event;
                removedCount++;
            };

            int updatedCount = 0;
            IDictionary<Type, CubeRunner> updatedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnerRegistrationsUpdated += (sender, args)
                =>
            {
                updatedRegistrations = args.Event;
                updatedCount++;
            };

            //exercise
            registrar.Deregister(typeof(Algorithm1));

            //verification
            Assert.AreEqual<int>(0, addCount);
            Assert.AreEqual<int>(0, updatedCount);
            Assert.AreEqual<int>(0, removedCount);

            Assert.AreEqual<int>(0, addedRegistrations.Count);
            Assert.AreEqual<int>(0, updatedRegistrations.Count);
            Assert.AreEqual<int>(0, removedRegistrations.Count);

            Assert.AreEqual<int>(0, registrar.RegistrationsCopy.Length);
        }

        [TestMethod]
        public void DeregisterAll()
        {
            //setup
            Algorithm1 alg1 = new Algorithm1();
            Algorithm2 alg2 = new Algorithm2();
            Mock<ICubeRunnerFactory> cubeRunnerFactoryFake = new Mock<ICubeRunnerFactory>();
            cubeRunnerFactoryFake.Setup(factory => factory.CreateCubeRunners(new List<ICubeSolvingAlgorithm>() { alg1 })).Returns(new List<CubeRunner>() { new CubeRunner(new RubiksCore.RubiksCube(), alg1) });
            cubeRunnerFactoryFake.Setup(factory => factory.CreateCubeRunners(new List<ICubeSolvingAlgorithm>() { alg2 })).Returns(new List<CubeRunner>() { new CubeRunner(new RubiksCore.RubiksCube(), alg2) });
            CubeRunnerRegistrar registrar = new CubeRunnerRegistrar(cubeRunnerFactoryFake.Object);

            int addCount = 0;
            IDictionary<Type, CubeRunner> addedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnersRegistered += (sender, args)
                =>
            {
                addedRegistrations = args.Event;
                addCount++;
            };

            int removedCount = 0;
            IDictionary<Type, CubeRunner> removedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnersDeregistered += (sender, args)
                =>
            {
                removedRegistrations = args.Event;
                removedCount++;
            };

            int updatedCount = 0;
            IDictionary<Type, CubeRunner> updatedRegistrations = new Dictionary<Type, CubeRunner>();
            registrar.RunnerRegistrationsUpdated += (sender, args)
                =>
            {
                updatedRegistrations = args.Event;
                updatedCount++;
            };

            //exercise
            registrar.Register(alg1);
            registrar.Register(alg2);
            registrar.DeregisterAll();

            //verification
            Assert.AreEqual<int>(2, addCount);
            Assert.AreEqual<int>(0, updatedCount);
            Assert.AreEqual<int>(1, removedCount);

            Assert.AreEqual<int>(1, addedRegistrations.Count);
            Assert.AreEqual<int>(0, updatedRegistrations.Count);
            Assert.AreEqual<int>(2, removedRegistrations.Count);

            Assert.AreEqual<Type>(typeof(Algorithm2), addedRegistrations.First().Key);
            Assert.IsTrue(removedRegistrations.Any(kvp => kvp.Key.Equals(typeof(Algorithm1))));
            Assert.IsTrue(removedRegistrations.Any(kvp => kvp.Key.Equals(typeof(Algorithm2))));

            Assert.AreEqual<int>(0, registrar.RegistrationsCopy.Length);
        }

        #region Nested Classes\\Fakes
        private class Algorithm1 : ICubeSolvingAlgorithm
        {

            public string AlgorithmName
            {
                get { throw new NotImplementedException(); }
            }

            public string Author
            {
                get { throw new NotImplementedException(); }
            }

            public string Description
            {
                get { throw new NotImplementedException(); }
            }

            public void Solve(RubiksCore.RubiksCube cube)
            {
                throw new NotImplementedException();
            }
        }

        private class Algorithm2 : ICubeSolvingAlgorithm
        {

            public string AlgorithmName
            {
                get { throw new NotImplementedException(); }
            }

            public string Author
            {
                get { throw new NotImplementedException(); }
            }

            public string Description
            {
                get { throw new NotImplementedException(); }
            }

            public void Solve(RubiksCore.RubiksCube cube)
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
