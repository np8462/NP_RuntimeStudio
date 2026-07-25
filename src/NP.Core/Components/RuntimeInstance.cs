using System;

namespace NP.Core.Components
{
    public class RuntimeInstance
    {
        public ComponentTypeInfo TypeInfo
        {
            get;
            set;
        }

        public object Instance
        {
            get;
            set;
        }

        public bool Created
        {
            get;
            set;
        }

        public string Error
        {
            get;
            set;
        }
    }
}