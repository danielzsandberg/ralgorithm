using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RubiksApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Bootstrapper _bootstrapper;
        protected override void OnStartup(StartupEventArgs e)
        {
            _bootstrapper = new Bootstrapper();
            _bootstrapper.Run();
            base.OnStartup(e);
        }
    }
}
