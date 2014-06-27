using RubiksCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.CubeSolverModule
{
    public interface ICubeProvider
    {
        /// <summary>
        /// Provides a Rubiks Cube to solve.
        /// </summary>
        /// <returns>An instance of a RubiksCube</returns>
        RubiksCube ProvideCube();
    }
}
