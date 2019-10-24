using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeclarationAutomation.Core.Sync;
using Microsoft.Extensions.DependencyInjection;

namespace DeclarationAutomation.Core
{
    //TODO find out how to make a ServiceProvider to injecct in the layered projects.
    public class CoreServiceLocator
    {
        private ServiceProvider serviceProvider;
        
        public CoreServiceLocator()
        {
            serviceProvider = SetupDependencies();
        }

        public T GetService<T>()
        {
            return serviceProvider.GetService<T>();
        }

        public T[] GetServices<T>()
        {
            return serviceProvider.GetServices<T>().ToArray();
        }

        private ServiceProvider SetupDependencies()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<SyncService>();
            serviceCollection.AddSingleton<ISyncProvider, GoogleDriveSyncProvider>();
            //Add multiple Sync providers.
            serviceCollection.AddSingleton(GetSyncProviders);
            serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceCollection.BuildServiceProvider();
        }

        private ISyncProvider[] GetSyncProviders(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetServices<ISyncProvider>().ToArray();
        }
    }
}
