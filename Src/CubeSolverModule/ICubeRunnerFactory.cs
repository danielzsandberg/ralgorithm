using RubiksApp.RubiksAlgorithmToolset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.CubeSolverModule
{
    public interface ICubeRunnerFactory
    {
        IEnumerable<CubeRunner> CreateCubeRunners(string assemblyPath);

        IEnumerable<CubeRunner> CreateCubeRunners(Assembly assembly);

        IEnumerable<CubeRunner> CreateCubeRunners(IEnumerable<ICubeSolvingAlgorithm> algorithms);
    }
}
