using System;
using System.Collections.Generic;
using NP.Core.Models;

namespace NP.Services.Plugins
{
    public class PluginRegistry
    {
        private readonly List<PluginInfo> _plugins;

        public PluginRegistry()
        {
            _plugins =
                new List<PluginInfo>();
        }

        public IList<PluginInfo> Plugins
        {
            get
            {
                return _plugins;
            }
        }

        public void Add(
            string name,
            string type,
            string version,
            string status)
        {
            PluginInfo item =
                new PluginInfo();

            item.Name = name;
            item.Type = type;
            item.Version = version;
            item.Status = status;
            item.Time = DateTime.Now;

            _plugins.Add(item);
        }

        public void LoadDefaults()
        {
            _plugins.Clear();

            Add(
                "JsonViewer",
                "UI",
                "1.0",
                "Loaded");

            Add(
                "RuntimeConsole",
                "UI",
                "1.0",
                "Loaded");

            Add(
                "AIChat",
                "AI",
                "1.0",
                "Loaded");

            Add(
                "ChromeExtension",
                "Bridge",
                "1.0",
                "Loaded");

            Add(
                "VS2012Addin",
                "Bridge",
                "1.0",
                "Loaded");
        }

        public void Clear()
        {
            _plugins.Clear();
        }
    }
}