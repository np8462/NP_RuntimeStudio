using System;
using System.Windows.Forms;
using NP.Core.Models;

namespace NP.UI.Controls.JsonViewer
{
    public partial class JsonTreeView : UserControl
    {
        public JsonTreeView()
        {
            InitializeComponent();
            treeViewJson.AfterSelect += TreeViewJson_AfterSelect;
        }

        // EVENT (سازگار با VS2012)
        public event Action<JsonNodeEventArgs> NodeChanged;

        private void TreeViewJson_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (NodeChanged != null)
            {
                NodeChanged(new JsonNodeEventArgs
                {
                    Text = e.Node.Text,
                    Path = BuildPath(e.Node)
                });
            }
        }

        private string BuildPath(TreeNode node)
        {
            string path = node.Text;

            TreeNode parent = node.Parent;

            while (parent != null)
            {
                path = parent.Text + "." + path;
                parent = parent.Parent;
            }

            return path;
        }

        // PROPERTY (قدیمی)
        public TreeView Tree
        {
            get
            {
                return treeViewJson;
            }
        }
        private TreeNode CreateNode(JsonNodeModel model)
        {
            TreeNode node = new TreeNode(model.Name);

            node.Tag = model;

            if (!string.IsNullOrEmpty(model.Value))
            {
                node.Text += " : " + model.Value;
            }

            foreach (JsonNodeModel child in model.Children)
            {
                node.Nodes.Add(CreateNode(child));
            }

            return node;
        }
        //private TreeNode CreateNode(JsonNodeModel model)
        //{
        //    TreeNode node = new TreeNode(model.Name);

        //    if (!string.IsNullOrEmpty(model.Value))
        //    {
        //        node.Text = node.Text + " : " + model.Value;
        //    }

        //    foreach (JsonNodeModel child in model.Children)
        //    {
        //        node.Nodes.Add(CreateNode(child));
        //    }

        //    return node;
        //}

        public void LoadNode(TreeNode node)
        {
            treeViewJson.Nodes.Clear();
            treeViewJson.Nodes.Add(node);
            treeViewJson.ExpandAll();
        }

        public void LoadModel(JsonNodeModel model)
        {
            treeViewJson.Nodes.Clear();

            TreeNode root = CreateNode(model);

            treeViewJson.Nodes.Add(root);

            treeViewJson.ExpandAll();
        }
    }

    public class JsonNodeEventArgs
    {
        public string Text { get; set; }
        public string Path { get; set; }
    }
}