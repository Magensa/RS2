using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PPSCRAv2.ServiceFactory;
using PPSCRAv2.UIFactory;
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
            services.AddSingleton<IPPSCRAv2UIFactory, PPSCRAv2UIFactory>();
            services.AddSingleton<IPPSCRAv2Client, PPSCRAv2Client>();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var uiFactory = serviceProvider.GetService<IPPSCRAv2UIFactory>();

            var svcUrl = config.GetValue<string>("SERVICEURL");
            Console.WriteLine($"Webservice Url:-{svcUrl}");

            while (true)
            {
                try
                {
                    Console.WriteLine("Please Select an option or service operation");
                    Console.WriteLine("1.GetCertLoadCommand");
                    Console.WriteLine("2.GetCommandListByDevice");
                    Console.WriteLine("3.GetDeviceAuthCommand");
                    Console.WriteLine("4.GetEnableSREDCommand");
                    Console.WriteLine("5.GetKeyList");
                    Console.WriteLine("6.GetKeyLoadCommand");
                    Console.WriteLine("7.GetLoadConfigCommand");
                    Console.WriteLine("8.GetPreActivateCommand");


                    var keyInfo = Console.ReadKey();
                    Console.WriteLine();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.D1:
                            uiFactory.ShowUI(PPSCRAv2UI.GetCertLoadCommand);
                            break;
                        case ConsoleKey.D2:
                            uiFactory.ShowUI(PPSCRAv2UI.GetCommandListByDevice);
                            break;
                        case ConsoleKey.D3:
                            uiFactory.ShowUI(PPSCRAv2UI.GetDeviceAuthCommand);
                            break;
                        case ConsoleKey.D4:
                            uiFactory.ShowUI(PPSCRAv2UI.GetEnableSREDCommand);
                            break;
                        case ConsoleKey.D5:
                            uiFactory.ShowUI(PPSCRAv2UI.GetKeyList);
                            break;
                        case ConsoleKey.D6:
                            uiFactory.ShowUI(PPSCRAv2UI.GetKeyLoadCommand);
                            break;
                        case ConsoleKey.D7:
                            uiFactory.ShowUI(PPSCRAv2UI.GetLoadConfigCommand);
                            break;
                        case ConsoleKey.D8:
                            uiFactory.ShowUI(PPSCRAv2UI.GetPreActivateCommand);
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
