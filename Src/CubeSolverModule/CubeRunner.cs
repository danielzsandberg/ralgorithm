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

        /// <summary>
        /// Returns the type of the algorithm that is being run.
        /// </summary>
        public Type AlgorithmType
        {
            get
            {
                return _alg.GetType();
            }
        }

        /// <summary>
        /// The cube that is being solved.
        /// </summary>
        public RubiksCube Cube
        {
            get
            {
                return _cube;
            }
            set
            {
                if(_cube != value)
                {
                    _cube = value;
                    OnPropertyChanged("Cube");
                }
            }
        }

        /// <summary>
        /// If true then the state of the cube will be printed out to the output window every time the cube is turned.
        /// </summary>
        public bool IsInDebugMode
        {
            get
            {
                return Debugger.IsAttached;
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

            if (IsInDebugMode)
            {
                Trace.WriteLine(string.Format("**********Running {0} on {1}**********", AlgorithmType.Name, DateTime.Now));
                Trace.WriteLine("**********Initial state**********");
                Trace.WriteLine(Create2DRubiksString(Cube));
            }

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

            if(IsInDebugMode)
            {
                Trace.WriteLine("**********Finished.**********");
            }

            RunnerState = CubeRunnerState.Stopped;

            return result;
        }

        void _cube_CubeTurned(object sender, GenericEventArgs<CubeTurnedEvent> e)
        {
            _numberOfTurns++;
            if (IsInDebugMode)
            {
                Trace.WriteLine(string.Format("**********Move Number: {0}, Face: {1}, Direction: {2}, Number of Layers:{3}**********", _numberOfTurns,
                    Enum.GetName(typeof(RubiksDirection), e.Event.FaceTurned), Enum.GetName(typeof(TurningDirection), e.Event.DirectionOfTurn),
                    e.Event.NumberOfLayersDeep.ToString()));
                Trace.WriteLine(Create2DRubiksString(sender as RubiksCube));
            }
        }

        private string Create2DRubiksString(RubiksCube cube)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("   {0}{1}{2}      \n", cube.GetColor(3, 0), cube.GetColor(4, 0), cube.GetColor(5, 0));
            builder.AppendFormat("   {0}{1}{2}      \n", cube.GetColor(3, 1), cube.GetColor(4, 1), cube.GetColor(5, 1));
            builder.AppendFormat("   {0}{1}{2}      \n", cube.GetColor(3, 2), cube.GetColor(4, 2), cube.GetColor(5, 2));
            builder.AppendFormat("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}\n", cube.GetColor(0, 3), cube.GetColor(1, 3), cube.GetColor(2, 3), cube.GetColor(3, 3), cube.GetColor(4, 3), cube.GetColor(5, 3), cube.GetColor(6, 3), cube.GetColor(7, 3), cube.GetColor(8, 3), cube.GetColor(9, 3), cube.GetColor(10, 3), cube.GetColor(11, 3));
            builder.AppendFormat("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}\n", cube.GetColor(0, 4), cube.GetColor(1, 4), cube.GetColor(2, 4), cube.GetColor(3, 4), cube.GetColor(4, 4), cube.GetColor(5, 4), cube.GetColor(6, 4), cube.GetColor(7, 4), cube.GetColor(8, 4), cube.GetColor(9, 4), cube.GetColor(10, 4), cube.GetColor(11, 4));
            builder.AppendFormat("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}\n", cube.GetColor(0, 5), cube.GetColor(1, 5), cube.GetColor(2, 5), cube.GetColor(3, 5), cube.GetColor(4, 5), cube.GetColor(5, 5), cube.GetColor(6, 5), cube.GetColor(7, 5), cube.GetColor(8, 5), cube.GetColor(9, 5), cube.GetColor(10, 5), cube.GetColor(11, 5));
            builder.AppendFormat("   {0}{1}{2}      \n", cube.GetColor(3, 6), cube.GetColor(4, 6), cube.GetColor(5, 6));
            builder.AppendFormat("   {0}{1}{2}      \n", cube.GetColor(3, 7), cube.GetColor(4, 7), cube.GetColor(5, 7));
            builder.AppendFormat("   {0}{1}{2}      ", cube.GetColor(3, 8), cube.GetColor(4, 8), cube.GetColor(5, 8));

            return builder.ToString();
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
