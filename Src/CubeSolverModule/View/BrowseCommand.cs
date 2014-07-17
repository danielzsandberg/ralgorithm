using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksApp.CubeSolverModule.View
{
    /// <summary>
    /// Command bound to the browse button. Registers new algorithms.
    /// </summary>
    public class BrowseCommand : ICommand
    {
        ICubeRunnerRegistrar _cubeRunnerRegistrar;

        public BrowseCommand(ICubeRunnerRegistrar cubeRunnerRegistrar)
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
                    _cubeRunnerRegistrar.Register(Assembly.LoadFrom(fileName));
                }
            }
        }
    }
}
