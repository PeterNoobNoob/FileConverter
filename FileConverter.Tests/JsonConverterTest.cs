using File.Coverter.Infrastructure.TypeConverter;
using FileConverter.Infrastructure.Interfaces.TypeConverter;
using NUnit.Framework;

namespace FileConverter.Tests
{
    [TestFixture]
    public class JsonConverterTest
    {
        private IJsonConverter _jsonConverter;

        [SetUp]
        public void SetUp()
        {
            _jsonConverter = new JsonConverter();
        }

        [Test]
        public void ConvertToXml_InputValidJson_ReturnsTrue()
        {
            var jsonString = @"{
                              '@Id': 1,
                              'Email': 'james@example.com',
                              'Active': true,
                              'CreatedDate': '2013-01-20T00:00:00Z',
                              'Roles': [
                                'User',
                                'Admin'
                              ],
                              'Team': {
                                '@Id': 2,
                                'Name': 'Software Developers',
                                'Description': 'Creators of fine software products and services.'
                              }
                            }";

            var result = _jsonConverter.ConvertToXml(jsonString);

            Assert.IsNotEmpty(result, "Result shouldn't be empty.");
        }

        [Test]
        public void ConvertToXml_InputInValidJson_ReturnsException()
        {
            var jsonString = "wrongXML";

            TestDelegate code = () => _jsonConverter.ConvertToXml(jsonString);

            Assert.That(code, Throws.Exception);
        }

    }
}
