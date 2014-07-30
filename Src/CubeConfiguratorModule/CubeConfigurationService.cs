using Microsoft.Practices.Prism.PubSubEvents;
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
        #region Instance Variables
        
        RubiksCube _cube;
        IEventAggregator _eventAggregator; 

        #endregion

        #region Constructors

        public CubeConfigurationService(IEventAggregator eventAggregator)
            : this()
        {
            _eventAggregator = eventAggregator;
        }

        public CubeConfigurationService()
        {
            _cube = new RubiksCube();
        } 

        #endregion

        #region Methods\\ICubeConfigurationService
        
        public RubiksCube GetCube()
        {
            return _cube;
        }

        public void SetCube(RubiksCube cube)
        {
            _cube = cube;
            OnNewCubeSet(cube);
        } 

        #endregion

        #region Events\\ICubeConfigurationService

        public event EventHandler<GenericEventArgs<RubiksCube>> NewCubeSet;

        protected virtual void OnNewCubeSet(RubiksCube newCube)
        {
            EventHandler<GenericEventArgs<RubiksCube>> handler = NewCubeSet;
            if (handler != null)
            {
                handler(this, new GenericEventArgs<RubiksCube>(newCube));
            }
            if(_eventAggregator != null)
            {
                _eventAggregator.GetEvent<NewCubeSetEvent>().Publish(newCube);
            }
        } 

        #endregion
    }
}
