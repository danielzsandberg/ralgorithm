using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubiksApp.CubeSolverModule.View;
using RubiksApp.CubeConfiguratorModule;

namespace RubiksApp.CubeSolverModule
{
    [Module(ModuleName="CubeSolverModule")]
    [ModuleDependency("CubeConfiguratorModule")]
    public class CubeSolverModule : IModule
    {
        IRegionViewRegistry _viewRegistry;
        ICubeProvider _cubeProvider;

        public CubeSolverModule(IRegionViewRegistry viewRegistry, ICubeConfigurationService cubeConfigurationService)
        {
            _viewRegistry = viewRegistry;
            _cubeProvider = new ConfiguratorModuleCubeProvider(cubeConfigurationService);
        }
        public void Initialize()
        {
            CubeRunnerPanelVM panelVm = new CubeRunnerPanelVM(new CubeRunnerFactory(_cubeProvider));
            _viewRegistry.RegisterViewWithRegion("solver", new Func<object>(() => new CubeRunnerPanel(){DataContext = panelVm}));
        }
    }
}
