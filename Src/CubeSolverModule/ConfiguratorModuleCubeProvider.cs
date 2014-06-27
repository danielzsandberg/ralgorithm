using RubiksApp.CubeConfiguratorModule;
using RubiksCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.CubeSolverModule
{
    public class ConfiguratorModuleCubeProvider : ICubeProvider
    {
        ICubeConfigurationService _cubeConfigurationService;

        public ConfiguratorModuleCubeProvider(ICubeConfigurationService cubeConfigurationService)
        {
            _cubeConfigurationService = cubeConfigurationService;
        }

        public RubiksCube ProvideCube()
        {
            return _cubeConfigurationService.GetCube();
        }
    }
}
