using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hospital.Application.PatientUseCases.Commands;

namespace Hospital.UI.ViewModels
{
    [QueryProperty("HospitalWard", "HospitalWard")]
    public partial class AddPatientByHospitalWardViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public AddPatientByHospitalWardViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        HospitalWard hospitalWard;

        [ObservableProperty]
        string fullName;

        [ObservableProperty]
        DateTime dateOfBirth;

        [ObservableProperty]
        double temperature;

        [ObservableProperty]
        string result;


        // Команда обновления списка пациентов в больничной палате
        [RelayCommand]
        async Task AddPatient() => await AddPatientQ();
        private async Task AddPatientQ()
        {

            if (!string.IsNullOrWhiteSpace(fullName) && !string.IsNullOrWhiteSpace(temperature.ToString()))
            {
                var hospitalWards = await _mediator.Send(new AddPatientCommand(fullName,
                    dateOfBirth, temperature, hospitalWard.Id));
                Result = "Успешно выполнено!)";
            }


        }
    }
}
