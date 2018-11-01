using RtfGenerator.Generator;
using RtfGenerator.Service;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RtfGenerator
{
    class Program
    {
        private static readonly IService _service = new Service.Service("http://localhost:51341", new RandomIndexGenerator());

        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;

            MainAsync(args).GetAwaiter().GetResult();
        }



        async static Task MainAsync(string[] args)
        {
            try
            {
                Settings settings = SettingsParser.Parse(args);
                if (settings.NeedGenerate)
                    await _service.GenerateAsync();
            }
            catch(Exception ex)
            {
                await Console.Out.WriteAsync($"Error :: {ex.Message}");
            }
        }
    }
}
