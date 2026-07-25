using System.Windows.Forms;
using NP.Core.Components;

namespace NP.Services.Components
{
    public class RuntimeHost
    {
        //private readonly RuntimeWorkspaceHost _workspace;
        private readonly RuntimeWindowManager _windowManager;

        public RuntimeHost(RuntimeWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public void Run(
            RuntimeInstance instance)
        {
            if (instance == null)
                return;

            switch (instance.TypeInfo.Kind)
            {
                case ComponentKind.Form:

                    RunForm(instance);

                    break;

                case ComponentKind.UserControl:

                    RunUserControl(instance);

                    break;

                case ComponentKind.Control:

                    RunControl(instance);

                    break;

                case ComponentKind.Component:

                    RunComponent(instance);

                    break;
            }
        }

        //-------------------------------------------------

        private void RunForm(
            RuntimeInstance instance)
        {
            Form form =
                instance.Instance as Form;

            if (form == null)
                return;

            _windowManager.Show(form);
        }

        //-------------------------------------------------

        private void RunUserControl(
            RuntimeInstance instance)
        {
            UserControl control =
                instance.Instance as UserControl;

            if (control == null)
                return;

            Form form =
                new Form();

            form.Text =
                instance.TypeInfo.Type.Name;

            control.Dock =
                DockStyle.Fill;

            form.Controls.Add(control);

            _windowManager.Show(form);
        }

        //-------------------------------------------------

        private void RunControl(
            RuntimeInstance instance)
        {
            Control control =
                instance.Instance as Control;

            if (control == null)
                return;

            Form form =
                new Form();

            form.Text =
                instance.TypeInfo.Type.Name;

            control.Dock =
                DockStyle.Fill;

            form.Controls.Add(control);

            _windowManager.Show(form);
        }

        //-------------------------------------------------

        private void RunComponent(
            RuntimeInstance instance)
        {
            IComponent component =
                instance.Instance as IComponent;

            if (component == null)
                return;

            component.Initialize();
        }

        public void Close()
        {
            _windowManager.CloseAll();
        }
    }
}