using NP.UI.Controls.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NP.UI.Forms
{
    public partial class RuntimeConsoleForm : Form
    {
        public RuntimeConsoleForm()
        {
            InitializeComponent();

            RuntimeConsoleControl console =
                new RuntimeConsoleControl();

            console.Dock = DockStyle.Fill;

            this.Controls.Add(console);
        }
    }
}


