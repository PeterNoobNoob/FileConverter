using FileConverter.Infrastructure.Interfaces.TypeConverter;
using Newtonsoft.Json;

namespace File.Coverter.Infrastructure.TypeConverter
{
    public class JsonConverter : IJsonConverter
    {
        public string ConvertToXml(string source)
        {
            return JsonConvert.DeserializeXNode(source, "Root").ToString();
        }
    }
}
