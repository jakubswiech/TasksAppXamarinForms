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
    public partial class TaskListPage : ContentPage, IView<TasksListViewModel>
    {
        private TasksListViewModel _viewModel;
        public TaskListPage(TasksListViewModel viewModel)
        {
            SetViewModel(viewModel);
            Appearing += OnAppearing;
            InitializeComponent();
        }

        private async void OnAppearing(object sender, EventArgs e)
        {
            await _viewModel.GetTaskListAsync();
            BindingContext = _viewModel;
        }

        public void SetViewModel(TasksListViewModel viewModel)
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }


        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            _viewModel.GoToTaskDetailsCommand.Execute(e);
        }

        private async void AddTaskButton_OnClicked(object sender, EventArgs e)
        {
            await _viewModel.GoToAddNewTask();
        }
    }
}