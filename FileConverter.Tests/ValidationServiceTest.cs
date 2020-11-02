using File.Coverter.Infrastructure.Validation;
using FileConverter.Infrastructure.Interfaces.Validation;
using NUnit.Framework;

namespace FileConverter.Tests
{
    [TestFixture]
    public class ValidationServiceTest
    {
        private IArgumentValidationService _argumentValidationService;
        [SetUp]
        public void SetUp()
        {
            _argumentValidationService = new ArgumentValidationService();
        }

        [Test]
        public void Validate_HelpInput_ReturnsFalse()
        {
            var helpString = "help";

            var result = _argumentValidationService.Validate(new[] {helpString});

            Assert.IsFalse(result, "Result should be false");
        }

        [Test]
        public void Validate_InputLessThan5_ReturnsFalse()
        {
            var arguments = new[] { "C:\\abc\\test.xml","xml","C:\\abc\\test.json","json", };

            var result = _argumentValidationService.Validate(arguments);

            Assert.IsFalse(result, "Result should be false");
        }

        [Test]
        public void Validate_InputNotCloudOrFilesystem_ReturnsFalse()
        {
            var arguments = new[] { "something", "C:\\abc\\test.xml", "xml","C:\\abc\\test.json","json", };

            var result = _argumentValidationService.Validate(arguments);

            Assert.IsFalse(result, "Result should be false");
        }

        [Test]
        public void Validate_InputSourceNotXmlOrJson_ReturnsFalse()
        {
            var arguments = new[] { "filesystem","C:\\abc\\test.xml","cs","C:\\abc\\test.json","json", };

            var result = _argumentValidationService.Validate(arguments);

            Assert.IsFalse(result, "Result should be false");
        }

        [Test]
        public void Validate_InputTargetNotXmlOrJsonOrJsonCamelCase_ReturnsFalse()
        {
            var arguments = new[] { "filesystem","C:\\abc\\test.xml","xml","C:\\abc\\test.json","txt", };

            var result = _argumentValidationService.Validate(arguments);

            Assert.IsFalse(result, "Result should be false");
        }

        [Test]
        public void Validate_InputTargetNotXmlOrJsonOrJsonCamelCase_ReturnsTrue()
        {
            var arguments = new[] { "filesystem","C:\\abc\\test.xml","xml","C:\\abc\\test.json","json", };

            var result = _argumentValidationService.Validate(arguments);

            Assert.IsTrue(result, "Result should be true");
        }
    }
}
