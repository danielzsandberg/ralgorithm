using Microsoft.Practices.Prism.Commands;
using RubiksCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RubiksApp.CubeConfiguratorModule
{
    public class CubieConfiguratorVM : INotifyPropertyChanged
    {
        #region Instance Variables

        ICommand _hotkeyCommand;
        ICubeConfigurationService _configService; 

        #endregion

        #region Constructors

        public CubieConfiguratorVM(ICubeConfigurationService configService)
        {
            _configService = configService;
            _configService.PropertyChanged += _configService_PropertyChanged;
            _hotkeyCommand = new CubeManipulationCommand(configService);
        } 

        #endregion

        #region Properties

        public RubiksCube Cube
        {
            get
            {
                return _configService.GetCube();
            }
        }

        public ICommand CubeManipulationCommand
        {
            get
            {
                return _hotkeyCommand;
            }
        } 

        #endregion

        #region Methods

        void _configService_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Cube")
            {
                OnPropertyChanged("Cube");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        } 

        #endregion

        #region INotifyPropertyChanged\\Events

        public event PropertyChangedEventHandler PropertyChanged; 

        #endregion

    }
}