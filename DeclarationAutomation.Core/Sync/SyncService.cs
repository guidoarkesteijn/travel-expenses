using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeclarationAutomation.Core.Report;

namespace DeclarationAutomation.Core.Sync
{
    public class SyncService : ITaskReportable<SyncData>
    {
        private ISyncProvider[] syncProviders;

        public SyncService(ISyncProvider[] syncProviders)
        {
            this.syncProviders = syncProviders;
        }

        public async Task<IReport> StartTask(SyncData syncData)
        {
            var report = new BundleReport("Sync Service Report");
            var filteredProviders = GetSyncProviders(syncData.SyncProviderType);

            foreach (var item in filteredProviders)
            {
                IReport syncReport = await item.Sync();
                report.AddReport(syncReport);
            }

            return report;
        }

        private ISyncProvider[] GetSyncProviders(SyncProviderType syncProviderType)
        {
            if(syncProviderType.HasFlag(SyncProviderType.All))
            {
                return syncProviders;
            }

            var filterSyncProviders = new List<ISyncProvider>();

            foreach (var item in syncProviders)
            {
                syncProviderType.HasFlag(item.SyncProviderType);
            }

            return filterSyncProviders.ToArray();
        }
    }
}
