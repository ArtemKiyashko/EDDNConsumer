using EDDNModels.Common;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JournalContributor.Extensions
{
    public static class MessageExtensions
    {
        public static async Task<ItemResponse<T>> CheckIfItemExists<T>(this T item, Container container, string partitionKey)
            where T : BaseMessage
        {
            try
            {
                return await container.ReadItemAsync<T>(item.Id, new PartitionKey(partitionKey));
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }
    }
}
