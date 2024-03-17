using Hospital.UI.ViewModels;

namespace Hospital.UI.Pages;

public partial class UpdateHospitalWardPage : ContentPage
{
	public UpdateHospitalWardPage(IMediator mediator)
	{
		InitializeComponent();
		BindingContext = new UpdateHospitalWardViewModel(mediator);
	}
}