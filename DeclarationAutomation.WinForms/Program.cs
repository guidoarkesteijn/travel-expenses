using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace DeclarationAutomation.WinForms
{
    static class Program
    {
        static ServiceProvider serviceProvider;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetupDependencyInjector();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyApplicationContext());
        }

        private static void SetupDependencyInjector()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<NotificationService>();

            serviceProvider = serviceCollection.BuildServiceProvider();

            var notificationService = serviceProvider.GetService<NotificationService>();

            Console.WriteLine(notificationService);
        }
    }
}
