using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace MSDependencyInjectionTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            // Use Hosting to creat our services.
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    services.AddTransient<ITransientOperation, DefaultOperation>();
                    services.AddScoped<IScopedOperation, DefaultOperation>();
                    services.AddSingleton<ISingletonOperation, DefaultOperation>();
                    services.AddTransient<OperationLogger>();
                })
                .Build();

            ExemplifyScoping(host.Services, "Scope 1");
            ExemplifyScoping(host.Services, "Scope 2");

            

            // Call the base object's OnStartup method;
            base.OnStartup(e);

            // Make and show the MainWindow since we removed the StartUpURI from App.xaml.
            MainWindow w = new();
            this.MainWindow = w;
            w.Show();
        }

        static void ExemplifyScoping(IServiceProvider services, string scope)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            OperationLogger logger = provider.GetRequiredService<OperationLogger>();
            logger.LogOperations($"{scope}-Call 1 .GetRequiredService<OperationLogger>()");

            Debug.WriteLine("...");

            logger = provider.GetRequiredService<OperationLogger>();
            logger.LogOperations($"{scope}-Call 2 .GetRequiredService<OperationLogger>()");

            Debug.WriteLine("");
        }

    }
}
