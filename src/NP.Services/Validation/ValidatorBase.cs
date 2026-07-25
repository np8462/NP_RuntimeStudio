namespace NP.Services.Validation
{
    public abstract class ValidatorBase<T>
    {
        public abstract ValidationResult Validate(T value);
    }
}