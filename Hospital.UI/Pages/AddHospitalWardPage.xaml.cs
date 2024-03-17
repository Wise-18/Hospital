using Hospital.UI.ViewModels;

namespace Hospital.UI.Pages;

public partial class AddHospitalWardPage : ContentPage
{
	public AddHospitalWardPage(IMediator mediator)
	{
		InitializeComponent();
		BindingContext = new AddHospitalWardViewModel(mediator);
	}
}