using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksApp.CubeSolverModule.View
{
    public class RunCommand : ICommand
    {
        CubeRunner _runner;
        RunnerBarVM _runnerBarVM;

        public RunCommand(CubeRunner runner, RunnerBarVM runnerBarVM)
        {
            _runner = runner;
            _runnerBarVM = runnerBarVM;
        }
        public bool CanExecute(object parameter)
        {
            return _runner.RunnerState != CubeRunnerState.Running;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            SolverResult result = _runner.Run();
            _runnerBarVM.LastRunsResult = result;
            _runnerBarVM.AllResults.Add(result);
        }
    }
}
