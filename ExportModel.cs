using CsvHelper.Configuration.Attributes;

namespace DynamoDbDataExporter
{
    public class ExportModel
    {
        [Index(0)]
        public string? CarId { get; set; }
        [Index(1)]
        public string? Year { get; set; }
        [Index(2)]
        public string? City { get; set; }
    }
}
