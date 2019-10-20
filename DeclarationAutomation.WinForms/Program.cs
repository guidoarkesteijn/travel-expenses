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
        private static ServiceProvider? serviceProvider;

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
            Application.Run(serviceProvider.GetService<MyApplicationContext>());
        }

        private static void SetupDependencyInjector()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<MyApplicationContext>();
            serviceCollection.AddSingleton<TrayContextMenuService>();
            serviceCollection.AddSingleton<OutOfOfficeCustomFormService>();
            serviceCollection.AddSingleton<ITrayMenuItem, OutOfOfficeService>();
            serviceCollection.AddSingleton<ITrayMenuItem, PreferenceService>();
            serviceCollection.AddSingleton(GetMenuItemableFactory);

            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private static ITrayMenuItem[] GetMenuItemableFactory(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetServices<ITrayMenuItem>().ToArray();
        }
    }
}
