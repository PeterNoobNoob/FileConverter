using System;
using System.IO;
using System.Text;
using FileConverter.Infrastructure.Interfaces.Repositories;

namespace File.Coverter.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        public void SaveFile(string data, string fullPath)
        {
            using (FileStream fs = System.IO.File.Create(fullPath))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(data);
                fs.Write(info, 0, info.Length);
            }
        }

        public string GetFileData(string fullPath)
        {
            return System.IO.File.ReadAllText(fullPath);
        }
    }
}
