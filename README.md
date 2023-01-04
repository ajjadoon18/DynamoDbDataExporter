# DynamoDbDataExporter

Exports data to aws dynamodb from csv file.
It uses aws .net sdk via SSO authentication. 

**Note this would need optimization for larger files. 

1. Identify role to use it would look something like this 
```
[profile prod-dynamodbcrud]
sso_start_url = https://mh-sso.awsapps.com/start
sso_region = eu-west-1
sso_account_id = 1234
sso_role_name = ProdDynamoDBCRUD
region = eu-west-1
```
2. Set variables accordingly in [Configuration.cs](https://github.com/ajjadoon18/DynamoDbDataExporter/blob/master/Configuration.cs)
3. Set members names in [ExportModel.cs](https://github.com/ajjadoon18/DynamoDbDataExporter/blob/master/ExportModel.cs) according to your excel and also change index numbers accordingly.
```
[Index(0)]
public string? CarId { get; set; }

[Index(1)]
public string? Year { get; set; }

[Index(2)]
public string? City { get; set; }
```
4. Run command ``` aws sso login ```
5. Build and run
