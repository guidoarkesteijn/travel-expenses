using CommandLine;
using DeclarationAutomation.Core.Sync;

namespace DeclarationAutomation.ConsoleApp.CLIOptions
{
    [Verb("sync", HelpText = "Sync content with provider.")]
    internal class SyncOptions : Options
    {
        [Option('p', "provider", Default = SyncProviderType.All, Required = true, HelpText = "Enum with all providers")]
        public SyncProviderType providerTypes { get; set; }
    }
}
