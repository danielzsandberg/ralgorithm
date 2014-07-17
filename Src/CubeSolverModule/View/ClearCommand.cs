using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksApp.CubeSolverModule.View
{
    /// <summary>
    /// Command bound to clear button. Deregisters all CubeRunners
    /// </summary>
    public class ClearCommand : ICommand
    {
        ICubeRunnerRegistrar _cubeRunnerRegistrar;

        public ClearCommand(ICubeRunnerRegistrar cubeRunnerRegistrar)
        {
            _cubeRunnerRegistrar = cubeRunnerRegistrar;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _cubeRunnerRegistrar.DeregisterAll();
        }
    }
}
