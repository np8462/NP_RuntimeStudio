using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NP.UI.Controls
{
    public partial class InputPanelControl : UserControl
    {
        public InputPanelControl()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            AddMessage(txtInput.Text.Trim());
        }

        public void AddMessage(string text)
        {
            MessageBox.Show(text);
        }
    }
}
