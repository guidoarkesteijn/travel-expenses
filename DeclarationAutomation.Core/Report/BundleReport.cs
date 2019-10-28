using System.Collections.Generic;
using System.Text;

namespace DeclarationAutomation.Core.Report
{
    public class BundleReport : IReport
    {
        public string Header { get; private set; }

        protected List<IReport> reports = new List<IReport>();

        public BundleReport(string message)
        {
            Header = message;
        }

        public void AddReport(IReport report)
        {
            reports.Add(report);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Header);

            foreach (var item in reports)
            {
                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }
    }

}
