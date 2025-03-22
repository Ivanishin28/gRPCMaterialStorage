using DL.InMemory.Repositories;
using DL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.InMemory.Configuration
{
    public static class DIRegistrationExtensions
    {
        public static IServiceCollection RegisterInMemoryDL(this IServiceCollection services)
        {
            services.AddTransient<IStorageRepository, MemoryStorageRepository>();

            return services;
        }
    }
}
