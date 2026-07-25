using System.Collections.Generic;

namespace NP.Services.Runtime
{
    public class RuntimeStateBag
    {
        public Dictionary<string, object> Items { get; private set; }

        public RuntimeStateBag()
        {
            Items = new Dictionary<string, object>();
        }
    }
}