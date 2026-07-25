using System;
using System.Windows.Forms;
using NP.Services.Plugins;
using NP.Core.Models;

namespace NP.UI.Controls.Plugins
{
    public partial class PluginExplorerControl : UserControl
    {
        private PluginRegistry _manager;

        public PluginExplorerControl()
        {
            InitializeComponent();

            _manager = new PluginRegistry();

            LoadTestPlugins();
        }

        public PluginRegistry Manager
        {
            get
            {
                return _manager;
            }
        }

        private void LoadTestPlugins()
        {
            _manager.Clear();

            dataGridViewVsAddin.Rows.Clear();


            _manager.Add(
                "JsonViewer",
                "UI",
                "1.0",
                "Loaded");

            _manager.Add(
                "RuntimeConsole",
                "UI",
                "1.0",
                "Loaded");

            _manager.Add(
                "AIChat",
                "UI",
                "1.0",
                "Loaded");

            _manager.Add(
                "CommandViewer",
                "UI",
                "1.0",
                "Loaded");

            _manager.Add(
                "ChromeExtension",
                "Bridge",
                "1.0",
                "Connected");

            _manager.Add(
                "VS2012 Addin",
                "Bridge",
                "1.0",
                "Waiting");

            _manager.Add(
                "OpenAI Provider",
                "AI",
                "1.0",
                "Ready");

            FillGrid();
        }

        private void FillGrid()
        {
            dataGridViewVsAddin.Rows.Clear();

            foreach (PluginInfo item in _manager.Plugins)
            {
                dataGridViewVsAddin.Rows.Add(
                    item.Time.ToString("HH:mm:ss"),
                    item.Name,
                    item.Type,
                    item.Status);
            }
        }

        private void toolStripButtonRefresh_Click(
            object sender,
            EventArgs e)
        {
            LoadTestPlugins();
        }

        private void toolStripButtonClear_Click(
            object sender,
            EventArgs e)
        {
            _manager.Clear();

            dataGridViewVsAddin.Rows.Clear();
        }
    }
}