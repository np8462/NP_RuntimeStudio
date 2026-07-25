using System.Collections.Generic;

namespace NP.Services.Tools
{
    public class ToolRegistry
    {
        private Dictionary<string, ITool> _tools =
            new Dictionary<string, ITool>();

        public void Register(ITool tool)
        {
            if (!_tools.ContainsKey(tool.Name))
                _tools.Add(tool.Name, tool);
        }

        public ITool Get(string name)
        {
            if (_tools.ContainsKey(name))
                return _tools[name];

            return null;
        }
    }
}