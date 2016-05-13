# PTrampert.MongoDb.Configuration
Simple configuration library for MongoDb.

## Getting Started
* Install the [nuget package](https://www.nuget.org/packages/ptrampert.mongodb.configuration).
* Add the following to your App.config or Web.config
```xml
<configSections>
  <section name="mongodb" type="PTrampert.MongoDb.Configuration.MongoConfigurationSection, PTrampert.MongoDb.Configuration" />
</configSections>
<mongodb connectionString="mongodb://localhost/?w=majority" databaseName="testdb" />
```
* You can load the config directly with MongoConfigLoader:
```
IMongoConfiguration config = MongoConfigLoader.LoadFromConfigFile();
```
* You can get an IMongoClient or an IMongoDatabase using the MongoFactory:
```
var factory = new MongoFactory();
var client = factory.Client;
var database = factory.Database;
```

### Contributing
If you would like to contribute, please submit a pull request to the dev branch. Pull requests to master will be rejected, as master is reserved for releasable code from the time of this writing forward.
