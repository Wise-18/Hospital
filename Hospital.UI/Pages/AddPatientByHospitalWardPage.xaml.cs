using Hospital.UI.ViewModels;

namespace Hospital.UI.Pages;

public partial class AddPatientByHospitalWardPage : ContentPage
{
	public AddPatientByHospitalWardPage(IMediator mediator)
	{
		InitializeComponent();
		BindingContext = new AddPatientByHospitalWardViewModel(mediator);
	}
}