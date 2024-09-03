using Hospital.Application.Interfaces;
using Hospital.Application.Services;
using Hospital.Logic.Store;
using Hospital.Persistence.Repositories;

namespace Hospital.API.Extentions
{
    public static class ServiceProviderExtentions
    {
        public static IServiceCollection AddDoctorService(this IServiceCollection services)
        {
            services.AddScoped<IDoctorStore, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            return services;
        }

        public static IServiceCollection AddPatientService(this IServiceCollection services)
        {
            services.AddScoped<IPatientStore, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();
            return services;
        }
    }
}
