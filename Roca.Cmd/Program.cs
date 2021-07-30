using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Roca.Bot;
using Roca.Core;

namespace Roca.Cmd
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration config = CreateConfiguration(args);
            Mongo.Initialize(config);
            RocaBot bot = new(config);

            await bot.Start().ConfigureAwait(false);

            Console.ReadLine();

            await bot.Stop().ConfigureAwait(false);
        }

        static IConfiguration CreateConfiguration(string[] args) =>
            Host.CreateDefaultBuilder(args).Build().Services.GetService<IConfiguration>();
    }
}
