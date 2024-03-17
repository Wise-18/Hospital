using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hospital.Application.HospitalWardUseCases.Commands;
using Hospital.Domain.Entities;

namespace Hospital.UI.ViewModels
{
    public partial class AddHospitalWardViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public AddHospitalWardViewModel(IMediator mediator)
        {
            _mediator = mediator;
            hospitalWard = new HospitalWard(0, 0);
        }

        [ObservableProperty]
        HospitalWard hospitalWard;

        [ObservableProperty]
        string result;


        // Команда обновления списка пациентов в больничной палате
        [RelayCommand]
        async Task AddHospital() => await AddHospitalWard();

        private async Task AddHospitalWard()
        {

            if(!string.IsNullOrWhiteSpace(hospitalWard.RoomСapacity.ToString()) && !string.IsNullOrWhiteSpace(hospitalWard.RoomNumber.ToString()))
            {
                var hospitalWards = await _mediator.Send(new AddHospitalWardCommand(hospitalWard.RoomNumber,
                    hospitalWard.RoomСapacity));
                Result = "Успешно выполнено!";
            }
            

        }
    }
}
