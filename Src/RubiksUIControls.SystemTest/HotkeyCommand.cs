using RubiksCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksUIControls.SystemTest
{
    public class HotkeyCommand : ICommand
    {
        private RubiksCube _cube;
        public HotkeyCommand(RubiksCube cube)
        {
            _cube = cube;
        }

        public bool CanExecute(object parameter)
        {
            return _cube != null;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            string direction = (string)parameter;
            if(direction == "left")
            {
                _cube.TurnLeft();
            }
            else if(direction == "right")
            {
                _cube.TurnRight();
            }
            else if (direction == "up")
            {
                _cube.TurnUp();
            }
            else if (direction == "down")
            {
                _cube.TurnDown();
            }
            else if (direction == "front")
            {
                _cube.TurnFront();
            }
            else if (direction == "back")
            {
                _cube.TurnBack();
            }
        }
    }
}
