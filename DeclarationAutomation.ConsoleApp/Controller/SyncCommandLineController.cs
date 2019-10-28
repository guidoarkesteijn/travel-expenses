using DeclarationAutomation.ConsoleApp.CLIOptions;
using DeclarationAutomation.Core.Sync;

namespace DeclarationAutomation.ConsoleApp.Controller
{
    class SyncCommandLineController : BaseCommandLineController<SyncOptions>
    {
        internal override int RunCommandAndExit(SyncOptions options)
        {
            SyncProviderType providers = options.providerTypes;
            return 0;
        }
    }
}
