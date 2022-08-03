using CatsAndDogs.Business.Interfaces;
using CatsAndDogs.Business.Services;
using Integration.Cats.Api.Interfaces;
using Integration.Cats.Api.Services;
using Integration.Dogs.Api.Interfaces;
using Integration.Dogs.Api.Services;

namespace CatsAndDogs.Api.Helpers
{
    /// <summary>
    /// Helper for Registering different Services
    /// </summary>
    public static class Register
    {
        /// <summary>
        /// Binds the Configurations from the appsettings.json file
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void Configurations(IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<Integration.Cats.Api.Models.Configurations>(options =>
                configuration.GetSection("Configurations").Bind(options));

            services.Configure<Integration.Dogs.Api.Models.Configurations>(options =>
                configuration.GetSection("Configurations").Bind(options));
        }

        /// <summary>
        /// Registers the DI services declared within the application
        /// </summary>
        public static void Services(IServiceCollection services)
        {
            services.AddScoped<ICatsAndDogsBreedsService, CatsAndDogsBreedsServices>();
            services.AddScoped<ICatsAndDogsListService, CatsAndDogsListService>();
            services.AddScoped<ICatsAndDogsImageService, CatsAndDogsImageService>();

            services.AddScoped<ICatService, CatService>();
            services.AddScoped<IDogService, DogService>();

            services.AddAutoMapper(typeof(Program));
        }
    }
}
