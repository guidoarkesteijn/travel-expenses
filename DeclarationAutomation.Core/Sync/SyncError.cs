
using DeclarationAutomation.Core.ErrorReporting;

namespace DeclarationAutomation.Core.Sync
{
    //TODO use syncError to report back what is wrong in the report.
    public class SyncError : Error
    {
        public SyncError(string message) : base(message)
        {
        }
    }
}
