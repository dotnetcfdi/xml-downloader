namespace XmlDownloader.Models
{
    public class Token
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string? Value { get; set; }

    }
}
