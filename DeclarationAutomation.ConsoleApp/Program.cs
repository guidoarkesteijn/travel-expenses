using System;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using DeclarationAutomation.Core;
using DeclarationAutomation.Core.Sync;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using CommandLine.Text;

namespace DeclarationAutomation.ConsoleApp
{
    class Program
    {
        //TODO add nice way to add simple command line arugments with a package and forward them to the correct 'Controller'
        static async Task Main(string[] args)
        {
            var parse = Parser.Default.ParseArguments<SyncOptions>(args);
            parse.MapResult(
                (SyncOptions x) => RunWithOptionsAndExit(x),
                errs => RunWithError(parse, errs)
            );
        }

        private static int RunWithError(ParserResult<SyncOptions> parse, IEnumerable<Error> options)
        {
            var helpText = HelpText.AutoBuild(parse, h =>
                {
                    // Configure HelpText	 
                    h.AddEnumValuesToHelpText = true;
                    return h;
                },
                e => e,
                verbsIndex: true
            );  //to show Verb help summary, set verbsIndex =true

            Console.WriteLine(helpText);
            return 1;
        }

        private static int RunWithOptionsAndExit(SyncOptions options)
        {
            var locator = new CoreServiceLocator();
            ITaskReportable syncService = locator.GetService<SyncService>();

            Console.WriteLine("Syncing");

            //IReport report = await syncService.StartTask();
            //Console.Write(report);

            return 0;
        }
    }
}
