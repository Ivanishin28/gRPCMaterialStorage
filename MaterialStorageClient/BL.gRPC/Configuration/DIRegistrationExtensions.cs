using BL.gRPC.Services;
using BL.Interfaces;
using Grpc.Net.ClientFactory;
using Microsoft.Extensions.Configuration;
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
        public static IServiceCollection RegisterGRPCServices(this IServiceCollection services)
        {
            services.AddTransient<IStorageService, GRPCStorageService>();

            return services;
        }

        public static IServiceCollection RegisterGRPCClients(this IServiceCollection services, IConfiguration config)
        {
            var grpcOptions = config.GetSection(GRPCOptions.SECTION_NAME).Get<GRPCOptions>();

            services.Configure<GrpcClientFactoryOptions>(options =>
            {
                options.Address = new Uri(grpcOptions.ChannelAddress);
            });

            services.AddGrpcClient<Storage.StorageClient>();

            return services;
        }
    }
}
