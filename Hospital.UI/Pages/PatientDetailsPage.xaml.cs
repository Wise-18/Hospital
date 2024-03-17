using Hospital.UI.ViewModels;

namespace Hospital.UI.Pages;

public partial class PatientDetailsPage : ContentPage
{
	public PatientDetailsPage(IMediator mediator)
	{
		InitializeComponent();
		BindingContext = new PatientDetailsViewModel(mediator);

    }
}