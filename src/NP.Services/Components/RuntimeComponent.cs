using System.Collections.Generic;
using System.Reflection;
using NP.Core.Components;

namespace NP.Services.Components
{
    public class RuntimeComponent
    {
        public ComponentInfo Info
        {
            get;
            private set;
        }

        public Assembly Assembly
        {
            get;
            private set;
        }

        public IList<ComponentTypeInfo> Types
        {
            get;
            private set;
        }

        public RuntimeComponent(
            ComponentInfo info,
            Assembly assembly)
        {
            Info = info;

            Assembly = assembly;

            Types =
                new List<ComponentTypeInfo>();
        }
    }
}