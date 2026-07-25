namespace NP.Services.Components
{
    public interface IComponent
    {
        string Name
        {
            get;
        }

        void Initialize();
    }
}