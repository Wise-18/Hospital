using Hospital.UI.Pages;

namespace Hospital.UI
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Routing.RegisterRoute(nameof(PatientDetailsPage), typeof(PatientDetailsPage));
            Routing.RegisterRoute(nameof(UpdateHospitalWardPage), typeof(UpdateHospitalWardPage));
            Routing.RegisterRoute(nameof(AddHospitalWardPage), typeof(AddHospitalWardPage));
            Routing.RegisterRoute(nameof(AddPatientByHospitalWardPage), typeof(AddPatientByHospitalWardPage));
            Routing.RegisterRoute(nameof(UpdatePatientPage), typeof(UpdatePatientPage));
        }
    }
}
