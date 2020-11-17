using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DI
{
    public static class ServicesExtender
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string conn)
        {
            services.AddDbContext<CarsDbContext>(opts =>
            {
                opts.UseSqlServer(conn);
            });
            return services;
        }
    }
}
