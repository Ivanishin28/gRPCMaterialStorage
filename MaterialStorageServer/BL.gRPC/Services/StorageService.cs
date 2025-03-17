using DL.Repositories;
using Domain.Models;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.gRPC.Services
{
    public class StorageService : Storage.StorageBase
    {
        private IStorageRepository _repository;

        public override Task<StoreResponse> Store(StoreRequest request, ServerCallContext context)
        {
            var material = new Material(request.Amount);
            return base.Store(request, context);
        }

        public override Task<WithdrawResponse> Withdraw(WithdrawRequest request, ServerCallContext context)
        {
            return base.Withdraw(request, context);
        }
    }
}
