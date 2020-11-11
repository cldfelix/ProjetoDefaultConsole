namespace CapturaDadosInfraero
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using log4net;
    using Microsoft.Extensions.Configuration;

    internal class Main
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        internal static async Task Work(string[] args)
        {
            await Task.FromResult(0);

            Logger.Info("Hello claud! CLR:4.0.30319.42000");
            Logger.Warn("Goodbye.");
            Logger.Error("我爱你。 愛してます。 사랑해요. 🌏");

            1.UpTo(8).ForEach(i => Logger.Debug("_".JoinArray("^".Times(i))));

            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            var mySettingsConfig = new MySettingsConfig();
            configuration.GetSection("MySettings").Bind(mySettingsConfig);

            Console.WriteLine("Setting from appsettings.json: " + mySettingsConfig.AccountName);
            Console.WriteLine("Setting from secrets.json: " + mySettingsConfig.ApiSecret);
            Console.WriteLine("Connection string: " + configuration.GetConnectionString("DefaultConnection"));

            Console.ReadKey();


        }
    }
}
