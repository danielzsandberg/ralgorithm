using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksApp.CubeSolverModule.View
{
    public class RunnerBarVM : INotifyPropertyChanged
    {
        #region Instance Variables

        SolverResult _lastRunsResult;
        ObservableCollection<SolverResult> _allResults = new ObservableCollection<SolverResult>();

        #endregion

        #region Properties

        public CubeRunner Runner
        {
            get;
            private set;
        }

        public SolverResult LastRunsResult
        {
            get
            {
                return _lastRunsResult;
            }
            set
            {
                _lastRunsResult = value;
                OnPropertyChanged("LastRunsResult");
            }
        }

        public ObservableCollection<SolverResult> AllResults
        {
            get
            {
                return _allResults;
            }
            set
            {
                _allResults = value;
                OnPropertyChanged("AllResults");
            }
        }

        public ICommand RunCommand
        {
            get;
            private set;
        }

        #endregion

        #region Constructors

        public RunnerBarVM(CubeRunner runner)
        {
            Runner = runner;
            RunCommand = new RunCommand(runner, this);
        }

        #endregion

        #region INotifyPropertyChanged\\Events

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
