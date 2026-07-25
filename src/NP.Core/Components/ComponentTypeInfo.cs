using System;

namespace NP.Core.Components
{
    public class ComponentTypeInfo
    {
        public string Name
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }

        public Type Type
        {
            get;
            set;
        }

        public ComponentKind Kind
        {
            get;
            set;
        }

        public bool CanCreate
        {
            get;
            set;
        }

        public string Namespace
        {
            get;
            set;
        }

        public string BaseType
        {
            get;
            set;
        }

        public Type[] Interfaces
        {
            get;
            set;
        }
    }
}