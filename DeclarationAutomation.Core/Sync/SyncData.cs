namespace DeclarationAutomation.Core.Sync
{
    public class SyncData
    {
        public readonly SyncProviderType SyncProviderType;

        public SyncData(SyncProviderType providerTypes)
        {
            SyncProviderType = providerTypes;
        }
    }
}
