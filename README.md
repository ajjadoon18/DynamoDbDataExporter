# DynamoDbDataExporter

Exports data to aws dynamodb from csv file.
It uses aws .net sdk via SSO authentication. 

**Note this would need optimization for larger files. 

1. Set variables accordingly in [Configuration.cs](https://github.com/ajjadoon18/DynamoDbDataExporter/blob/master/Configuration.cs)
2. Set members names in [ExportModel.cs](https://github.com/ajjadoon18/DynamoDbDataExporter/blob/master/ExportModel.cs) according to your excel and also change index numbers accordingly.
```
[Index(0)]
public string? CarId { get; set; }

[Index(1)]
public string? Year { get; set; }

[Index(2)]
public string? City { get; set; }
```
3. Run command ``` aws sso login ```
4. Build and run