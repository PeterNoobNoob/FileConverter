namespace FileConverter.Infrastructure.Interfaces.TypeConverter
{
    public interface IXmlConverter
    {
        string ConvertToJson(string source);
        string ConvertToJsonCamelCase(string source);
    }
}
