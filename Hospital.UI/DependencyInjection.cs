using Hospital.UI.Pages;
using Hospital.UI.ViewModels;

namespace Hospital.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(
            this IServiceCollection services)
        {
            services.AddTransient<HospitalWardsPage>().
                AddTransient<PatientDetailsPage>()
                .AddTransient<UpdateHospitalWardPage>()
                .AddTransient<AddHospitalWardPage>()
                .AddTransient<AddPatientByHospitalWardPage>()
                .AddTransient<UpdatePatientPage>();
            return services;
        }

        public static IServiceCollection RegisterViewModels(
        this IServiceCollection services)
        {
            services.AddTransient<HospitalWardsViewModel>()
                .AddTransient<PatientDetailsViewModel>()
                .AddTransient<UpdateHospitalWardViewModel>()
                .AddTransient<UpdateHospitalWardViewModel>()
                .AddTransient<AddPatientByHospitalWardViewModel>()
                .AddTransient<UpdatePatientViewModel>();
            return services;
        }
        

    }
}
