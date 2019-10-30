using CommandLine;
using DeclarationAutomation.Core.Publish;

namespace DeclarationAutomation.ConsoleApp.CLIOptions
{
    /// <summary>
    /// Options used for the publishing of the travel expenses.
    /// You can define the different variables needed for the publish verb.
    /// </summary>
    [Verb("publish", HelpText = "Publish content to your provider(s)")]
    internal class PublishOptions : Options
    {
        [Option('p', "provider", Default = PublishProviderType.All, HelpText = "Select which provider to publish to.")]
        public PublishProviderType PublishProvider { get; set; }
    }
}
