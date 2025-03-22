using BL.gRPC.Services;
using BL.Interfaces;
using Grpc.Net.ClientFactory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.gRPC.Configuration
{
    public static class DIRegistrationExtensions
    {
        public static IServiceCollection RegisterGRPC(this IServiceCollection services)
        {
            services.AddTransient<IStorageService, GRPCStorageService>();

            services.RegisterGRPCClients();

            return services;
        }

        private static IServiceCollection RegisterGRPCClients(this IServiceCollection services)
        {
            services.Configure<GrpcClientFactoryOptions>(options =>
            {
                options.Address = new Uri("http://localhost:5000/");
            });

            services.AddGrpcClient<Storage.StorageClient>();

            return services;
        }
    }
}
