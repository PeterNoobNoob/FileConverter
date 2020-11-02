using System;
using File.Coverter.Infrastructure.TypeConverter;
using FileConverter.Infrastructure.Interfaces.TypeConverter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using NUnit.Framework;

namespace FileConverter.Tests
{
    [TestFixture]
    public class XmlConverterTest
    {
        private IXmlConverter _xmlConverter;

        [SetUp]
        public void SetUp()
        {
            _xmlConverter = new XmlConverter();
        }

        [Test]
        public void ConvertToJson_InputValidXml_ReturnsTrue()
        {
            var xmlString = @"<?xml version='1.0' standalone='no'?>
                            <root>
                              <person id='1'>
                              <name>Alan</name>
                              <url>http://www.google.com</url>
                              </person>
                              <person id='2'>
                              <name>Louis</name>
                              <url>http://www.yahoo.com</url>
                              </person>
                            </root>";

            var result = _xmlConverter.ConvertToJson(xmlString);

            Assert.IsNotEmpty(result, "Result shouldn't be empty.");
        }

        [Test]
        public void ConvertToJson_InputInValidXml_ReturnsException()
        {
            var xmlString = "wrongXML";

            TestDelegate code = () => _xmlConverter.ConvertToJson(xmlString);

            Assert.That(code, Throws.Exception);
        }
        [Test]
        public void ConvertToJsonCamelCase_InputValidXml_ReturnsTrue()
        {
            var xmlString = @"<?xml version='1.0' standalone='no'?>
                            <root>
                              <person id='1'>
                              <name>Alan</name>
                              <url>http://www.google.com</url>
                              </person>
                              <person id='2'>
                              <name>Louis</name>
                              <url>http://www.yahoo.com</url>
                              </person>
                            </root>";

            var result = _xmlConverter.ConvertToJson(xmlString);

            Assert.IsNotEmpty(result, "Result shouldn't be empty.");
        }

        [Test]
        public void ConvertToJsonCamelCase_InputInValidXml_ReturnsException()
        {
            var xmlString = "wrongXML";

            TestDelegate code = () => _xmlConverter.ConvertToJsonCamelCase(xmlString);

            Assert.That(code, Throws.Exception);
        }
    }
}