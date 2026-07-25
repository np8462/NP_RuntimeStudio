using System.Collections.Generic;
using System.Windows.Forms;

namespace NP.Services.Components
{
    public class RuntimeWorkspaceHost
    {
        private readonly List<Form> _openedForms =
            new List<Form>();

        public IEnumerable<Form> OpenedForms
        {
            get
            {
                return _openedForms;
            }
        }

        public void Show(Form form)
        {
            if (form == null)
                return;

            form.Show();

            _openedForms.Add(form);
        }

        public void CloseAll()
        {
            foreach (Form form in _openedForms)
            {
                if (!form.IsDisposed)
                    form.Close();
            }

            _openedForms.Clear();
        }
    }
}