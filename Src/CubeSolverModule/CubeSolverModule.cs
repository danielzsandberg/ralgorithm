using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubiksApp.CubeSolverModule.View;
using RubiksApp.CubeConfiguratorModule;
using System.IO;
using System.Diagnostics;
using System.Reflection;

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
            ICubeRunnerRegistrar registrar = new CubeRunnerRegistrar(new CubeRunnerFactory(_cubeProvider));
            CubeRunnerPanelVM panelVm = new CubeRunnerPanelVM(registrar);
            DirectoryInfo algorithmsDirectory = new DirectoryInfo("./Algorithms");
            if(algorithmsDirectory.Exists)
            {
                foreach(FileInfo file in algorithmsDirectory.EnumerateFiles())
                {
                    Assembly dllToSearchForAlgorithms = null;

                    try
                    {
                        dllToSearchForAlgorithms = Assembly.LoadFrom(file.FullName);
                    }
                    catch(Exception ex)
                    {
                        Trace.WriteLine(string.Format("Could not load file: {0}. Exception message: {1}.", file.FullName, ex.Message));
                    }

                    if(dllToSearchForAlgorithms != null)
                    {
                        registrar.Register(dllToSearchForAlgorithms);
                    }
                }
            }
            _viewRegistry.RegisterViewWithRegion("solver", new Func<object>(() => new CubeRunnerPanel(){DataContext = panelVm}));
        }
    }
}
