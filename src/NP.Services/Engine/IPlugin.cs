namespace NP.Services.Engine
{
    public interface IPlugin
    {
        string Name
        {
            get;
        }

        void Initialize();
    }
}