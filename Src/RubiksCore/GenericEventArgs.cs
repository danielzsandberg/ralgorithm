using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCore
{
    public class GenericEventArgs<TEvent> : EventArgs
    {
        public TEvent Event
        {
            get;
            private set;
        }

        public GenericEventArgs(TEvent eventInfo)
        {
            Event = eventInfo;
        }
    }
}
