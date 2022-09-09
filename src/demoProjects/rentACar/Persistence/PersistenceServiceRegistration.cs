using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        //Persistent'ı ilgilendiren bütün registiration işlemleri burada yapılacak.
        //Her katmanın registiration işlemi kendi katmanında yapılacak ve en sonunda webApi Program.cs dosyasına eklenecek

        //"this IServiceCollection services" kullanımı extension yazmak için kullanılan bir implementasyondur
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("RentACarCampConnectionString")));
            //Repository registrations
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();

            return services;
        }
    }
}