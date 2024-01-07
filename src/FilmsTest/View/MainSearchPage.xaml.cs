using FilmsTest.ViewModel;

namespace FilmsTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainSearchViewModel viewmodel)
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }
    }
}
