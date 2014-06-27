using RubiksCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.CubeConfiguratorModule
{
    public class CubeConfigurationService : ICubeConfigurationService
    {
        public RubiksCube _cube;

        public CubeConfigurationService()
        {
            _cube = new RubiksCube();
        }

        public RubiksCube GetCube()
        {
            return _cube;
        }

        public void SetCube(RubiksCube cube)
        {
            _cube = cube;
            OnPropertyChanged("Cube");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
