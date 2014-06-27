using System.Collections.Generic;

namespace RubiksCore
{
    public interface INotationParser
    {
        KeyValuePair<RubiksDirection, TurningDirection>[] ParseNotation(string notationString);
    }
}

