using DeclarationAutomation.Core.ErrorReporting;

namespace DeclarationAutomation.Core.Sync
{
    public class SyncError : Error
    {
        public SyncError(string message) : base(message)
        {
        }
    }
}
