using RubiksApp.CubeConfiguratorModule;
using RubiksApp.RubiksAlgorithmToolset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.CubeSolverModule
{
    public class CubeRunnerFactory : ICubeRunnerFactory
    {
        ICubeConfigurationService _cubeProvider;

        public CubeRunnerFactory(ICubeConfigurationService provider)
        {
            _cubeProvider = provider;
        }

        public IEnumerable<CubeRunner> CreateCubeRunners(string assemblyPath)
        {
            return CreateCubeRunners(Assembly.LoadFrom(assemblyPath));
        }

        public IEnumerable<CubeRunner> CreateCubeRunners(Assembly assembly)
        {
            IEnumerable<Type> types = assembly.ExportedTypes.Where(type => type.GetInterfaces().Any(typ => typ.Equals((typeof(ICubeSolvingAlgorithm)))));

            IEnumerable<ICubeSolvingAlgorithm> algorithms = types.Select(type => (ICubeSolvingAlgorithm)Activator.CreateInstance(type)).ToArray();

            return CreateCubeRunners(algorithms);
        }

        public IEnumerable<CubeRunner> CreateCubeRunners(IEnumerable<ICubeSolvingAlgorithm> algorithms)
        {
            return algorithms.Select(alg => new CubeRunner(_cubeProvider.GetCube(), alg)).ToArray();
        }
    }
}
