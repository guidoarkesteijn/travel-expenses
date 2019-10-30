using System;

namespace DeclarationAutomation.Core.Sync
{
    [Flags]
    public enum SyncProviderType
    {
        All = 0,
        GoogleDrive = 1,
        OneDrive = 2
    }
}
