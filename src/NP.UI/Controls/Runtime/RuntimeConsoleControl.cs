using System;
using System.Windows.Forms;
using NP.Services.Runtime;
using System.IO;
using NP.Core.Models;

namespace NP.UI.Controls.Runtime
{
    public partial class RuntimeConsoleControl : UserControl
    {
        private RuntimeLogger _logger;

        public RuntimeConsoleControl()
        {
            InitializeComponent();

            _logger = new RuntimeLogger();

            _logger.LogAdded += Logger_LogAdded;

            _logger.Write("Runtime initialized");

            _logger.Write("Console ready");

            _logger.Write("JsonViewer loaded");

            _logger.Write("Runtime started");

            _logger.Write("Test message");

            _logger.Write("Waiting...");
        }

        private void Logger_LogAdded(RuntimeLogEntry entry)
        {
            richTextBoxLog.AppendText(
                entry.Time.ToString("HH:mm:ss")
                + " - "
                + entry.Message
                + Environment.NewLine);
        }

        public RuntimeLogger Logger
        {
            get
            {
                return _logger;
            }
        }
        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Clear();
        }
        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            if (richTextBoxLog.SelectedText != "")
            {
                Clipboard.SetText(
                    richTextBoxLog.SelectedText);
            }
            else
            {
                Clipboard.SetText(
                    richTextBoxLog.Text);
            }
        }
        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter =
                "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            dlg.FileName =
                "RuntimeLog_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss")
                + ".txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(
                    dlg.FileName,
                    richTextBoxLog.Text);

                MessageBox.Show(
                    "Log saved successfully.");
            }
        }
        private void toolStripButtonTest_Click(object sender, EventArgs e)
        {
            _logger.Write(
                "Manual test : "
                + DateTime.Now.ToLongTimeString());
        }
    }
}