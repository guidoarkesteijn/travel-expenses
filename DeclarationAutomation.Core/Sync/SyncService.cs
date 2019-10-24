using System;
using System.Collections.Generic;
using System.Text;

namespace DeclarationAutomation.Core.Sync
{
    public class SyncService
    {
        private ISyncProvider[] syncProviders;

        internal SyncService(ISyncProvider[] syncProviders)
        {
            this.syncProviders = syncProviders;
        }

        public void Sync()
        {
            bool completed = false;

            foreach (var item in syncProviders)
            {
                completed = item.Sync();
            }
        }
    }
}
