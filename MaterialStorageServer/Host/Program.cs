using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder();
            builder.Services.AddTransient<Application>();
            using var host = builder.Build();

            using var scope = host.Services.CreateScope();
            var application = scope.ServiceProvider.GetRequiredService<Application>();
            application.Start();

            host.Run();
        }
    }
}