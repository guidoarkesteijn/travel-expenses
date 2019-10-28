using System;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using DeclarationAutomation.Core;
using DeclarationAutomation.Core.Sync;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using CommandLine.Text;
using DeclarationAutomation.ConsoleApp.CLIOptions;
using DeclarationAutomation.Core.Report;

namespace DeclarationAutomation.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var parse = Parser.Default.ParseArguments<SyncOptions,PublishOptions>(args);
            parse.MapResult(
                (SyncOptions x) => RunSyncWithOptionsAndExit(x),
                (PublishOptions o) => RunPublishWithOptionsAndExit(o),
                errs => RunWithError(parse, errs)
            );
        }

        private static int RunWithError(ParserResult<object> parseResult, IEnumerable<Error> options)
        {
            var helpText = HelpText.AutoBuild(parseResult, h =>
                {
                    // Configure HelpText
                    h.AddEnumValuesToHelpText = true;
                    return h;
                },
                e => e,
                verbsIndex: true
            );

            Console.WriteLine(helpText);
            return 1;
        }

        private static int RunSyncWithOptionsAndExit(SyncOptions options)
        {
            var locator = new CoreServiceLocator();
            ITaskReportable syncService = locator.GetService<SyncService>();

            Console.WriteLine("Syncing");

            //IReport report = await syncService.StartTask();
            //Console.Write(report);

            return 0;
        }

        private static int RunPublishWithOptionsAndExit(PublishOptions publishOptions)
        {
            return 0;
        }
    }
}
