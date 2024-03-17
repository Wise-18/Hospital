using Hospital.UI.ViewModels;

namespace Hospital.UI.Pages;

public partial class UpdatePatientPage : ContentPage
{
	public UpdatePatientPage(IMediator mediator)
	{
		InitializeComponent();
		BindingContext = new UpdatePatientViewModel(mediator);
	}
}