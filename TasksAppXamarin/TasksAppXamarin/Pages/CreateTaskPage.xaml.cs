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
    public partial class CreateTaskPage : ContentPage, IView<CreateTaskViewModel>
    {
        private CreateTaskViewModel _viewModel;
        public CreateTaskPage(CreateTaskViewModel viewModel)
        {
            SetViewModel(viewModel);
            InitializeComponent();
        }

        public void SetViewModel(CreateTaskViewModel viewModel)
        {
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
    }
}