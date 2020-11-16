using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCRAv2.ServiceFactory;
using SCRAv2.UIFactory;
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
            services.AddSingleton<ISCRAv2UIFactory, SCRAv2UIFactory>();
            services.AddSingleton<ISCRAv2Client, SCRAv2Client>();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var uiFactory = serviceProvider.GetService<ISCRAv2UIFactory>();

            var svcUrl = config.GetValue<string>("SCRAv2Url");
            Console.WriteLine($"Webservice Url:-{svcUrl}");

            while (true)
            {
                try
                {
                    Console.WriteLine("Please Select an option or service operation");
                    Console.WriteLine("1.GetCommandByKSN");
                    Console.WriteLine("2.GetCommandList");
                    Console.WriteLine("3.GetFirmwareList");
                    Console.WriteLine("4.GetKeyList");
                    Console.WriteLine("5.GetCommandByMUT");
                    Console.WriteLine("6.GetFirmwareByMUT");
                    Console.WriteLine("7.GetFirmwareCommands");
                    Console.WriteLine("8.GetKeyLoadCommand");
                    Console.Write("Enter Option Number:-");

                    var keyInfo = Console.ReadKey();
                    Console.WriteLine();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.D1:
                            uiFactory.ShowUI(SCRAv2UI.GetCommandByKSN);
                            break;
                        case ConsoleKey.D2:
                            uiFactory.ShowUI(SCRAv2UI.GETCOMMANDLIST);
                            break;
                        case ConsoleKey.D3:
                            uiFactory.ShowUI(SCRAv2UI.GETFIRMWARELIST);
                            break;
                        case ConsoleKey.D4:
                            uiFactory.ShowUI(SCRAv2UI.GETKEYLIST);
                            break;
                        case ConsoleKey.D5:
                            uiFactory.ShowUI(SCRAv2UI.GETCOMMANDBYMUT);
                            break;
                        case ConsoleKey.D6:
                            uiFactory.ShowUI(SCRAv2UI.GETFIRMWAREBYMUT);
                            break;
                        case ConsoleKey.D7:
                            uiFactory.ShowUI(SCRAv2UI.GETFIRMWARECOMMANDS);
                            break;
                        case ConsoleKey.D8:
                            uiFactory.ShowUI(SCRAv2UI.GETKEYLOADCOMMAND);
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
