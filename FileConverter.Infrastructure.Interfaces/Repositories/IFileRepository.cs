namespace FileConverter.Infrastructure.Interfaces.Repositories
{
    public interface IFileRepository
    {
        void SaveFile(string data, string fullPath);
        string GetFileData(string fullPath);
    }
}
