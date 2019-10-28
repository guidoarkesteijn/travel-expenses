using System.Threading.Tasks;
using DeclarationAutomation.Core.Report;

namespace DeclarationAutomation.Core.Sync
{
    public interface ISyncProvider
    {
        bool Authenticated { get; }
        bool Connected { get; }

        Task<IReport> Sync();
    }
}
