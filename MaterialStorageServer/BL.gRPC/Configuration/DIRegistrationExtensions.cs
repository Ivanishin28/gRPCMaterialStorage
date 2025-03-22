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
            services.AddGrpc();

            return services;
        }
    }
}
