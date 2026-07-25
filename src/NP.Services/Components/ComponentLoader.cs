using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NP.Core.Components;
using System.Windows.Forms;

namespace NP.Services.Components
{
    public class ComponentLoader
    {
        private readonly ComponentRegistry _registry;
        private readonly ReflectionScanner _scanner;

        public ComponentLoader(
            ComponentRegistry registry,
            ReflectionScanner scanner)
        {
            _registry = registry;
            _scanner = scanner;
        }

        //-------------------------------------------------
        // Search Workspace
        //-------------------------------------------------

        public IList<ComponentInfo> LoadFolder(
            string folder)
        {
            List<ComponentInfo> list =
                new List<ComponentInfo>();

            if (!Directory.Exists(folder))
                return list;

            string[] files =
                Directory.GetFiles(
                    folder,
                    "*.dll",
                    SearchOption.AllDirectories);

            foreach (string file in files)
            {
                ComponentInfo info =
                    new ComponentInfo();

                info.Name =
                    Path.GetFileNameWithoutExtension(file);

                info.FileName =
                    Path.GetFileName(file);

                info.FilePath =
                    file;

                info.AssemblyPath =
                    file;

                info.Loaded =
                    false;

                list.Add(info);
            }

            return list;
        }

        //-------------------------------------------------
        // Load One DLL
        //-------------------------------------------------
        ComponentInfo _cmpnntInf;
        public bool Load(
            ComponentInfo component)
        {
            try
            {
                if (component == null)
                    return false;

                if (!File.Exists(component.AssemblyPath))
                    return false;

                _cmpnntInf = component;

                Assembly assembly =
                    Assembly.LoadFrom(
                        component.AssemblyPath);

                RuntimeComponent runtime =
                    new RuntimeComponent(
                        component,
                        assembly);

                _scanner.Scan(runtime);

                _registry.Register(runtime);

                component.Loaded = true;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(_cmpnntInf.FileName);

                component.Error =
                    ex.Message;

                component.Loaded =
                    false;

                return false;
            }
        }
    }
}