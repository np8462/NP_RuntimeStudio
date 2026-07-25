using System.Collections.Generic;

namespace NP.Services.Engine
{
    public class PluginEngine
    {
        private readonly List<IPlugin> _plugins =
            new List<IPlugin>();

        public void Register(IPlugin plugin)
        {
            if (plugin == null)
                return;

            _plugins.Add(plugin);

            plugin.Initialize();
        }

        public IEnumerable<IPlugin> GetPlugins()
        {
            return _plugins;
        }
    }
}