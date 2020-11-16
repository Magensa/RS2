using EMV.ServiceFactory;
using EMV.UIFactory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;


namespace DecryptV2.DemoApp
{
    class Program
    {
        static void Main()
        {
            _ = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(config);
            services.AddSingleton<IEMVUIFactory, EMVUIFactory>();
            services.AddSingleton<IEMVClient, EMVClient>();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var uiFactory = serviceProvider.GetService<IEMVUIFactory>();

            var svcUrl = config.GetValue<string>("EMVURL");
            Console.WriteLine($"Webservice Url:-{svcUrl}");

            while (true)
            {
                try
                {
                    Console.WriteLine("Please Select an option or service operation");
                    Console.WriteLine("1.GetEMVCommands");
                    Console.Write("Enter Option Number:-");

                    var keyInfo = Console.ReadKey();
                    Console.WriteLine();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.D1:
                            uiFactory.ShowUI(EMVUI.GETEMVCOMMANDS);
                            break;
                    }
                    bool decision = Confirm("Would you like to Continue with other Request");
                    if (decision)
                        continue;
                    else
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static bool Confirm(string title)
        {
            ConsoleKey response;
            do
            {
                Console.Write($"{ title } [y/n] ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return (response == ConsoleKey.Y);
        }
    }
}
