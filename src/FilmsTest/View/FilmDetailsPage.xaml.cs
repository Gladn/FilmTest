using FilmsTest.ViewModel;

namespace FilmsTest.View;

public partial class FilmDetailsPage : ContentPage
{
	public FilmDetailsPage()
	{
		InitializeComponent();
		BindingContext = new FilmDetailsViewModel();
    }    
}