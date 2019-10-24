﻿using System.Threading.Tasks;

namespace DeclarationAutomation.Core.Sync
{
    public abstract class BaseSyncProvider : ISyncProvider
    {
        public abstract bool Authenticated { get; }
        public abstract bool Connected { get; }
        
        protected abstract Task<IReport> SyncImpl();

        public async Task<IReport> Sync()
        {
            return await SyncImpl();
        }
    }
}
