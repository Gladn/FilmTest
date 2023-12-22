using FilmsTest.ViewModel;

namespace FilmsTest
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainSearchViewModel();
        }
    }
}
