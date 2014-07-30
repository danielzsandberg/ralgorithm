using RubiksCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksApp.CubeConfiguratorModule
{
    public class CubeManipulationCommand : ICommand
    {
        ICubeConfigurationService _cubeConfigService;
        public CubeManipulationCommand(ICubeConfigurationService cubeConfigService)
        {
            _cubeConfigService = cubeConfigService;
        }

        public bool CanExecute(object parameter)
        {
            return _cubeConfigService != null;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            string direction = (string)parameter;

            RubiksCube currentCube = _cubeConfigService.GetCube();

            if (direction == "left")
            {
                currentCube.TurnLeft();
            }
            else if (direction == "right")
            {
                currentCube.TurnRight();
            }
            else if (direction == "up")
            {
                currentCube.TurnUp();
            }
            else if (direction == "down")
            {
                currentCube.TurnDown();
            }
            else if (direction == "front")
            {
                currentCube.TurnFront();
            }
            else if (direction == "back")
            {
                currentCube.TurnBack();
            }
            else if(direction == "shuffle")
            {
                currentCube.Shuffle();
            }

            _cubeConfigService.SetCube(currentCube.Copy());
        }
    }
}
