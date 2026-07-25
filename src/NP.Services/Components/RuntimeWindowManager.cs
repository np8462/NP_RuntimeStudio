using System.Collections.Generic;
using System.Windows.Forms;

namespace NP.Services.Components
{
    public class RuntimeWindowManager
    {
        private readonly List<Form> _forms =
            new List<Form>();

        public IEnumerable<Form> Forms
        {
            get
            {
                return _forms;
            }
        }

        public void Show(Form form)
        {
            if (form == null)
                return;

            form.Show();

            _forms.Add(form);
        }

        public void CloseAll()
        {
            foreach (Form form in _forms)
            {
                if (!form.IsDisposed)
                    form.Close();
            }

            _forms.Clear();
        }
    }
}