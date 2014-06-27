using RubiksCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RubiksCore.RubiksUIControls
{
    /// <summary>
    /// Interaction logic for TwoDCube.xaml
    /// </summary>
    public partial class TwoDCube : UserControl
    {
        public TwoDCube()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CubeProperty =
            DependencyProperty.Register("Cube", typeof(RubiksCube), typeof(TwoDCube),
            new PropertyMetadata(RubiksCubeSet));

        private static void RubiksCubeSet(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RubiksCube newCube = (RubiksCube)e.NewValue;
            RubiksCube oldCube = (RubiksCube)e.OldValue;
            TwoDCube twoDCube = (TwoDCube)d;

            twoDCube.ReinitializeCubes(oldCube, newCube);
            twoDCube.PopulateCube();
        }

        

        public RubiksCube Cube
        {
            get
            {
                return (RubiksCube)GetValue(CubeProperty);
            }
            set
            {
                SetValue(CubeProperty, value);
            }
        }

        private void ReinitializeCubes(RubiksCube oldCube, RubiksCube newCube)
        {
            if (oldCube != null)
            {
                oldCube.CubeTurned -= cubeTurned;
            }

            newCube.CubeTurned += cubeTurned;
        }

        void cubeTurned(object sender, GenericEventArgs<CubeTurnedEvent> e)
        {
            PopulateCube();
        }

        private void PopulateCube()
        {
            _cubeGrid.RowDefinitions.Clear();
            _cubeGrid.ColumnDefinitions.Clear();
            _cubeGrid.Children.Clear();
            for(int row = 0; row < Cube.CubeSize * 3; row++)
            {
                _cubeGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1.0/(Cube.CubeSize * 3), GridUnitType.Star) });
            }

            for(int column = 0; column < Cube.CubeSize * 4; column++)
            {
                _cubeGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0/(Cube.CubeSize * 4), GridUnitType.Star) });
            }

            foreach(TwoDPosition position in CreatePositionsForCube())
            {
                CreateRect(Cube.GetColor(position), position.Y, position.X);
            }
        }

        private void CreateRect(Color color, int rowNumber, int columnNumber)
        {
            Border border = new Border();
            border.CornerRadius = new CornerRadius(1);
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Thickness(3);
            
            Rectangle rect = new Rectangle();
            rect.Fill = new SolidColorBrush(color);

            border.Child = rect;

            _cubeGrid.Children.Add(border);
            Grid.SetColumn(border, columnNumber);
            Grid.SetRow(border, rowNumber);
        }

        private IEnumerable<TwoDPosition> CreatePositionsForCube()
        {
            List<TwoDPosition> positions = new List<TwoDPosition>();

            //Horizontal part
            for (int y = Cube.CubeSize; y < Cube.CubeSize * 2; y++)
            {
                for(int x = 0; x < Cube.CubeSize * 4; x++)
                {
                    positions.Add(new TwoDPosition(x, y));
                }
            }

            //Vertical part
            for (int x = Cube.CubeSize; x < Cube.CubeSize * 2; x++)
            {
                for(int y = 0; y < Cube.CubeSize; y++)
                {
                    positions.Add(new TwoDPosition(x, y));
                }

                for(int y = Cube.CubeSize * 2 - 1; y < Cube.CubeSize * 3; y++)
                {
                    positions.Add(new TwoDPosition(x, y));
                }
            }

            return positions;
        }
    }
}
