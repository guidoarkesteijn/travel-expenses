namespace DeclarationAutomation.Core.Report
{
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

}
