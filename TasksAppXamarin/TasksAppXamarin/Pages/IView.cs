using TasksAppXamarin.ViewModels;

namespace TasksAppXamarin.Pages
{
    public interface IView<TViewModel> where TViewModel : IViewModel
    {
        void SetViewModel(TViewModel viewModel);
    }
}
