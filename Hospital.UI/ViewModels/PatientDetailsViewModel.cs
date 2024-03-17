using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hospital.Application.PatientUseCases.Commands;
using Hospital.UI.Pages;

namespace Hospital.UI.ViewModels
{
    [QueryProperty("Patient", "Patient")]
    public partial class PatientDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Patient patient;

        [ObservableProperty]
        string result;


        private readonly IMediator _mediator;

        public PatientDetailsViewModel(IMediator mediator) => _mediator = mediator;

        // Команда обновления списка пациентов в больничной палате
        [RelayCommand]
        async Task RemovePatient() => await RemovePatientq();

        public async Task RemovePatientq()
        {
            if (Result == "Удалено!") return;

            var hospitalWards = await _mediator.Send(new RemovePatientCommand(patient));
            Result = "Удалено!";
        }

        [RelayCommand]
        async void UpdatePatient() => await GotoUpdatePatient();

        private async Task GotoUpdatePatient()
        {
            if (Result == "Удалено!") return;

            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Patient", patient }
            };

            await Shell.Current.GoToAsync(nameof(UpdatePatientPage), parameters);
        }
    }
}
