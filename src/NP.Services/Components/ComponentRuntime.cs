namespace NP.Services.Components
{
    public class ComponentRuntime
    {
        public ComponentRegistry Registry
        {
            get;
            private set;
        }

        public ComponentRuntime()
        {
            Registry =
                new ComponentRegistry();
        }
    }
}