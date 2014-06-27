using RubiksCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksUIControls.SystemTest
{
    class TestWindowVM
    {
        private RubiksCube _cube = new RubiksCube(null, 3);

        public RubiksCube RubiksCube
        {
            get
            {
                return _cube;
            }
        }

        public ICommand HotKeyCommand
        {
            get
            {
                return new HotkeyCommand(_cube);
            }
        }
    }
}
