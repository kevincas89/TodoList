
using BLL.Interface;
using DAL.Base;
using DAL.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Site.Middleware
{
    public static class Ioc
    {
        public static IServiceCollection AddDependecy(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            return services;
        }
    }
}
