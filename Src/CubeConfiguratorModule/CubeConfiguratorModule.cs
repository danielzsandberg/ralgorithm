using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.CubeConfiguratorModule
{
    [Module(ModuleName="CubeConfiguratorModule")]
    public class CubeConfiguratorModule : IModule
    {
        readonly IRegionViewRegistry _viewRegistry;
        readonly IUnityContainer _container;

        public CubeConfiguratorModule(IRegionViewRegistry viewRegistry, IUnityContainer container)
        {
            _viewRegistry = viewRegistry;
            _container = container;
        }

        public void Initialize()
        {
            //Hack to account for WPF quirk where dependencies in module folder do not get loaded.
            Assembly.LoadFrom(@"Modules\RubiksUIControls.dll");

            //Register configuration service with container
            ICubeConfigurationService cubeConfigurationService = new CubeConfigurationService(_container.Resolve<IEventAggregator>());
            _container.RegisterInstance(cubeConfigurationService, new ContainerControlledLifetimeManager());

            //Instantiate and register view
            CubieConfiguratorVM configuratorVm = new CubieConfiguratorVM(cubeConfigurationService);
            CubeConfiguratorControl configuratorView = new CubeConfiguratorControl() { DataContext = configuratorVm };
            _viewRegistry.RegisterViewWithRegion("cubeConfigurator", new Func<object>(() => configuratorView));
        }
    }
}
