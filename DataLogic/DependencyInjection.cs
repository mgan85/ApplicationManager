using DataLogic.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataLogic;
public static class DependencyInjection
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IPhoneRepository, PhoneRepository>();
        services.AddScoped<IJobTypeRepository, JobTypeRepository>();
        services.AddScoped<ISkillLevelRepository, SkillLevelRepository>();
        services.AddScoped<IApplicationStatusRepository, ApplicationStatusRepository>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IHandlerRepository, HandlerRepository>();
        services.AddScoped<IJobOfferRepository, JobOfferRepository>();
        services.AddScoped<IApplicationRepository, ApplicationRepository>();

        services.AddScoped<IUserSkillRepository, UserSkillRepository>();
        services.AddScoped<IJobOfferRequiredSkillRepository, JobOfferRequiredSkillRepository>();

        return services;
    }
}
