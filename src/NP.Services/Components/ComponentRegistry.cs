using System.Collections.Generic;

namespace NP.Services.Components
{
    public class ComponentRegistry
    {
        private readonly List<RuntimeComponent>
            _components =
            new List<RuntimeComponent>();

        public IEnumerable<RuntimeComponent>
            Components
        {
            get
            {
                return _components;
            }
        }

        public void Register(
            RuntimeComponent component)
        {
            if (component == null)
                return;

            _components.Add(component);
        }

        public void Clear()
        {
            _components.Clear();
        }

        public RuntimeComponent FindByName(
    string name)
        {
            foreach (RuntimeComponent item
                in _components)
            {
                if (item.Info.Name == name)
                    return item;
            }

            return null;
        }
    }
}