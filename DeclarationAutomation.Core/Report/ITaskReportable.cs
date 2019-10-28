using System.Threading.Tasks;

namespace DeclarationAutomation.Core.Report
{
    public interface ITaskReportable
    {
        Task<IReport> StartTask();
    }

}
