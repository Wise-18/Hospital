using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hospital.Application.HospitalWardUseCases.Queries;
using Hospital.Application.PatientUseCases.Queries;
using Hospital.Domain.Entities;
using Hospital.UI.Pages;
using System.Collections.ObjectModel;

namespace Hospital.UI.ViewModels
{

    public partial class HospitalWardsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public ObservableCollection<HospitalWard> HospitalWards { get; set; } = new();
        public ObservableCollection<Patient> Patients { get; set; } = new();

        // Выбранный в списке больничная палата
        [ObservableProperty]
        HospitalWard selectedHostipalWard;

        [ObservableProperty]
        Patient selectedPatient;

        public HospitalWardsViewModel(IMediator mediator) => _mediator = mediator;


        // Команда обновления списка больничных палат
        [RelayCommand]
        async Task UpdateGroupList() => await GetHospitalWards();

        // Команда обновления списка пациентов в больничной палате
        [RelayCommand]
        async Task UpdateMembersList() => await GetPatients();

        public async Task GetHospitalWards()
        {
            var hospitalWards = await _mediator.Send(new GetAllHospitalWardsRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                HospitalWards.Clear();
                foreach (var hospitalWard in hospitalWards)
                    HospitalWards.Add(hospitalWard);
            });
        }

        public async Task GetPatients()
        {
            if (selectedHostipalWard is null) return;

            var patients = await _mediator.Send(new GetPatientsByHospitalWardRequest(selectedHostipalWard.Id));
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Patients.Clear();
                foreach (var patient in patients)
                    Patients.Add(patient);
            });
        }

        [RelayCommand]
        async void ShowDetails(Patient patient) => await GotoDetailsPage(patient);
        
        private async Task GotoDetailsPage(Patient patient)
        {
            IDictionary<string, object> parameters =new Dictionary<string, object>()
            {
                { "Patient", patient }
            };

            await Shell.Current.GoToAsync(nameof(PatientDetailsPage), parameters);

        }

        [RelayCommand]
        async void AddPatinetByHospitalWard() => await GotoAddPatinetByHospitalWardPage();

        private async Task GotoAddPatinetByHospitalWardPage()
        {
            if (selectedHostipalWard == null) return;

            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "HospitalWard", selectedHostipalWard }
            };

            await Shell.Current.GoToAsync(nameof(AddPatientByHospitalWardPage), parameters);

        }

        [RelayCommand]
        async void UpdateHospitalWard() => await GotoUpdateHospitalWard();

        private async Task GotoUpdateHospitalWard()
        {
            if (selectedHostipalWard == null) return;

            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "HospitalWard", SelectedHostipalWard }
            };

            await Shell.Current.GoToAsync(nameof(UpdateHospitalWardPage), parameters);
        }

        [RelayCommand]
        async void AddHospitalWard() => await GotoAddHospitalWard();

        private async Task GotoAddHospitalWard()
        {
            await Shell.Current.GoToAsync(nameof(AddHospitalWardPage));
        }
    }
}
