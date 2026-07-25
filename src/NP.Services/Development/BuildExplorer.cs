using System.Windows.Forms;

namespace NP.Services.Development
{
    public class BuildExplorer
    {
        public string SelectFile()
        {
            using(OpenFileDialog dialog =
                new OpenFileDialog())
            {
                dialog.Filter =
                    "C# Files (*.cs)|*.cs";

                dialog.Multiselect =
                    false;

                if(dialog.ShowDialog() !=
                    DialogResult.OK)
                    return null;

                return dialog.FileName;
            }
        }

        //------------------------------------------------

        public string SelectFolder()
        {
            using(FolderBrowserDialog dialog =
                new FolderBrowserDialog())
            {
                if(dialog.ShowDialog() !=
                    DialogResult.OK)
                    return null;

                return dialog.SelectedPath;
            }
        }
    }
}