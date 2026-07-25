using System;
using System.Reflection;

namespace NP.Services.Tools
{
    public static class ReflectionHelper
    {
        public static object CreateInstance(string typeName)
        {
            Type type = Type.GetType(typeName);

            if (type == null)
                return null;

            return Activator.CreateInstance(type);
        }
    }
}