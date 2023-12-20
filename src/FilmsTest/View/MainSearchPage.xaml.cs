using FilmsTest.ViewModel;

namespace FilmsTest.View
{
    public partial class MainSearchPage : ContentPage
    {
        public MainSearchPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}