using System;
using System.Linq;
using System.Threading.Tasks;
using DeclarationAutomation.Core;
using DeclarationAutomation.Core.Sync;
using Microsoft.Extensions.DependencyInjection;

namespace DeclarationAutomation.ConsoleApp
{
    class Program
    {
        //TODO can we make this an async main entry point.
        //TODO add nice way to add simple command line arugments with a package and forward them to the correct 'Controller'
        static void Main(string[] args)
        {
            foreach (var item in args)
            {
                Console.WriteLine("Arg:" + item);
            }

            bool completed = false;
            
            var locator = new CoreServiceLocator();
            ITaskReportable syncService = locator.GetService<SyncService>();
            var task = new Task(async () =>
            {
                Console.WriteLine("Syncing");

                IReport report = await syncService.StartTask();
                Console.Write(report);
                completed = true;
            });
            task.Start();

            //based on the arguments start the correct service and calls.
            while (!completed)
            {
                //Wait for completed to be done :)
            }
        }
    }
}
