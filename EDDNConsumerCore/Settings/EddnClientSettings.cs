using System;
using System.Collections.Generic;
using System.Text;

namespace EDDNConsumerCore.Settings
{
    public class EddnClientSettings
    {
        public string ServerAddress { get; set; }
        public int Port { get; set; }
        public string Protocol { get; set; }
        public string ConnectionString => $"{Protocol}://{ServerAddress}:{Port}";
    }
}
