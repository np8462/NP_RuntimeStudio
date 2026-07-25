using System;
using System.Windows.Forms;
using NP.Core.Models;
using NP.Services.VSExtension;

namespace NP.UI.Controls.VSExtension
{
    public partial class VsAddinControl : UserControl
    {
        private VsAddinManager _manager;

        public VsAddinControl()
        {
            InitializeComponent();

            _manager =
                new VsAddinManager();

            LoadTestData();
        }

        public VsAddinManager Manager
        {
            get
            {
                return _manager;
            }
        }

        private void LoadTestData()
        {
            _manager.Clear();

            dataGridViewVsAddin.Rows.Clear();

            _manager.Add(
                "Status",
                "Connected");

            _manager.Add(
                "Addin",
                "NP.VSExtension");

            _manager.Add(
                "Visual Studio",
                "2012");

            _manager.Add(
                "Solution",
                "NP_AI_RuntimeStudio");

            _manager.Add(
                "Document",
                "JsonViewerControl.cs");

            FillGrid();
        }

        private void FillGrid()
        {
            dataGridViewVsAddin.Rows.Clear();

            foreach (VsAddinInfo item in _manager.Items)
            {
                dataGridViewVsAddin.Rows.Add(
                    item.Time.ToString("HH:mm:ss"),
                    item.Property,
                    item.Value);
            }
        }

        private void toolStripButtonRefresh_Click(
            object sender,
            EventArgs e)
        {
            LoadTestData();
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