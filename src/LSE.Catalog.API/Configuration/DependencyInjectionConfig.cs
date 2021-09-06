using LSE.Catalog.API.Service;
using LSE.Catalog.Domain.Repositories;
using LSE.Catalog.Infrastructure.Data;
using LSE.Catalog.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LSE.Catalog.API.Configuration
{
    public static class DependencyInjectionConfig
    {

        //private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());

        public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<CatalogDbContext>(options => options.UseInMemoryDatabase("ProductsDB"));

            services.AddDbContext<CatalogDbContext>(options => options
                //.UseLoggerFactory(_logger)
                //.EnableSensitiveDataLogging()
                .UseSqlServer(configuration.GetConnectionString("SQLServerCs")
            ));

            services.AddTransient<ProductPopulateService>();

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}