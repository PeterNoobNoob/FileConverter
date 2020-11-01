using System.Runtime.InteropServices;
using FileConverter.Infrastructure.Interfaces.Converter;
using FileConverter.Infrastructure.Interfaces.Repositories;
using FileConverter.Infrastructure.Interfaces.TypeConverter;
using FileConverter.Infrastructure.Interfaces.Validation;
using FileConverter.Models;
using FileConverter.Models.Source;
using FileConverter.Models.Target;

namespace File.Coverter.Infrastructure.Converter
{
    public class ConverterService : IConverterService
    {
        private readonly IFileRepository _fileRepository;
        private readonly ICloudRepository _cloudRepository;
        private readonly IXmlConverter _xmlConverter;
        private readonly IJsonConverter _jsonConverter;

        public ConverterService(
            IFileRepository fileRepository, ICloudRepository cloudRepository,
            IXmlConverter xmlConverter, IJsonConverter jsonConverter)
        {
            _fileRepository = fileRepository;
            _cloudRepository = cloudRepository;
            _xmlConverter = xmlConverter;
            _jsonConverter = jsonConverter;
        }

        public void ConvertFile(ConvertModel convert)
        {
            switch (convert.Source.SourceDestinationType)
            {
                case SourceDestinationType.Cloud:
                    ConvertCloudFile(convert);
                    break;
                case SourceDestinationType.Filesystem:
                    ConvertFilesystemFile(convert);
                    break;
            }
        }

        private void ConvertFilesystemFile(ConvertModel convert)
        {
            if ((convert.Source.SourceFileType == SourceFileType.Json &&
                 (convert.Target.TargetFileType == TargetFileType.Json ||
                  convert.Target.TargetFileType == TargetFileType.JsonCamelCase) ||
                 convert.Source.SourceFileType == SourceFileType.Xml &&
                 convert.Target.TargetFileType == TargetFileType.Xml))
            {
                var data = _fileRepository.GetFileData(((FileSystemSourceModel) convert.Source).FullPath);
                _fileRepository.SaveFile(data, convert.Target.FullPath);
                return;
            }

            switch (convert.Source.SourceFileType)
            {
                case SourceFileType.Json:
                    ConvertFileSystemJsonFile(convert);
                    break;
                case SourceFileType.Xml: ConvertFileSystemXmlFile(convert);
                    break;
            }

        }

        private void ConvertCloudFile(ConvertModel convert)
        {
            if ((convert.Source.SourceFileType == SourceFileType.Json &&
                 (convert.Target.TargetFileType == TargetFileType.Json ||
                  convert.Target.TargetFileType == TargetFileType.JsonCamelCase) ||
                 convert.Source.SourceFileType == SourceFileType.Xml &&
                 convert.Target.TargetFileType == TargetFileType.Xml))
            {
                var data = _cloudRepository.GetFileData(((CloudSourceModel) convert.Source).Url);
                _fileRepository.SaveFile(data, convert.Target.FullPath);
            }
        }

        private void ConvertFileSystemJsonFile(ConvertModel convert)
        {
            var data = _fileRepository.GetFileData(((FileSystemSourceModel) convert.Source).FullPath);
            string convertedString = string.Empty;
            switch (convert.Target.TargetFileType)
            {
                case TargetFileType.Xml:
                    convertedString = _jsonConverter.ConvertToXml(data);
                    break;
            }

            _fileRepository.SaveFile(convertedString, convert.Target.FullPath);
        }

        private void ConvertFileSystemXmlFile(ConvertModel convert)
        {
            var data = _fileRepository.GetFileData(((FileSystemSourceModel) convert.Source).FullPath);
            string convertedString = string.Empty;
            switch (convert.Target.TargetFileType)
            {
                case TargetFileType.Json:
                    convertedString = _xmlConverter.ConvertToJson(data);
                    break;
                case TargetFileType.JsonCamelCase:
                    convertedString = _xmlConverter.ConvertToJsonCamelCase(data);
                    break;
            }

            _fileRepository.SaveFile(convertedString, convert.Target.FullPath);
        }
    }
}
