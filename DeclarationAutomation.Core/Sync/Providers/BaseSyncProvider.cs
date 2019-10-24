namespace DeclarationAutomation.Core.Sync
{
    public abstract class BaseSyncProvider : ISyncProvider
    {
        public abstract bool Authenticated { get; }
        public abstract bool Connected { get; }
        
        protected abstract bool SyncImpl();

        public bool Sync()
        {
            return SyncImpl();
        }
    }
}
