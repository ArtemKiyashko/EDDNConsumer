using System;
using System.Collections.Generic;
using System.Text;

namespace JournalContributor.Settings
{
    public class CosmosDbSettings
    {
        public string DbName { get; set; }
        public CollectionSettings BodiesCollection { get; set; }
        public CollectionSettings SystemsCollection { get; set; }
        public CollectionSettings StationsCollection { get; set; }
        public CollectionSettings SignalsCollection { get; set; }
    }
}
