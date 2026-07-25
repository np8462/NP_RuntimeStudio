using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NP.UI.Controls.JsonViewer
{
    public partial class JsonNodeView : UserControl
    {
        public JsonNodeView()
        {
            InitializeComponent();
        }

        public string JsonText
        {
            get
            {
                return richTextBoxJson.Text;
            }
            set
            {
                richTextBoxJson.Text = value;
            }
        }
    }
}