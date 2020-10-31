namespace FileConverter.Infrastructure.Interfaces.Validation
{
    public interface IArgumentValidationService
    {
        bool Validate(string[] arguments);
    }
}
