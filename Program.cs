using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using CsvHelper;
using DynamoDbDataExporter;
using System.Globalization;

Console.WriteLine($"Starting the export process! on Table: {Configuration.TABLE_NAME}");
var ssoCreds = SsoHelper.LoadSsoCredentials(Configuration.SSO_PROFILE);
await SsoHelper.PrintCredentials(ssoCreds);

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("$ Do you want to continue?..... Press any key");
Console.ResetColor();
Console.ReadLine();

var dynamoDBClient = new AmazonDynamoDBClient(ssoCreds);
var _context = new DynamoDBContext(dynamoDBClient);
var config = new DynamoDBOperationConfig
{
    OverrideTableName = Configuration.TABLE_NAME,
};

using (var reader = new StreamReader(Configuration.CSV))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var records = csv.GetRecords<ExportModel>();
    foreach (var record in records)
    {
        await _context.SaveAsync(record, config);
    }
    Console.WriteLine($"Export porcess complete...{records.Count()} items exported");
}