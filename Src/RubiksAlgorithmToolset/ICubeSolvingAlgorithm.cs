using RubiksCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksApp.RubiksAlgorithmToolset
{
    public interface ICubeSolvingAlgorithm
    {
        string AlgorithmName { get; }
        string Author { get; }
        string Description { get; }
        void Solve(RubiksCube cube);
    }
}
