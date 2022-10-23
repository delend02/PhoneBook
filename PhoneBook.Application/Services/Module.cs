using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Infrastucture.Data.Context;
using PhoneBook.Infrastucture.Data.Repository;

namespace PhoneBook.Application.Services
{
    public static class Module
    {
        public static IServiceCollection DatabaseConnected(this IServiceCollection services, string connectionDB)
        {
            services.AddScoped<IRepository<TelephoneBook>, TelephoneBookRepository>();
            //services.AddScoped<IRepository<User>, UserRepository>();
            services.AddDbContext<PhoneContext>(options => 
                    options.UseSqlServer(connectionDB, 
                            sqlServerOptionsAction: sqlserverOptions =>
                            {
                                sqlserverOptions.EnableRetryOnFailure(
                                    3, TimeSpan.FromSeconds(5), new List<int> { 4060 });
                            }));
            return services;
        }

        public static IServiceCollection AddEntityServices(this IServiceCollection services)
        {
            services.AddScoped<ITelephoneServices, TelephoneService>();
            services.AddScoped<IUserServices, UserServices>();
            return services;
        }


    }
}
