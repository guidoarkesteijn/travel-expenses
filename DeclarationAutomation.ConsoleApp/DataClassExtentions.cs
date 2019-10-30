using System;
using System.Collections.Generic;
using System.Text;
using DeclarationAutomation.ConsoleApp.CLIOptions;
using DeclarationAutomation.Core.Sync;

namespace DeclarationAutomation.ConsoleApp
{
    /// <summary>
    /// Easy extention class to change the CLI options to the data class used in Core.
    /// </summary>
    internal static class DataClassExtentions
    {
        /// <summary>
        /// Convert a SyncOptions to a SyncData
        /// </summary>
        /// <returns>A instance of a SyncData which can be used in core.</returns>
        internal static SyncData ToSyncData(this SyncOptions syncOptions)
        {
            return new SyncData(syncOptions.providerTypes);
        }
    }
}
