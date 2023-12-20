using FilmsTest.ViewModel;

namespace FilmsTest.View
{
	public partial class DataFilmPage : ContentPage
	{
		public DataFilmPage()
		{
			InitializeComponent();
            BindingContext = new MainViewModel();
        }
	}
}