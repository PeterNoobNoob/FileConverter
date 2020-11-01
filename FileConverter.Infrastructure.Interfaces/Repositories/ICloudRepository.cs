namespace FileConverter.Infrastructure.Interfaces.Repositories
{
    public interface ICloudRepository
    {
        string GetFileData(string url);
    }
}
