using CommandLine;
using DeclarationAutomation.Core.Publish;

namespace DeclarationAutomation.ConsoleApp.CLIOptions
{
    [Verb("publish", HelpText = "Publish your declarations")]
    internal class PublishOptions : Options
    {
        [Option('p', "provider", Default = PublishProviderType.All, HelpText = "Select which provider to publish to.")]
        public PublishProviderType PublishProvider { get; set; }
    }
}
