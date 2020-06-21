using System;
using System.Threading.Tasks;
using Autofac;
using TasksAppXamarin.Pages;
using TasksAppXamarin.ViewModels;
using Xamarin.Forms;

namespace TasksAppXamarin
{
    public class Navigator : INavigator
    {

        private readonly Lazy<INavigation> _navigation;
        private readonly IComponentContext _context;
        private INavigation Navigation => _navigation.Value;

        public Navigator(Lazy<INavigation> navigation, IComponentContext context)
        {
            _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task NavigateToAsync<TViewModel>(Action<TViewModel> action) where TViewModel : IViewModel
        {
            var page = _context.Resolve<IView<TViewModel>>();
            var viewModel = _context.Resolve<TViewModel>();
            action(viewModel);
            page.SetViewModel(viewModel);

            await NavigateToAsync(page as Page);
        }

        public async Task NavigateToAsync<TViewModel>() where TViewModel : IViewModel
            => await Navigation.PushAsync(GetPage<TViewModel>());

        public async Task NavigateToAsync(Page page)
        {
            await Navigation.PushAsync(page);
        }

        public Page GetPage<TViewModel>() where TViewModel : IViewModel
        {
            var page = _context.Resolve<IView<TViewModel>>();
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }
            var viewModel = _context.Resolve<TViewModel>();
            page.SetViewModel(viewModel);

            return page as Page;
        }

        public async Task GoBackAsync()
        {
            await Navigation.PopAsync();
        }
    }
}