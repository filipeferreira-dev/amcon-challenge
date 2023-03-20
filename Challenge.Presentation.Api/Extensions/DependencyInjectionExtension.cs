using Challenge.ApplicationService.Services;
using Challenge.ApplicationService.Services.Contracts;
using Challenge.Domain.Repositories;
using Challenge.Infra.Data.Repositories;
using Challenge.SharedKernel.Repositories;

namespace Challenge.Presentation.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            //Configure dependencies
            services.AddTransient<IMerchantRepository, MerchantRepository>();
            services.AddTransient<IMerchantApplicationService, MerchantApplicationService>();
            services.AddTransient<ICacheService, CacheService>();
            services.AddTransient<ICacheRepository, CacheRepository>();
            services.AddTransient<ISyncService, SyncService>();
        }
    }
}
