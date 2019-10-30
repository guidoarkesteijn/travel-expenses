namespace DeclarationAutomation.Core.Report
{
    public class GoogleDriveReport : IReport
    {
        public enum Status
        {
            Unknown = -1,
            Success = 0,
            Failed = 1,
            Aborted = 2
        }

        private Status currentStatus;

        public bool Success => currentStatus == Status.Success;

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
