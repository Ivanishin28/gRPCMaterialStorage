using BL.gRPC;
using Grpc.Net.Client;

namespace Host.App
{
    public class Application
    {
        private Storage.StorageClient _storageClient;

        public Application(Storage.StorageClient storageClient)
        {
            _storageClient = storageClient;
        }

        public async void Start()
        {
            var message = new StoreRequest { Amount = 1000 };
            var storeResponse = await _storageClient.StoreAsync(message);
            Console.WriteLine(storeResponse.Result.Errors.ToArray().Length);
        }
    }
}
