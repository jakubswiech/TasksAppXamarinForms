using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAppXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksAppXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskDetailsPage : ContentPage, IView<TaskDetailsViewModel>
    {
        private TaskDetailsViewModel _viewModel;
        public TaskDetailsPage(TaskDetailsViewModel viewModel)
        {
            SetViewModel(viewModel);
            InitializeComponent();
        }

        public void SetViewModel(TaskDetailsViewModel viewModel)
        {
            _viewModel = viewModel;
            BindingContext = viewModel;
        }
    }
}