using BL.gRPC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.gRPC.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureGRPC(this IEndpointRouteBuilder builder)
        {
            builder.MapGrpcService<StorageService>();
        }
    }
}
