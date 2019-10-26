using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace DeclarationAutomation.ConsoleApp
{
    class CommandLineOptions
    {
        [Option('s', "sync", Required = false, HelpText = "Sync with all storage providers.")]
        public bool Verbose { get; set; }
    }
}
