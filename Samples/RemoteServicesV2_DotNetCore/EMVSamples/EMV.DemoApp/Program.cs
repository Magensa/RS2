using EMV.ServiceFactory;
using EMV.UIFactory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using static System.Console;


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
            WriteLine($"Webservice Url:-{svcUrl}");

            while (true)
            {
                try
                {
                    WriteLine("Please Select an option or service operation");
                    WriteLine("1.GetEMVCommands");
                    Write("Enter Option Number:-");

                    var keyInfo = ReadKey();
                    WriteLine();

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
                    WriteLine(ex.Message);
                }
            }
        }
        public static bool Confirm(string title)
        {
            ConsoleKey response;
            do
            {
                Write($"{ title } [y/n] ");
                response = ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                {
                    WriteLine();
                }
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return (response == ConsoleKey.Y);
        }
    }
}
