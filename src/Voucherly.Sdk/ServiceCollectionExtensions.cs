using fbognini.Sdk.Extensions;
using fbognini.Sdk.Handlers;
using fbognini.Sdk.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Voucherly.Sdk
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddVoucherlyApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<VoucherlyApiSettings>(configuration.GetSection(nameof(VoucherlyApiSettings)));

            services.AddHttpClient<IVoucherlyApiService, VoucherlyApiService>()
                .ThrowApiExceptionIfNotSuccess()
                .AddLogging();

            return services;
        }
    }
}
