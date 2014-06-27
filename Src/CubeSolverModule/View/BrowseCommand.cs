using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksApp.CubeSolverModule.View
{
    public class BrowseCommand : ICommand
    {
        ICubeRunnerFactory _runnerCreator;
        CubeRunnerPanelVM _panelVM;

        public BrowseCommand(ICubeRunnerFactory runnerCreator, CubeRunnerPanelVM panelVm)
        {
            _runnerCreator = runnerCreator;
            _panelVM = panelVm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Multiselect = true,
                Filter = "Algorithm Library (*.dll)|*.dll"
            };

            bool? result = ofd.ShowDialog();

            if(result != null && result.Value)
            {
                foreach(string fileName in ofd.FileNames)
                {
                    foreach(CubeRunner runner in _runnerCreator.CreateCubeRunners(fileName))
                    {
                        _panelVM.RunnerBars.Add(new RunnerBarVM(runner));
                    }
                }
            }
        }
    }
}
