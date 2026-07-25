namespace NP.Services.Builders
{
    public class ObjectBuilder<T> : BuilderBase<T>
        where T : new()
    {
        public override T Build()
        {
            return new T();
        }
    }
}