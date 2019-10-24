namespace DeclarationAutomation.Core.Sync
{
    public interface ISyncProvider
    {
        bool Authenticated { get; }
        bool Connected { get; }

        bool Sync();
    }
}
