
using System.Collections.Generic;

namespace RubiksCore
{
    public interface ICubieConfigurator
    {
        IEnumerable<Cubie> CreateCubies(int cubeSize);
    }
}
