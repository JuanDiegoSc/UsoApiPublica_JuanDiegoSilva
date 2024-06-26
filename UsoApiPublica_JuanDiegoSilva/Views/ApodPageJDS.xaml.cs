using UsoApiPublica_JuanDiegoSilva.ViewModels;

namespace UsoApiPublica_JuanDiegoSilva.Views;

public partial class ApodPageJDS : ContentPage
{
	public ApodPageJDS()
	{
		InitializeComponent();
        BindingContext = new ApodViewModelJDS();

    }
}