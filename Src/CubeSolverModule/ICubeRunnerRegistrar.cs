using RubiksApp.RubiksAlgorithmToolset;
using RubiksCore;
using System;
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
    public interface ICubeRunnerRegistrar
    {
        /// <summary>
        /// Registers multiple cube runners.
        /// </summary>
        /// <param name="cubeRunners">Cube runners to register</param>
        void Register(IEnumerable<CubeRunner> cubeRunners);

        /// <summary>
        /// Registers a single cube runner
        /// </summary>
        /// <param name="cubeRunner">The cube runner to register</param>
        void Register(CubeRunner cubeRunner);

        /// <summary>
        /// Register all algorithms contained in assembly and creates CubeRunners for them.
        /// </summary>
        /// <param name="assembly">An assembly that contains algorithms</param>
        void Register(Assembly assembly);

        /// <summary>
        /// Register a single algorithm and creates a CubeRunner for it.
        /// </summary>
        /// <param name="algorithm">The algorithm to register</param>
        void Register(ICubeSolvingAlgorithm algorithm);

        /// <summary>
        /// Deregisters an algorithm type and all associated CubeRunners.
        /// </summary>
        /// <param name="algorithmTypeToDeregister">The type of algorithm to deregister</param>
        void Deregister(Type algorithmTypeToDeregister);

        /// <summary>
        /// Deregisters all algorithms and associated cube runners.
        /// </summary>
        void DeregisterAll();

        /// <summary>
        /// A copy of the internal registry.
        /// </summary>
        KeyValuePair<Type, CubeRunner>[] RegistrationsCopy
        {
            get;
        }

        /// <summary>
        /// Raised when new CubeRunners are registered. Contains the added registrations.
        /// </summary>
        event EventHandler<GenericEventArgs<IDictionary<Type, CubeRunner>>> AlgorithmsRegistered;

        /// <summary>
        /// Raised when CubeRunners are deregistered. Contains the removed registrations.
        /// </summary>
        event EventHandler<GenericEventArgs<IDictionary<Type, CubeRunner>>> AlgorithmsDeregistered;

        /// <summary>
        /// Raised when CubeRunner registrations are updated. Contains the updated registrations.
        /// </summary>
        event EventHandler<GenericEventArgs<IDictionary<Type, CubeRunner>>> AlgorithmRegistrationsUpdated;
    }
}
