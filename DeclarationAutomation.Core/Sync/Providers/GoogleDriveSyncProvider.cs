using System;
using System.Threading.Tasks;
using DeclarationAutomation.Core.Report;

namespace DeclarationAutomation.Core.Sync
{
    public class GoogleDriveSyncProvider : BaseSyncProvider
    {
        public override bool Authenticated => authenticated;
        private bool authenticated;

        public override bool Connected => connected;
        private bool connected;

        protected override async Task<IReport> SyncImpl()
        {
            await Task.Delay(5000);
            return new GoogleDriveReport(GoogleDriveReport.Status.SUCCESS);
        }
    }
}
