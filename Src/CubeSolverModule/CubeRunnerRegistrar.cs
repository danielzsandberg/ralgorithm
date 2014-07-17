using RubiksApp.RubiksAlgorithmToolset;
using RubiksCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.CubeSolverModule
{
    /// <summary>
    /// A registrar for cube solving runners. Provides registration, registrar querying, and notification of new registrations.
    /// </summary>
    public class CubeRunnerRegistrar
    {
        #region Instance Variables

        ConcurrentDictionary<Type, CubeRunner> _registrations = new ConcurrentDictionary<Type, CubeRunner>();
        ICubeRunnerFactory _cubeRunnerFactory; 

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new CubeRunnerRegistrar.
        /// </summary>
        /// <param name="cubeRunnerFactory">Factory used to create CubeRunners when registering ICubeSolvingAlgorithms</param>
        public CubeRunnerRegistrar(ICubeRunnerFactory cubeRunnerFactory)
        {
            _cubeRunnerFactory = cubeRunnerFactory;
        } 

        #endregion

        #region Methods

        /// <summary>
        /// Registers multiple cube runners.
        /// </summary>
        /// <param name="cubeRunners">Cube runners to register</param>
        public void Register(IEnumerable<CubeRunner> cubeRunners)
        {
            List<CubeRunner> addedCubeRunners = new List<CubeRunner>();
            List<CubeRunner> updateCubeRunners = new List<CubeRunner>();

            foreach(CubeRunner runner in cubeRunners)
            {
                bool wasAddPerformed = false;
                bool wasUpdatePerformed = false;

                _registrations.AddOrUpdate(runner.AlgorithmType,
                    (type) =>
                    {
                        wasAddPerformed = true;
                        return runner;
                    },
                    (type, existingRunner) =>
                    {
                        wasUpdatePerformed = true;
                        return runner;
                    }
                    );
                if(wasAddPerformed)
                {
                    addedCubeRunners.Add(runner);
                }
                if(wasUpdatePerformed)
                {
                    updateCubeRunners.Add(runner);
                }
            }

            if(addedCubeRunners.Count > 0)
            {
                this.AlgorithmsRegistered(this, new GenericEventArgs<IDictionary<Type, CubeRunner>>(addedCubeRunners.ToDictionary(
                    (runner) =>
                    {
                        return runner.AlgorithmType;
                    }
                    )));
            }
            if(updateCubeRunners.Count > 0)
            {
                this.AlgorithmRegistrationsUpdated(this, new GenericEventArgs<IDictionary<Type, CubeRunner>>(updateCubeRunners.ToDictionary(
                    (runner) =>
                    {
                        return runner.AlgorithmType;
                    }
                    )));
            }
        }

        /// <summary>
        /// Registers a single cube runner
        /// </summary>
        /// <param name="cubeRunner">The cube runner to register</param>
        public void Register(CubeRunner cubeRunner)
        {
            Register(new List<CubeRunner>() { cubeRunner });
        }

        /// <summary>
        /// Register all algorithms contained in assembly and creates CubeRunners for them.
        /// </summary>
        /// <param name="assembly">An assembly that contains algorithms</param>
        public void Register(Assembly assembly)
        {
            IEnumerable<CubeRunner> cubeRunners = _cubeRunnerFactory.CreateCubeRunners(assembly);

            Register(cubeRunners);
        }

        /// <summary>
        /// Register a single algorithm and creates a CubeRunner for it.
        /// </summary>
        /// <param name="algorithm">The algorithm to register</param>
        public void Register(ICubeSolvingAlgorithm algorithm)
        {
            CubeRunner value = _cubeRunnerFactory.CreateCubeRunners(new List<ICubeSolvingAlgorithm>() { algorithm }).First();
            Register(value);
        }

        /// <summary>
        /// Deregisters an algorithm type and all associated CubeRunners.
        /// </summary>
        /// <param name="algorithmTypeToDeregister">The type of algorithm to deregister</param>
        public void Deregister(Type algorithmTypeToDeregister)
        {
            CubeRunner removedRunner = null;
            bool removeSuccessful = _registrations.TryRemove(algorithmTypeToDeregister, out removedRunner);

            if (removeSuccessful)
            {
                AlgorithmsDeregistered(this, new GenericEventArgs<IDictionary<Type, CubeRunner>>(new Dictionary<Type, CubeRunner>() { { algorithmTypeToDeregister, removedRunner } }));
            }
        }

        /// <summary>
        /// Deregisters all algorithms and associated cube runners.
        /// </summary>
        public void DeregisterAll()
        {
            KeyValuePair<Type, CubeRunner>[] registrationsCopy = RegistrationsCopy;

            _registrations.Clear();

            Dictionary<Type, CubeRunner> runners = new Dictionary<Type, CubeRunner>();
            foreach (KeyValuePair<Type, CubeRunner> kvp in registrationsCopy)
            {
                runners.Add(kvp.Key, kvp.Value);
            }

            if (runners.Count > 0)
            {
                AlgorithmsDeregistered(this, new GenericEventArgs<IDictionary<Type, CubeRunner>>(runners));
            }
        } 

        #endregion

        #region Properties

        public KeyValuePair<Type, CubeRunner>[] RegistrationsCopy
        {
            get
            {
                return _registrations.ToArray();
            }
        } 

        #endregion

        #region Events

        public event EventHandler<GenericEventArgs<IDictionary<Type, CubeRunner>>> AlgorithmsRegistered = delegate { };

        public event EventHandler<GenericEventArgs<IDictionary<Type, CubeRunner>>> AlgorithmsDeregistered = delegate { };

        public event EventHandler<GenericEventArgs<IDictionary<Type, CubeRunner>>> AlgorithmRegistrationsUpdated = delegate { }; 

        #endregion
    }
}
