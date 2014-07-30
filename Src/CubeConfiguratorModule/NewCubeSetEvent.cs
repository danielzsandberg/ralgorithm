using Microsoft.Practices.Prism.PubSubEvents;
using RubiksCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.CubeConfiguratorModule
{
    /// <summary>
    /// Gets published when a new cube is set on the CubeConfiguratorModule via the SetCube method on the CubeConfigurationService
    /// </summary>
    public class NewCubeSetEvent : PubSubEvent<RubiksCube>
    {
    }
}
