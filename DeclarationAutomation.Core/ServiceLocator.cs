using System;
using System.Collections.Generic;
using System.Text;
using DeclarationAutomation.Core.Sync;
using Microsoft.Extensions.DependencyInjection;

namespace DeclarationAutomation.Core
{
    //TODO find out how to make a ServiceProvider to injecct in the layered projects.
    public class CoreServiceLocator
    {
        public ServiceProvider ServiceProvider { get; private set; }
        
        public CoreServiceLocator()
        {
            ServiceProvider = SetupDependencies();
        }

        private ServiceProvider SetupDependencies()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ISyncProvider, GoogleDriveSyncProvider>();
            serviceCollection.AddSingleton<SyncService>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
