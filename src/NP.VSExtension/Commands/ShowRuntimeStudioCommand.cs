using NP.VSExtension.Forms;

namespace NP.VSExtension.Commands
{
    public static class ShowRuntimeStudioCommand
    {
        public static void Execute()
        {
            RuntimeStudioForm frm =
                new RuntimeStudioForm();

            frm.Show();
        }
    }
}