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
    public partial class UpdateTaskPage : ContentPage, IView<TaskUpdateViewModel>
    {
        private TaskUpdateViewModel _viewModel;
        public UpdateTaskPage(TaskUpdateViewModel viewModel)
        {
            SetViewModel(viewModel);
            InitializeComponent();
        }

        public void SetViewModel(TaskUpdateViewModel viewModel)
        {
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
    }
}