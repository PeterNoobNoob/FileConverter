using File.Coverter.Infrastructure.Converter;
using FileConverter.Infrastructure.Interfaces.Converter;
using FileConverter.Infrastructure.Interfaces.Repositories;
using FileConverter.Infrastructure.Interfaces.TypeConverter;
using FileConverter.Models;
using FileConverter.Models.Source;
using FileConverter.Models.Target;
using Moq;
using NUnit.Framework;

namespace FileConverter.Tests
{
    [TestFixture]
    public class ConverterServiceTest
    {
        private IConverterService _converterService;

        [SetUp]
        public void SetUp()
        {
            var jsonConverter = new Mock<IJsonConverter>();
            jsonConverter.Setup(x => x.ConvertToXml(It.IsAny<string>())).Returns<string>(a => It.IsAny<string>());
            var xmlConverter = new Mock<IXmlConverter>();
            xmlConverter.Setup(x=>x.ConvertToJson(It.IsAny<string>())).Returns<string>(a => It.IsAny<string>());
            xmlConverter.Setup(x=>x.ConvertToJsonCamelCase(It.IsAny<string>())).Returns<string>(a => It.IsAny<string>());
            var fileRepository = new Mock<IFileRepository>();
            fileRepository.Setup(x=>x.GetFileData(It.IsAny<string>())).Returns<string>(a => It.IsAny<string>());
            fileRepository.Setup(x => x.SaveFile(It.IsAny<string>(), It.IsAny<string>()));
            var cloudRepository = new Mock<ICloudRepository>();
            cloudRepository.Setup(x => x.GetFileData(It.IsAny<string>())).Returns<string>(x => It.IsAny<string>());
            //_converterService = new ConverterService(jsonConverter.Object, xmlConverter.Object, fileRepository.Object, cloudRepository.Object);
        }

        [Test]
        public void ConvertFile_InputValidParameters_DoesntReturnException()
        {
            var convert = new ConvertModel()
            {
                Source = new FileSystemSourceModel()
                {
                    FullPath = "testPath",
                    SourceFileType = SourceFileType.Json,
                    SourceDestinationType = SourceDestinationType.Filesystem
                },
                Target = new TargetModel()
                {
                    FullPath = "testPath",
                    TargetFileType = TargetFileType.Xml
                }
            };

            TestDelegate code = () => _converterService.ConvertFile(convert);

            Assert.DoesNotThrow(code);
        }
    }
}
