using Microsoft.Extensions.DependencyInjection;
using Wikification.Business.Implementation;
using Wikification.Business.Interfaces;

namespace Wikification.Bootstrap
{
    public class BusinessIoC
    {
        internal static void AddAllDependencies(IServiceCollection services)
        {
            services.AddScoped<IContentPageBusiness, ContentPageBusiness>();
        }
    }
}
