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
using Microsoft.Practices.Prism.PubSubEvents;

namespace RubiksApp.CubeSolverModule
{
    [Module(ModuleName="CubeSolverModule")]
    [ModuleDependency("CubeConfiguratorModule")]
    public class CubeSolverModule : IModule
    {
        IRegionViewRegistry _viewRegistry;
        ICubeConfigurationService _cubeConfigurationService;
        IEventAggregator _eventAggregator;

        public CubeSolverModule(IRegionViewRegistry viewRegistry, ICubeConfigurationService cubeConfigurationService, IEventAggregator eventAggregator)
        {
            _viewRegistry = viewRegistry;
            _cubeConfigurationService = cubeConfigurationService;
            _eventAggregator = eventAggregator;
        }
        public void Initialize()
        {
            ICubeRunnerRegistrar registrar = new CubeRunnerRegistrar(new CubeRunnerFactory(_cubeConfigurationService), _eventAggregator);
            CubeRunnerPanelVM panelVm = new CubeRunnerPanelVM(registrar, _cubeConfigurationService);
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
