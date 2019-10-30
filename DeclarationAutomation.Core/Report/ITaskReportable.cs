using System.Threading.Tasks;

namespace DeclarationAutomation.Core.Report
{
    public interface ITaskReportable<T>
    {
        Task<IReport> StartTask(T data);
    }

}
