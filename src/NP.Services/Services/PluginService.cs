using NP.Services.Engine;

namespace NP.Services.Services
{
    public class PluginService
    {
        public PluginEngine Engine
        {
            get;
            private set;
        }

        public PluginService()
        {
            Engine = new PluginEngine();
        }

        public void Register(IPlugin plugin)
        {
            Engine.Register(plugin);
        }
    }
}