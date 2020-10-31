namespace FileConverter.Models.Source
{
    public abstract class SourceModel
    {
        public SourceDestinationType SourceDestinationType { get; set; }
        public SourceFileType SourceFileType { get; set; }
    }
}
