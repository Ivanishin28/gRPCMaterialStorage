using BL.gRPC;
using Grpc.Net.Client;
using BL.gRPC.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Host.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args);

            builder.ConfigureServices((context, services) =>
            {
                var config = context.Configuration;

                services.AddTransient<Application>();

                services
                    .RegisterGRPCServices()
                    .RegisterGRPCClients(config);
            });

            var app = builder.Build();

            var scope = app.Services.CreateScope();
            var application = scope.ServiceProvider.GetRequiredService<Application>();
            application.Start();

            app.Run();
        }
    }
}