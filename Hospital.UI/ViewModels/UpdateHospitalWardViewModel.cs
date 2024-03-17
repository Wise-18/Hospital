using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hospital.Application.HospitalWardUseCases.Commands;

namespace Hospital.UI.ViewModels
{
    [QueryProperty("HospitalWard", "HospitalWard")]
    public partial class UpdateHospitalWardViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        [ObservableProperty]
        HospitalWard hospitalWard;

        [ObservableProperty]
        string result;

        public UpdateHospitalWardViewModel(IMediator mediator) => _mediator = mediator;

        // Команда обновления списка пациентов в больничной палате
        [RelayCommand]
        async Task UpdateHospital() => await UpdateHospitalWard();

        private async Task UpdateHospitalWard()
        {
            var hospitalWards = await _mediator.Send(new UpdateHospitalWardCommand(hospitalWard));
            Result = "Успешно выполнено!";

        }
    }
}
