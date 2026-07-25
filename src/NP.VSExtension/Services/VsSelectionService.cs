using EnvDTE;

namespace NP.Extension.Services
{
    public class VsSelectionService
    {
        private readonly DTE _dte;

        public VsSelectionService(
            DTE dte)
        {
            _dte = dte;
        }

        public string GetSelectedText()
        {
            Document doc =
                _dte.ActiveDocument;

            if (doc == null)
            {
                return null;
            }

            TextSelection sel =
                (TextSelection)
                doc.Selection;

            return sel.Text;
        }
    }
}