using RubiksApp.RubiksAlgorithmToolset;
using RubiksCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.CubeSolverModule
{
    public class CubeRunner : INotifyPropertyChanged
    {
        #region Instance Variables

        CubeRunnerState _state;
        RubiksCube _cube;
        ICubeSolvingAlgorithm _alg;
        int _numberOfTurns;

        #endregion

        #region Constructors

        internal CubeRunner(RubiksCube cube, ICubeSolvingAlgorithm algorithm)
        {
            _cube = cube;
            _alg = algorithm;

            _state = CubeRunnerState.Stopped;
        } 

        #endregion

        #region Properties

        /// <summary>
        /// Represents the current state of the runner
        /// </summary>
        public CubeRunnerState RunnerState
        {
            get
            {
                return _state;
            }
            private set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged("RunnerState");
                }
            }
        }
 
        public string AlgorithmName
        {
            get
            {
                return _alg.AlgorithmName;
            }
        }

        public string AlgorithmDescription
        {
            get
            {
                return _alg.Description;
            }
        }

        public string AlgorithmAuthor
        {
            get
            {
                return _alg.Author;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Runs the algorithm.
        /// </summary>
        /// <returns>The results of the run</returns>
        public SolverResult Run()
        {
            RunnerState = CubeRunnerState.Running;

            _cube.CubeTurned += _cube_CubeTurned;
            _numberOfTurns = 0;

            bool wasError = false;
            string errorMessage = null;

            Stopwatch timer = new Stopwatch();
            timer.Start();
            try
            {
                _alg.Solve(_cube);
            }
            catch(Exception ex)
            {
                wasError = true;
                errorMessage = ex.Message;
            }
            timer.Stop();

            SolverResult result = new SolverResult() 
            {
                WasCubeSolved = _cube.IsSolved,
                WasThereAnError = wasError,
                ErrorMessage = errorMessage,
                TimeToCompletion = timer.Elapsed,
                MovesToCompletion = _numberOfTurns
            };

            _cube.CubeTurned -= _cube_CubeTurned;

            RunnerState = CubeRunnerState.Stopped;

            return result;
        }

        void _cube_CubeTurned(object sender, GenericEventArgs<CubeTurnedEvent> e)
        {
            _numberOfTurns++;
        }

        #endregion

        #region INotifyPropertyChanged\\Events

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        } 

        #endregion
    }
}
