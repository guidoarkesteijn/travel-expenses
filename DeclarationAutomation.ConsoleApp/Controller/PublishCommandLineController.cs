using DeclarationAutomation.ConsoleApp.CLIOptions;

namespace DeclarationAutomation.ConsoleApp.Controller
{
    class PublishCommandLineController : BaseCommandLineController<PublishOptions>
    {
        internal override int RunCommandAndExit(PublishOptions options)
        {

            return 0;
        }
    }
}
