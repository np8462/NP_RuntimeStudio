using NP.Services.Commands;
using NP.UI.Forms;
using NP.Services.Infrastructure;
using NP.Services.Runtime;
using System.Windows.Forms;

namespace NP.Services.Services
{
    public class PluginManager : ServiceBase
    {
        public PluginManager(HostForm form, CommandBus bus)
            : base(form, bus)
        {
            bus.CommandReceived += OnCommandReceived;
        }

        private void OnCommandReceived(CommandPacket cmd)
        {
            if (cmd.Command != "plugin_request")
                return;

            Form.Log("PluginManager received: " + cmd.Data);
        }
    }
}

/*
using System.Collections.Generic;

namespace NP.Host.Services
{
    public class PluginManager
    {
        private Dictionary<string, object> _plugins =
            new Dictionary<string, object>();

        public void Register(string name, object plugin)
        {
            if (!_plugins.ContainsKey(name))
                _plugins.Add(name, plugin);
        }

        public object Get(string name)
        {
            if (_plugins.ContainsKey(name))
                return _plugins[name];

            return null;
        }
    }
}
*/