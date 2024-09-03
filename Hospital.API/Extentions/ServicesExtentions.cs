using Hospital.Application.Interfaces;
using Hospital.Application.Services;

namespace Hospital.API.Extentions
{
    public static class ServiceProviderExtentions
    {
        public static IServiceCollection AddDoctorService(this ServiceCollection services)
        {
            services.AddScoped<IDoctorService, DoctorService>();

            return services;
        }

        public static IServiceCollection AddPatientService(this ServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();

            return services;
        }
    }
}
