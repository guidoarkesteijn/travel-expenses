using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeclarationAutomation.Core.Report;

namespace DeclarationAutomation.Core.Sync
{
    public class SyncService : ITaskReportable
    {
        private ISyncProvider[] syncProviders;

        public SyncService(ISyncProvider[] syncProviders)
        {
            this.syncProviders = syncProviders;
        }

        public async Task<IReport> StartTask()
        {
            var report = new BundleReport("Sync Service Report");
            
            foreach (var item in syncProviders)
            {
                IReport syncReport = await item.Sync();
                report.AddReport(syncReport);
            }

            return report;
        }
    }
}
