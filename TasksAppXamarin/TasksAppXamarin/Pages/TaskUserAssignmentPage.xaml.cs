using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAppXamarin.Models;
using TasksAppXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksAppXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskUserAssignmentPage : ContentPage, IView<TaskUserAssignmentViewModel>
    {
        private TaskUserAssignmentViewModel _viewModel;
        public TaskUserAssignmentPage(TaskUserAssignmentViewModel viewModel)
        {
            SetViewModel(viewModel);
            InitializeComponent();
        }

        public void SetViewModel(TaskUserAssignmentViewModel viewModel)
        {
            _viewModel = viewModel;
            BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            await _viewModel.GetUsersAsync();
        }

        private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.SelectedUser = (sender as Picker).SelectedItem as User;
            AssignButton.IsEnabled = true;
        }
    }
}