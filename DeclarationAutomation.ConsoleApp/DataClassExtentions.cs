using System;
using System.Collections.Generic;
using System.Text;
using DeclarationAutomation.ConsoleApp.CLIOptions;
using DeclarationAutomation.Core.Sync;

namespace DeclarationAutomation.ConsoleApp
{
    internal static class DataClassExtentions
    {
        internal static SyncData ToSyncData(this SyncOptions syncOptions)
        {
            return new SyncData(syncOptions.providerTypes);
        }
    }
}
