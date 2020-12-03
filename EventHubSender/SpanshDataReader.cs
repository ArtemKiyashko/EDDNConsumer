using EventHubSender.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EventHubSender
{
    public class SpanshDataReader : IDataReader<IEnumerable<SpanshSystem>>
    {
        private readonly string _filePath;
        private readonly ILogger<SpanshDataReader> _logger;

        public SpanshDataReader(string filePath, ILogger<SpanshDataReader> logger)
        {
            _filePath = filePath;
            _logger = logger;
        }

        public IEnumerable<SpanshSystem> ReadData()
        {
            var serializer = new JsonSerializer();
            serializer.MissingMemberHandling = MissingMemberHandling.Error;
            serializer.Error += Serializer_Error;
            foreach (var line in File.ReadLines(_filePath))
                if (line.StartsWith("\t{"))
                    yield return JsonConvert.DeserializeObject<SpanshSystem>(
                        line[^1] == ',' ?
                            line.Remove(line.Length - 1, 1) :
                            line);
        }

        private void Serializer_Error(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e)
        {
            _logger.LogError(e.ErrorContext.Error.Message);
            e.ErrorContext.Handled = true;
        }
    }
}
