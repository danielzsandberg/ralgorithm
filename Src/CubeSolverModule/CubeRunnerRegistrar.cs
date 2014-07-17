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
    
    public class CubeRunnerRegistrar : ICubeRunnerRegistrar
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
                this.RunnersRegistered(this, new GenericEventArgs<IDictionary<Type, CubeRunner>>(addedCubeRunners.ToDictionary(
                    (runner) =>
                    {
                        return runner.AlgorithmType;
                    }
                    )));
            }
            if(updateCubeRunners.Count > 0)
            {
                this.RunnerRegistrationsUpdated(this, new GenericEventArgs<IDictionary<Type, CubeRunner>>(updateCubeRunners.ToDictionary(
                    (runner) =>
                    {
                        return runner.AlgorithmType;
                    }
                    )));
            }
        }

        public void Register(CubeRunner cubeRunner)
        {
            Register(new List<CubeRunner>() { cubeRunner });
        }

        public void Register(Assembly assembly)
        {
            IEnumerable<CubeRunner> cubeRunners = _cubeRunnerFactory.CreateCubeRunners(assembly);

            Register(cubeRunners);
        }

        public void Register(ICubeSolvingAlgorithm algorithm)
        {
            CubeRunner value = _cubeRunnerFactory.CreateCubeRunners(new List<ICubeSolvingAlgorithm>() { algorithm }).First();
            Register(value);
        }

        public void Deregister(Type algorithmTypeToDeregister)
        {
            CubeRunner removedRunner = null;
            bool removeSuccessful = _registrations.TryRemove(algorithmTypeToDeregister, out removedRunner);

            if (removeSuccessful)
            {
                RunnersDeregistered(this, new GenericEventArgs<IDictionary<Type, CubeRunner>>(new Dictionary<Type, CubeRunner>() { { algorithmTypeToDeregister, removedRunner } }));
            }
        }

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
                RunnersDeregistered(this, new GenericEventArgs<IDictionary<Type, CubeRunner>>(runners));
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

        public event EventHandler<GenericEventArgs<IDictionary<Type, CubeRunner>>> RunnersRegistered = delegate { };

        public event EventHandler<GenericEventArgs<IDictionary<Type, CubeRunner>>> RunnersDeregistered = delegate { };

        public event EventHandler<GenericEventArgs<IDictionary<Type, CubeRunner>>> RunnerRegistrationsUpdated = delegate { }; 

        #endregion
    }
}
