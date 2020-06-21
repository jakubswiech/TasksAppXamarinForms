using TasksAppXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksAppXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogTimeForTaskPage : ContentPage, IView<TaskLogTimeViewModel>
    {
        private TaskLogTimeViewModel _viewModel;
        public LogTimeForTaskPage(TaskLogTimeViewModel viewModel)
        {
            SetViewModel(viewModel);
            InitializeComponent();
        }

        public void SetViewModel(TaskLogTimeViewModel viewModel)
        {
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
    }
}