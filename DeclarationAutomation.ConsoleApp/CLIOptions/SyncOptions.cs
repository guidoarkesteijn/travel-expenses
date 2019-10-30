using CommandLine;
using DeclarationAutomation.Core.Sync;

namespace DeclarationAutomation.ConsoleApp.CLIOptions
{
    /// <summary>
    /// Options used for the syncing of the travel expenses.
    /// You can define the different variables needed for the sync verb.
    /// </summary>
    [Verb("sync", HelpText = "Sync content with provider(s).")]
    internal class SyncOptions : Options
    {
        [Option('p', "provider", Default = SyncProviderType.All, Required = false, HelpText = "Enum with all providers")]
        public SyncProviderType providerTypes { get; set; }
    }
}
