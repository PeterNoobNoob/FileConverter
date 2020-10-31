using File.Coverter.Infrastructure.Converter;
using FileConverter.Models;
using FileConverter.Models.Source;
using FileConverter.Models.Target;

namespace FileConverter.Mappers
{
    public static class ArgumentsMapper
    {
        public static ConvertModel ToModel(this string[] args)
        {
            var destinationType = GetDestinationType(args[0]);
            var sourcePath = args[1];
            var sourceFileType = GetSourceFileType(args[2]);
            var targetPath = args[3];
            var targetFileType = GetTargetFileType(args[4]);
            var convertModel = new ConvertModel();
            switch (destinationType)
            {
                case SourceDestinationType.Cloud: convertModel.Source = new CloudSourceModel()
                {
                    SourceFileType = sourceFileType,
                    SourceDestinationType = SourceDestinationType.Cloud,
                    Url = sourcePath
                };
                    break;
                case SourceDestinationType.Filesystem: convertModel.Source = new FileSystemSourceModel()
                {
                    SourceFileType = sourceFileType,
                    SourceDestinationType = SourceDestinationType.Filesystem,
                    FullPath = sourcePath
                };
                    break;
                default: convertModel.Source = null;
                    break;
            }
            convertModel.Target = new TargetModel()
            {
                TargetFileType = targetFileType,
                FullPath = targetPath
            };
            return convertModel;
        }

        private static SourceDestinationType GetDestinationType(string destinationType)
        {
            switch (destinationType.ToUpperInvariant())
            {
                case "CLOUD": return SourceDestinationType.Cloud;
                case "FILESYSTEM": return SourceDestinationType.Filesystem;
            }

            return SourceDestinationType.Unknown;
        }

        private static SourceFileType GetSourceFileType(string fileType)
        {
            switch (fileType.ToUpperInvariant())
            {
                case "XML": return SourceFileType.Xml;
                case "JSON": return SourceFileType.Json;
            }

            return SourceFileType.Unknown;
        }

        private static TargetFileType GetTargetFileType(string fileType)
        {
            switch (fileType.ToUpperInvariant())
            {
                case "XML": return TargetFileType.Xml;
                case "JSON": return TargetFileType.Json;
                case "JSONCAMELCASE": return TargetFileType.JsonCamelCase;
            }

            return TargetFileType.Unknown;
        }
    }
}
