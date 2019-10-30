using System;

namespace DeclarationAutomation.Core.Report
{
    public interface IReport
    {
        bool Success { get; }
        string ToString();
    }
}
