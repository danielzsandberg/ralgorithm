using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksApp.AboutDialog
{
    public class AboutCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            AboutDialog dialog = new AboutDialog();
            dialog.DataContext = new AboutDialogVM();
            dialog.ShowDialog();
        }
    }
}
