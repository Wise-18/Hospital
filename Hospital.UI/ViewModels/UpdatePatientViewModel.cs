using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hospital.Application.HospitalWardUseCases.Commands;
using Hospital.Application.PatientUseCases.Commands;
using Hospital.Domain.Entities;

namespace Hospital.UI.ViewModels
{
    [QueryProperty("Patient", "Patient")]
    public partial class UpdatePatientViewModel : ObservableObject
    {
        
        [ObservableProperty]
        Patient patient;

        [ObservableProperty]
        string result;

        private readonly IMediator _mediator;

        public UpdatePatientViewModel(IMediator mediator) => _mediator = mediator;

        // Команда обновления списка пациентов в больничной палате
        [RelayCommand]
        async Task UpdatePatient() => await UpdatePatientq();

        private async Task UpdatePatientq()
        {
            var hospitalWards = await _mediator.Send(new UpdatePatientCommand(patient));
            Result = "Успешно выполнено!";

        }
    }
}
