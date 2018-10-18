using Microsoft.Extensions.DependencyInjection;
using Wikification.Business.Implementation;
using Wikification.Business.Interfaces;
using Wikification.Data;
using Wikification.Data.Interfaces;

namespace Wikification.Bootstrap
{
    /// <summary>
    /// Uses Microsoft.Extensions.DependencyInjection and Scrutor https://github.com/khellang/Scrutor
    /// </summary>
    public class BusinessIoC
    {
        internal static void AddAllDependencies(IServiceCollection services)
        {
            services.AddScoped<ILogifier, Logifier>();
            services.AddScoped<IEventLogger, EventLogger>();

            services.AddScoped<IContentPageBusiness, ContentPageBusiness>();
            services.Decorate<IContentPageBusiness, ContentPageBusinessDecorator>();
            services.Decorate<IContentPageBusiness>((inner, provider)
                => new ContentPageBusinessEventLoggingDecorator(inner,
                    provider.GetRequiredService<MainContext>(),
                    provider.GetRequiredService<IEventLogger>()));
            services.Decorate<IContentPageBusiness>((inner, provider)
                => new ContentPageBusinessValidationDecorator(inner, provider.GetRequiredService<MainContext>()));
            services.Decorate<IContentPageBusiness>((inner, provider)
                => new ContentPageBusinessExceptionLoggingDecorator(inner, provider.GetRequiredService<ILogifier>()));

            services.AddScoped<ISystemBusiness, SystemBusiness>();
            services.Decorate<ISystemBusiness, SystemBusinessDecorator>();
            services.Decorate<ISystemBusiness>((inner, provider)
                => new SystemBusinessEventLoggingDecorator(inner,
                    provider.GetRequiredService<MainContext>(),
                    provider.GetRequiredService<IEventLogger>()));
            services.Decorate<ISystemBusiness>((inner, provider)
                => new SystemBusinessValidationDecorator(inner, provider.GetRequiredService<MainContext>()));
            services.Decorate<ISystemBusiness>((inner, provider)
                => new SystemBusinessExceptionLoggingDecorator(inner, provider.GetRequiredService<ILogifier>()));

            services.AddScoped<IAchievementBusiness, AchievementBusiness>();
            services.Decorate<IAchievementBusiness, AchievementBusinessDecorator>();
            services.Decorate<IAchievementBusiness>((inner, provider)
                => new AchievementBusinessEventLoggingDecorator(inner, provider.GetRequiredService<MainContext>(), provider.GetRequiredService<IEventLogger>()));
            services.Decorate<IAchievementBusiness>((inner, provider)
                => new AchievementBusinessValidationDecorator(inner, provider.GetRequiredService<MainContext>()));
            services.Decorate<IAchievementBusiness>((inner, provider)
                => new AchievementBusinessExceptionLoggingDecorator(inner, provider.GetRequiredService<ILogifier>()));
        }
    }
}
