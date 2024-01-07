using System.Runtime.CompilerServices;

namespace FilmsTest.Service
{
    public interface INavigationService
    {
        Task NavigateToPage(Page page);
    }

    public class NavigationService : INavigationService
    {
        [MethodImpl(MethodImplOptions.NoOptimization)]
        public async Task NavigateToPage(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);           
        }
    }
}