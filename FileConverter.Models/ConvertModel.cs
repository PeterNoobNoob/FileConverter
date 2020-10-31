using FileConverter.Models.Source;
using FileConverter.Models.Target;

namespace FileConverter.Models
{
    public class ConvertModel
    {
        public SourceModel Source { get; set; }
        public TargetModel Target { get; set; }
    }
}
