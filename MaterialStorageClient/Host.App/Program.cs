using BL.gRPC;
using Grpc.Net.Client;
using BL.gRPC.Configuration;

namespace Host.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var address = new Uri("https://localhost:7088/");
            using var channel = GrpcChannel.ForAddress(address);
            var storage = new Storage.StorageClient(channel);
            var message = new StoreRequest { Amount = 1000 };
            var storeResponse = await storage.StoreAsync(message);
            Console.WriteLine(storeResponse.Result.Errors.ToArray().Length);
        }
    }
}