using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using DeclarationAutomation.ConsoleApp.CLIOptions;
using DeclarationAutomation.Core;
using DeclarationAutomation.Core.Report;
using DeclarationAutomation.Core.Sync;

namespace DeclarationAutomation.ConsoleApp
{
    class Program
    {
        static async Task<int> Main(string [] args)
        {
            var parseResult = Parser.Default.ParseArguments<SyncOptions, PublishOptions>(args);

            int result = await parseResult.MapResult(
              (SyncOptions opts) => RunSyncWithOptionsAndExit(opts),
              (PublishOptions opts) => RunPublishWithOptionsAndExit(opts),
              errs => RunWithError(parseResult, errs));

            return result;
        }

        private static async Task<int> RunWithError(ParserResult<object> parseResult, IEnumerable<Error> options)
        {
            //TODO find a way to remove the duplicate error text.
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
            return await Task.FromResult(1);
        }

        //TODO make this more generic between different methods? Sync, Publish, etc.
        private static async Task<int> RunSyncWithOptionsAndExit(SyncOptions syncOptions)
        {
            var locator = new CoreServiceLocator();
            ITaskReportable<SyncData> syncService = locator.GetService<SyncService>();
            IReport report = await syncService.StartTask(syncOptions.ToSyncData()).ConfigureAwait(true);

            Console.WriteLine(report);

            if (report.Success)
            {
                return 0;
            }

            return -1;
        }

        private static async Task<int> RunPublishWithOptionsAndExit(PublishOptions publishOptions)
        {
            //TODO implement publishing
            await Task.Delay(5000);

            return 0;
        }
    }
}
