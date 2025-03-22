using DL.Repositories;
using Domain.Models;
using Grpc.Core;

namespace BL.gRPC.Services
{
    public class StorageService : Storage.StorageBase
    {
        private IStorageRepository _repository;

        public StorageService(IStorageRepository repository)
        {
            _repository = repository;
        }

        public override Task<StoreResponse> Store(StoreRequest request, ServerCallContext context)
        {
            var material = new Material(request.Amount);
            var storage = _repository.GetStorage();
            var storeResult = storage.StoreMaterial(material);

            if (storeResult.IsSuccess)
            {
                Console.WriteLine($"Successfully stored ${material.Amount}");
            }
            else
            {
                Console.WriteLine(storeResult.ErrorMessage);
            }

            var storeResponse = new StoreResponse()
            {
                Result = new ResultMessage { Errors = { storeResult.Errors } }
            };
            return Task.FromResult(storeResponse);
        }

        public override Task<WithdrawResponse> Withdraw(WithdrawRequest request, ServerCallContext context)
        {
            var material = new Material(request.Amount);
            var storage = _repository.GetStorage();
            var storageResponse = storage.StoreMaterial(material);
            var result = new WithdrawResponse()
            {
                Result = new ResultMessage { Errors = { storageResponse.Errors } }
            };
            return Task.FromResult(result);
        }
    }
}
