using System.Reflection;
using NP.Core.Components;

namespace NP.Services.Components
{
    public class DependencyScanner
    {
        public DependencyInfo Scan(
            string dllFile)
        {
            AssemblyName assembly =
                AssemblyName.GetAssemblyName(
                    dllFile);

            DependencyInfo info =
                new DependencyInfo();

            info.AssemblyName =
                assembly.Name;

            Assembly reflection =
                Assembly.ReflectionOnlyLoadFrom(
                    dllFile);

            foreach (AssemblyName item
                in reflection.GetReferencedAssemblies())
            {
                info.References.Add(
                    item.Name);
            }

            return info;
        }
    }
}