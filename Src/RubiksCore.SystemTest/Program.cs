using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCore.SystemTest
{
    class Program
    {
        static RubiksCube cube;
        static StreamWriter streamWriter;
        static void Main(string[] args)
        {
            using (streamWriter = new StreamWriter("rubiks.txt"))
            {
                //Load the cube
                LoadCube(30);
                PrintCube();

                //Make turns of the cube
                TurnCubeBack();
                PrintCube();

                TurnCubeDown();
                PrintCube();

                TurnCubeFront();
                PrintCube();

                TurnCubeLeft();
                PrintCube();

                Console.ReadLine();
            }

        }

        static void LoadCube(int sides)
        {
            WriteText("Loading cube...");
            cube = new RubiksCube(null, sides);
            WriteText(" Cube loaded!");
        }

        static void PrintCube()
        {
            WriteText("Printing cube state...");
            WriteText(cube.ToString());
        }

        static void TurnCubeBack()
        {
            WriteText("Turning cube (back)...");
            cube.TurnBack();
            WriteText("Cube turned!");
        }

        static void TurnCubeDown()
        {
            Console.WriteLine("Turning cube (down)...");
            cube.TurnDown();
            Console.WriteLine("Cube turned!");
        }

        static void TurnCubeFront()
        {
            WriteText("Turning cube (front)...");
            cube.TurnFront();
            WriteText("Cube turned!");
        }

        static void TurnCubeLeft()
        {
            WriteText("Turning cube (left)...");
            cube.TurnLeft();
            WriteText("Cube turned!");
        }

        static void WriteText(string text)
        {
            Console.WriteLine(text);
            streamWriter.WriteLine(text);
        }
    }
}
