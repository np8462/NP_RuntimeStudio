using System;
using System.Reflection;
using System.Windows.Forms;
using NP.Core.Components;

namespace NP.Services.Components
{
    public class ReflectionScanner
    {
        public void Scan(
            RuntimeComponent runtime)
        {
            if (runtime == null)
                return;

            foreach (Type type in runtime.Assembly.GetTypes())
            {
                ComponentTypeInfo item =
                    new ComponentTypeInfo();

                item.Name =
                    type.Name;

                item.FullName =
                    type.FullName;
                
                item.Namespace =
                    type.Namespace;

                item.BaseType =
                    type.BaseType != null
                        ? type.BaseType.FullName
                        : "";

                item.Interfaces =
                    type.GetInterfaces();

                item.Type =
                    type;

                item.CanCreate =
                    !type.IsAbstract &&
                    type.GetConstructor(Type.EmptyTypes) != null;

                //--------------------------------

                if (typeof(Form).IsAssignableFrom(type))
                {
                    item.Kind =
                        ComponentKind.Form;
                }
                else
                    if (typeof(UserControl).IsAssignableFrom(type))
                    {
                        item.Kind =
                            ComponentKind.UserControl;
                    }
                    else
                        if (typeof(Control).IsAssignableFrom(type))
                        {
                            item.Kind =
                                ComponentKind.Control;
                        }
                        else
                            if (typeof(IComponent).IsAssignableFrom(type))
                            {
                                item.Kind =
                                    ComponentKind.Component;
                            }
                            else
                            {
                                item.Kind =
                                    ComponentKind.Class;
                            }

                runtime.Types.Add(item);
            }
        }
    }
}