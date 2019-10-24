using System.Threading.Tasks;

namespace DeclarationAutomation.Core.Sync
{
    public interface ISyncProvider
    {
        bool Authenticated { get; }
        bool Connected { get; }

        Task<IReport> Sync();
    }
}
