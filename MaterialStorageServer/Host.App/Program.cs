using DL.InMemory.Configuration;
using BL.gRPC.Configuration;

namespace Host.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder
                .Services
                .RegisterInMemoryDL()
                .RegisterGRPC();

            var app = builder.Build();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.ConfigureGRPC();

            app.Run();
        }
    }
}