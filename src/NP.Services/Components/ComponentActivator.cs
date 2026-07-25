using System;
using System.Collections.Generic;
using NP.Core.Components;

namespace NP.Services.Components
{
    public class ComponentActivator
    {
        public RuntimeInstance Create(
            ComponentTypeInfo info)
        {
            RuntimeInstance runtime =
                new RuntimeInstance();

            runtime.TypeInfo = info;

            try
            {
                if (!info.CanCreate)
                {
                    runtime.Created = false;
                    runtime.Error =
                        "Type cannot be created.";

                    return runtime;
                }

                runtime.Instance =
                    Activator.CreateInstance(
                        info.Type);

                runtime.Created = true;
            }
            catch (Exception ex)
            {
                runtime.Created = false;
                runtime.Error = ex.Message;
            }

            return runtime;
        }

        //--------------------------------------------------

        public IList<RuntimeInstance> CreateInstances(
            RuntimeComponent component)
        {
            List<RuntimeInstance> list =
                new List<RuntimeInstance>();

            if (component == null)
                return list;

            foreach (ComponentTypeInfo item
                in component.Types)
            {
                switch (item.Kind)
                {
                    case ComponentKind.Form:
                    case ComponentKind.UserControl:
                    case ComponentKind.Control:
                    case ComponentKind.Component:
                        break;

                    default:
                        continue;
                }
                
                RuntimeInstance runtime =
                    Create(item);

                list.Add(runtime);
            }

            return list;
        }
    }
}