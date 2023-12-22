using FilmsTest.View;

namespace FilmsTest
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("FilmDetailsPage", typeof(FilmDetailsPage));
        }
    }
}
