namespace NP.Services.Components
{
    public class ComponentBuilder
    {
        private readonly ComponentCompiler _compiler;

        public ComponentBuilder(
            ComponentCompiler compiler)
        {
            _compiler = compiler;
        }

        public bool Build(
            ComponentProject project)
        {
            if (project == null)
                return false;

            return _compiler.Compile(project);
        }
    }
}