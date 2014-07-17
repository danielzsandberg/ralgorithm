using RubiksCore;
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
        #region Properties

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

        #endregion

        #region Constructors

        public CubeRunnerPanelVM(ICubeRunnerRegistrar registrar)
        {
            registrar.RunnersRegistered += registrar_RunnersRegistered;
            registrar.RunnerRegistrationsUpdated += registrar_RunnerRegistrationsUpdated;
            registrar.RunnersDeregistered += registrar_RunnersDeregistered;

            RunnerBars = new ObservableCollection<RunnerBarVM>();
            BrowseCommand = new BrowseCommand(registrar);
            ClearCommand = new ClearCommand(registrar);
        } 

        #endregion

        #region Methods\\Event Handlers

        void registrar_RunnersDeregistered(object sender, GenericEventArgs<IDictionary<Type, CubeRunner>> e)
        {
            RemoveExistingRunnerBars(e.Event);
        }

        void registrar_RunnerRegistrationsUpdated(object sender, GenericEventArgs<IDictionary<Type, CubeRunner>> e)
        {
            RemoveExistingRunnerBars(e.Event);
            AddNewRunnerBars(e.Event);
        }

        void registrar_RunnersRegistered(object sender, GenericEventArgs<IDictionary<Type, CubeRunner>> e)
        {
            AddNewRunnerBars(e.Event);
        }

        #endregion

        #region Methods\\Helpers

        private void AddNewRunnerBars(IDictionary<Type, CubeRunner> newRegistrations)
        {
            foreach (var registration in newRegistrations)
            {
                RunnerBars.Add(new RunnerBarVM(registration.Value));
            }
        }

        private void RemoveExistingRunnerBars(IDictionary<Type, CubeRunner> removedRegistrations)
        {
            foreach (var registration in removedRegistrations)
            {
                RunnerBarVM runnerBarToRemove = RunnerBars.FirstOrDefault(runnerBar => runnerBar.Runner.AlgorithmType.Equals(registration.Key));
                if (runnerBarToRemove != null)
                {
                    RunnerBars.Remove(runnerBarToRemove);
                }
            }
        }
        
        #endregion
    }
}
