using System;

namespace DeclarationAutomation.Core.Report
{
    public interface IReport
    {
        //TODO Add Error class so we can log what went wrong.

        bool Success { get; }
        string ToString();
    }
}
