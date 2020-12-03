using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EventHubSender
{
    public static class StreamReaderExtensions
    {
        public async static Task<StreamReader> SkipLinesAsync(this StreamReader reader, int count)
        {
            for (int i = 0; i < count; i++)
                await reader.ReadLineAsync();
            return reader;
        }
    }
}
