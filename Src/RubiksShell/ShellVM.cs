using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksApp
{
    public class ShellVM
    {
        public ICommand QuickStartCommand { get; set; }
        public ICommand AboutCommand { get; set; }
    }
}
