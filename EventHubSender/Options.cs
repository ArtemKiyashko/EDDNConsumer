using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubSender
{
    public class Options
    {
        [Option(
            Required = true,
            HelpText = "Path to json galaxy file")]
        public string PathToFile { get; set; }

        [Option(
            Required = false,
            Default = 262144,
            HelpText = "Maximum bytes per batch")]
        public long MaxBytesInBatch { get; set; }
    }
}
