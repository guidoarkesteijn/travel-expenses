using System;

namespace DeclarationAutomation.Core.Sync
{
    public class GoogleDriveSyncProvider : BaseSyncProvider
    {
        public override bool Authenticated => authenticated;
        private bool authenticated;

        public override bool Connected => connected;
        private bool connected;

        protected override bool SyncImpl()
        {
            throw new NotImplementedException();
        }
    }
}
