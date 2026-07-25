namespace NP.Services.Components
{
    public class ComponentCompiler
    {
        public bool Compile(
            ComponentProject project)
        {
            if (project == null)
                return false;

            // مرحله بعد:
            // CodeDom
            // یا Roslyn

            return true;
        }
    }
}