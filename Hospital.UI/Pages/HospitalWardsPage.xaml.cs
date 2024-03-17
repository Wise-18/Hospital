using Hospital.UI.ViewModels;

namespace Hospital.UI.Pages;

public partial class HospitalWardsPage : ContentPage
{
	public HospitalWardsPage(IMediator mediator)
	{
		InitializeComponent();

		HospitalWardsViewModel hospitalWardsViewModel = new HospitalWardsViewModel(mediator);

		BindingContext = hospitalWardsViewModel;
    }
}