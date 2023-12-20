using FilmsTest.View;

namespace FilmsTest
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainSearchPage", typeof(MainSearchPage));
            //Routing.RegisterRoute("DataFilmPage", typeof(DataFilmPage));
        }
    }
}
