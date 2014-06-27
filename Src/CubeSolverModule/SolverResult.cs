using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.CubeSolverModule
{
    public class SolverResult
    {
        /// <summary>
        /// Number of moves that the algorithm took to complete
        /// </summary>
        public int MovesToCompletion 
        { 
            get; 
            internal set; 
        }

        /// <summary>
        /// The amount of time that the algorithm took to complete
        /// </summary>
        public TimeSpan TimeToCompletion
        {
            get;
            internal set;
        }

        /// <summary>
        /// True if the cube was solved and false otherwise
        /// </summary>
        public bool WasCubeSolved
        {
            get;
            internal set;
        }

        /// <summary>
        /// True if an exception was thrown by the algorithm and false otherwise
        /// </summary>
        public bool WasThereAnError
        {
            get;
            internal set;
        }

        /// <summary>
        /// Null if there was not an error. Otherwise it should contain the exception's message.
        /// </summary>
        public string ErrorMessage
        {
            get;
            internal set;
        }
    }
}
