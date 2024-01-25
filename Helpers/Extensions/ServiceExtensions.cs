//using Examen.Repositories.UserRepository;
//using Examen.Services.SMTP;

using EXAMEN.Repositories.EvenimentRepository;
using EXAMEN.Repositories.ParticipantRepository;
using EXAMEN.Services;

namespace Examen.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IEvenimentRepository, EvenimentRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //services.AddTransient<IAuthService, AuthService>();
            //services.AddScoped<EXAMEN.Services.DogService.DogService.IDogService, DogService>();
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<IEvenimentService, EvenimentService>();
            return services;
        }


    }
}
