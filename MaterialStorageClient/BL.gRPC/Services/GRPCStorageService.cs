using BL.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.gRPC.Services
{
    public class GRPCStorageService : IStorageService
    {
        private Storage.StorageClient _storageClient;

        public GRPCStorageService(Storage.StorageClient storageClient)
        {
            _storageClient = storageClient;
        }

        public async Task<Result> Store(Material material)
        {
            var storeRequest = new StoreRequest { Amount = material.Amount };
            var storeResult = await _storageClient.StoreAsync(storeRequest);

            var errors = storeResult.Result.Errors.ToArray();
            if (errors.Length > 0)
            {
                return Result.Failure();
            }
            else
            {
                return Result.Success();
            }
        }

        public async Task<Result> Withdraw(Material material)
        {
            var withdrawRequest = new WithdrawRequest { Amount = material.Amount };
            var withdrawResult = await _storageClient.WithdrawAsync(withdrawRequest);

            var errors = withdrawResult.Result.Errors.ToArray();
            if (errors.Length > 0)
            {
                return Result.Failure();
            }
            else
            {
                return Result.Success();
            }
        }
    }
}
