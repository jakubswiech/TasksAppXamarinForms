using System;
using System.Threading.Tasks;
using TasksAppXamarin.ViewModels;
using Xamarin.Forms;

namespace TasksAppXamarin
{
    public interface INavigator
    {
        Task NavigateToAsync<TViewModel>() where TViewModel : IViewModel;
        Task NavigateToAsync<TViewModel>(Action<TViewModel> action) where TViewModel : IViewModel;
        Task NavigateToAsync(Page page);
        Page GetPage<TViewModel>() where TViewModel : IViewModel;
        Task GoBackAsync();
    }
}
