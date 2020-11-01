using System.Xml;
using FileConverter.Infrastructure.Interfaces.TypeConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace File.Coverter.Infrastructure.TypeConverter
{
    public class XmlConverter : IXmlConverter
    {
        public string ConvertToJson(string source)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(source);
            return JsonConvert.SerializeXmlNode(xmlDoc);
        }

        public string ConvertToJsonCamelCase(string source)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(source);
            var camelSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var objectString =  JsonConvert.SerializeXmlNode(xmlDoc);
            var objectJson = JsonConvert.DeserializeObject(objectString);
            return JsonConvert.SerializeObject(objectJson, camelSettings);
        }
    }
}
