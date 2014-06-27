using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksApp.CubeSolverModule.View
{
    public class ClearCommand : ICommand
    {
        CubeRunnerPanelVM _cubeRunnerPanelVm;

        public ClearCommand(CubeRunnerPanelVM cubeRunnerPanelVm)
        {
            _cubeRunnerPanelVm = cubeRunnerPanelVm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _cubeRunnerPanelVm.RunnerBars.Clear();
        }
    }
}
