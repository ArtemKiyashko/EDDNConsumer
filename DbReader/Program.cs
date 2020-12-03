using EDDNModels.Journal;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbReader
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>(false, true)
                .Build();
            var client = new CosmosClient(config["CosmosDBConnectionString"]);
            var db = client.GetDatabase("EDDN");
            var container = db.GetContainer("Bodies");
            var documentsSystemNames = container.GetItemQueryIterator<string>(queryText: @"select value f.StarSystem from (
                                                                            SELECT c.StarSystem, count(c.StarType) stars_count FROM c
                                                                            where c.StarType in ('N', 'DCV')
                                                                            group by c.StarSystem
                                                                        ) f
                                                                        where f.stars_count > 1");
            var allBodies = new List<JournalMessage>();
            while (documentsSystemNames.HasMoreResults)
            {
                var currentResultSet = await documentsSystemNames.ReadNextAsync();
                foreach (var systemName in currentResultSet)
                {
                    var documentsFullSystemsInfo = container.GetItemQueryIterator<JournalMessage>(queryText: $"select * from c where c.StarSystem = '{systemName}'");
                    while (documentsFullSystemsInfo.HasMoreResults)
                    {
                        var currentFulInfoSet = await documentsFullSystemsInfo.ReadNextAsync();
                        foreach(var fullBodyInfo in currentFulInfoSet)
                        {
                            allBodies.Add(fullBodyInfo);
                        }
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
