using RubiksCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.CubeConfiguratorModule
{
    /// <summary>
    /// Provides the ability to access and modify the cube that is currently under configuration
    /// </summary>
    public interface ICubeConfigurationService
    {
        /// <summary>
        /// Provides a reference to the cube that is under configuration.
        /// </summary>
        /// <returns></returns>
        RubiksCube GetCube();

        /// <summary>
        /// Replaces the cube under configuration with the one that is passed into this method.
        /// </summary>
        /// <param name="cube">The cube that will replace the one currently under configuraiton</param>
        void SetCube(RubiksCube cube);

        /// <summary>
        /// Raised when a new cube is set via the SetCube method.
        /// </summary>
        event EventHandler<GenericEventArgs<RubiksCube>> NewCubeSet;
 
    }
}
