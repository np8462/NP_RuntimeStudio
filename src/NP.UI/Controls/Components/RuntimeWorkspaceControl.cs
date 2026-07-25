using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NP.Services.Components;
using NP.Core.Components;
using NP.Services.Development;

namespace NP.UI.Controls.Components
{
    public partial class RuntimeWorkspaceControl : UserControl
    {
        private readonly ComponentWorkspace _workspace;
        private readonly DevelopmentWorkspace
    _development;

        public RuntimeWorkspaceControl()
        {
            InitializeComponent();

            _workspace =
                new ComponentWorkspace();

            _workspace.LogsChanged +=
                Workspace_LogsChanged;

            _development =
    new DevelopmentWorkspace();

        }

        private void Workspace_LogsChanged(object sender, EventArgs e)
        {
            RefreshLog();
        }

        private void BrowseFolder()
        {
            using (FolderBrowserDialog dialog =
                new FolderBrowserDialog())
            {
                dialog.Description =
                    "Select Component Folder";

                if (dialog.ShowDialog() !=
                    DialogResult.OK)
                    return;

                txtFolder.Text =
                    dialog.SelectedPath;

                _workspace.Open(
                    dialog.SelectedPath);

                RefreshLog();
            }
        }
        //private void BrowseFolder()
        //{
        //    using (FolderBrowserDialog dialog =
        //        new FolderBrowserDialog())
        //    {
        //        dialog.Description =
        //            "Select Component Folder";

        //        if (dialog.ShowDialog() !=
        //            DialogResult.OK)
        //        {
        //            return;
        //        }

        //        txtFolder.Text =
        //            dialog.SelectedPath;

        //        AddLog(
        //            "Workspace Opened");

        //        AddLog(
        //            "Folder : " +
        //            dialog.SelectedPath);

        //        AddLog(
        //            "Searching Components...");
        //    }
        //}

        private void CloseWorkspace()
        {
            _workspace.Close();

            txtFolder.Clear();

            listBoxLog.Items.Clear();

        }
        //private void CloseWorkspace()
        //{
        //    txtFolder.Clear();

        //    listBoxLog.Items.Clear();

        //    AddLog("Workspace Closed");
        //}


        private void RefreshLog()
        {
            listBoxLog.Items.Clear();

            foreach (RuntimeLogInfo log
                in _workspace.Logs)
            {
                listBoxLog.Items.Add(

                    log.Time.ToString("HH:mm:ss")

                    + "  "

                    + log.Source

                    + "  "

                    + log.Message);
            }

            if (listBoxLog.Items.Count > 0)
                listBoxLog.TopIndex =
                    listBoxLog.Items.Count - 1;
        }
        //private void RefreshLog()
        //{
        //    listBoxLog.Items.Clear();

        //    foreach (RuntimeLogInfo log
        //        in _workspace.Logs)
        //    {
        //        listBoxLog.Items.Add(

        //            log.Time.ToString("HH:mm:ss")

        //            + "  "

        //            + log.Message);
        //    }

        //    if (listBoxLog.Items.Count > 0)
        //    {
        //        listBoxLog.TopIndex =
        //            listBoxLog.Items.Count - 1;
        //    }
        //}

        private void toolStripButtonBrowse_Click(object sender, EventArgs e)
        {
            BrowseFolder();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            CloseWorkspace();
        }

        //private void
        //toolStripButtonBuildFile_Click(
        //    object sender,
        //    EventArgs e)
        //{
        //    BuildResult result =

        //        _development.BuildFile();

        //    if (result == null)
        //        return;

        //    RefreshBuildLog();
        //}
        private void toolStripButtonBuildFile_Click(
    object sender,
    EventArgs e)
        {
            BuildResult result =
                _workspace.BuildFile();

            if (result == null)
                return;

            txtFolder.Text = result.SourceFile;

            RefreshLog();
        }
        private void RefreshBuildLog()
        {
            foreach (string item
                in _development.Manager.Logger.Items)
            {
                listBoxLog.Items.Add(item);
            }

            if (listBoxLog.Items.Count > 0)
            {
                listBoxLog.TopIndex =
                    listBoxLog.Items.Count - 1;
            }
        }

        private void toolStripButtonBuildFolder_Click(
    object sender,
    EventArgs e)
        {
            BuildResult result =
                _workspace.BuildFolder();

            if (result == null)
                return;

            RefreshLog();
        }

        //private void AddLog(string text)
        //{
        //    listBoxLog.Items.Add(
        //        DateTime.Now.ToString("HH:mm:ss")
        //        + "   "
        //        + text);

        //    listBoxLog.TopIndex =
        //        listBoxLog.Items.Count - 1;
        //}
    }
}
