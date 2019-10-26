using System;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using DeclarationAutomation.Core;
using DeclarationAutomation.Core.Sync;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace DeclarationAutomation.ConsoleApp
{
    class Program
    {
        //TODO add nice way to add simple command line arugments with a package and forward them to the correct 'Controller'
        static async Task Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithNotParsed(RunWithError)
                .WithParsed(RunWithOptionsAndExit);
        }

        private static void RunWithError(IEnumerable<Error> options)
        {
            Console.WriteLine("error");
        }

        private static void RunWithOptionsAndExit(CommandLineOptions options)
        {
            var locator = new CoreServiceLocator();
            ITaskReportable syncService = locator.GetService<SyncService>();

            Console.WriteLine("Syncing");

            //IReport report = await syncService.StartTask();
            //Console.Write(report);
        }
    }
}
