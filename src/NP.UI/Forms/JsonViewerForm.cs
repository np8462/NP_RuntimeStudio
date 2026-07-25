using System;
using System.IO;
using System.Windows.Forms;
using NP.Services.Json;
using NP.UI.Controls.JsonViewer;

namespace NP.UI.Forms
{
    public partial class JsonViewerForm : Form
    {
        private JsonTreeBuilder _builder;

        public JsonViewerForm()
        {
            InitializeComponent();

            _builder = new JsonTreeBuilder();

            jsonTreeView1.NodeChanged += JsonTreeView1_NodeChanged;
        }

        public void OpenFile(string path)
        {
            string json = File.ReadAllText(path);

            richTextBoxJsonRaw.Text = json;

            var model = _builder.Build(json);

            jsonTreeView1.LoadModel(model);

            jsonNodeView1.JsonText = json;

            statusStrip1.Items.Clear();
            statusStrip1.Items.Add("Loaded: " + Path.GetFileName(path));
        }

        private void JsonTreeView1_NodeChanged(JsonNodeEventArgs e)
        {
            txtPath.Text = e.Path;

            HighlightAndScroll(e.Text);
        }

        private void HighlightAndScroll(string text)
        {
            int index = richTextBoxJsonRaw.Text.IndexOf(text);

            if (index >= 0)
            {
                // انتخاب متن
                richTextBoxJsonRaw.SelectionStart = index;
                richTextBoxJsonRaw.SelectionLength = text.Length;

                // هایلایت (اگر RichTextBox پشتیبانی کند)
                richTextBoxJsonRaw.SelectionBackColor =
                    System.Drawing.Color.Yellow;

                // رفتن به محل متن
                richTextBoxJsonRaw.ScrollToCaret();

                // برگرداندن فوکوس به Search
                txtSearch.Focus();
            }
        }

        private void HighlightText(string text)
        {
            int index = richTextBoxJsonRaw.Text.IndexOf(text);

            if (index >= 0)
            {
                richTextBoxJsonRaw.Focus();

                richTextBoxJsonRaw.SelectAll();
                richTextBoxJsonRaw.SelectionBackColor = System.Drawing.Color.White;

                richTextBoxJsonRaw.Select(index, text.Length);
                richTextBoxJsonRaw.SelectionBackColor = System.Drawing.Color.Yellow;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.Text = txtSearch.Text;

            SearchAndHighlight(txtSearch.Text);
        }

        private void SearchAndHighlight(string keyword)
        {
            if (keyword == "")
                return;

            int index = richTextBoxJsonRaw.Text.IndexOf(keyword);

            if (index >= 0)
            {
                // richTextBoxJsonRaw.Focus();  ← حذف شود

                richTextBoxJsonRaw.Select(index, keyword.Length);

                richTextBoxJsonRaw.SelectionBackColor = System.Drawing.Color.Yellow;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "JSON Files (*.json)|*.json|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                JsonViewerForm viewer = new JsonViewerForm();
                viewer.OpenFile(dlg.FileName);
                viewer.Show();
            }
        }
    }
}