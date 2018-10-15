using Microsoft.Extensions.DependencyInjection;
using Wikification.Business.Implementation;
using Wikification.Business.Interfaces;
using Scrutor;
using Wikification.Data;
using Microsoft.EntityFrameworkCore;

namespace Wikification.Bootstrap
{
    public class BusinessIoC
    {
        internal static void AddAllDependencies(IServiceCollection services)
        {
            services.AddScoped<IContentPageBusiness, ContentPageBusiness>();
            services.AddScoped<ISystemBusiness, SystemBusiness>();
            //services.AddScoped<IAchievementBusiness, AchievementBusiness>();
            //services.AddDbContext<DbContext, MainContext>();

            services.AddSingleton<IAchievementBusiness, AchievementBusiness>();
            services.Decorate<IAchievementBusiness, AchievementBusinessDecorator>();
            services.Decorate<IAchievementBusiness>((inner, provider)
                => new AchievementBusinessValidationDecorator(inner, provider.GetRequiredService<MainContext>()));

            //TODO installera decorators och scanning med https://github.com/khellang/Scrutor
        }
    }
}
