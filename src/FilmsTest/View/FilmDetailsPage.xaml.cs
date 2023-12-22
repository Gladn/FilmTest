using FilmsTest.ViewModel;

namespace FilmsTest.View;

public partial class FilmDetailsPage : ContentPage
{
	public FilmDetailsPage(FilmDetailsViewModel viewModel)
    {
		InitializeComponent();
		BindingContext = viewModel;
    }    
}