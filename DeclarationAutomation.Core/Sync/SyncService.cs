using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationAutomation.Core.Sync
{
    public interface ITaskReportable
    {
        Task<IReport> StartTask();
    }

    public interface IReport
    {
        string ToString();
    }

    public class GoogleDriveReport : IReport
    {
        public enum Status
        {
            UNKNOWN = -1,
            SUCCESS = 0,
            FAILED = 1,
            ABORTED = 2
        }

        private Status currentStatus;

        public GoogleDriveReport(Status currentStatus)
        {
            this.currentStatus = currentStatus;
        }

        public override string ToString()
        {
            return "Google Drive Sync: " + currentStatus;
        }
    }

    public class BundleReport : IReport
    {
        public string Header { get; private set; }

        protected List<IReport> reports = new List<IReport>();

        public BundleReport(string message)
        {
            Header = message;
        }

        public void AddReport(IReport report)
        {
            reports.Add(report);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Header);
            
            foreach (var item in reports)
            {
                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }
    }

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
