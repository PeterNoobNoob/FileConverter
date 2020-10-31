using FileConverter.Models;

namespace FileConverter.Infrastructure.Interfaces.Converter
{
    public interface IConverterService
    {
        void ConvertFile(ConvertModel convert);
    }
}
