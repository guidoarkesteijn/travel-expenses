using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DeclarationAutomation.ConsoleApp.CLIOptions;

namespace DeclarationAutomation.ConsoleApp.Controller
{
    abstract class BaseCommandLineController<O> where O : Options
    {
        internal abstract int RunCommandAndExit(O options);
    }
}
