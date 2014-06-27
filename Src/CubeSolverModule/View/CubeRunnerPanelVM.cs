using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksApp.CubeSolverModule.View
{
    public class CubeRunnerPanelVM
    {
        public ObservableCollection<RunnerBarVM> RunnerBars 
        { 
            get; 
            private set; 
        }

        public ICommand BrowseCommand 
        { 
            get; 
            private set; 
        }

        public ICommand ClearCommand
        {
            get;
            private set;
        }

        public CubeRunnerPanelVM(ICubeRunnerFactory cubeRunnerCreator)
        {
            RunnerBars = new ObservableCollection<RunnerBarVM>();
            BrowseCommand = new BrowseCommand(cubeRunnerCreator, this);
            ClearCommand = new ClearCommand(this);
        }
    }
}
