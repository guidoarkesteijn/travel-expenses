using System;
using System.Collections.Generic;
using System.Text;

namespace DeclarationAutomation.ConsoleApp
{
    abstract class BaseCommandLineController<O> where O : Options
    {
        internal abstract int RunCommandAndExit(O options);
    }

    class SyncCommandLineController : BaseCommandLineController<SyncOptions>
    {
        internal override int RunCommandAndExit(SyncOptions options)
        {
            //ProviderType providers = options.providerTypes;
            return -1;
        }
    }
}
