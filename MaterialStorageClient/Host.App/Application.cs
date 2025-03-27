using BL.gRPC;
using BL.Interfaces;
using Domain.Models;
using Grpc.Net.Client;

namespace Host.App
{
    public class Application
    {
        private IStorageService _storageService;

        public Application(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async void Start()
        {
            var materialToStore = new Material(1000);
            var result = await _storageService.Store(materialToStore);
            if (result.IsSuccess)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }
        }
    }
}
