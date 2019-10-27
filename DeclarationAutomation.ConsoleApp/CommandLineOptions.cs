using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace DeclarationAutomation.ConsoleApp
{
    [Flags]
    public enum ProviderType
    {
        All = 0,
        GoogleDrive = 1,
        OneDrive = 2,
        Custom = 4
    }

    internal class Options
    {

    }

    [Verb("sync", HelpText = "Sync content with provider.")]
    internal class SyncOptions : Options
    {
        [Option('p', "provider", Default = ProviderType.All, Required = true, HelpText = "Enum with all providers")]
        public ProviderType providerTypes { get; set; }
    }
}
