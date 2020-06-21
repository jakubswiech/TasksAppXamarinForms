using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TasksAppXamarin.Models;
using TasksAppXamarin.Services;
using Xamarin.Forms;

namespace TasksAppXamarin.ViewModels
{
    public class TaskDetailsViewModel : BaseViewModel
    {
        private readonly ITasksService _tasksService;
        private readonly IUsersService _usersService;
        private readonly INavigator _navigator;
        private TaskDetailedModel _selectedTask;

        public TaskDetailedModel SelectedTask
        {
            get => _selectedTask;
            private set
            {
                _selectedTask = value;
                SetProperty(ref _selectedTask, _selectedTask, nameof(SelectedTask));
            }
        }

        public TaskDetailsViewModel(ITasksService tasksService, IUsersService usersService, INavigator navigator)
        {
            _tasksService = tasksService ?? throw new ArgumentNullException(nameof(tasksService));
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            ArchiveTaskCommand = new Command(async () => await ArchiveTask());
            GoToAssignmentPageCommand = new Command(async () => await OnGoToAssignmentPageAsync());
            GoToUpdatePageCommand = new Command(async () => await OnGoToUpdatePageAsync());
            GoToLogTimePageCommand = new Command(async () => await OnGoToLogTimePageAsync());
        }

        public void SetTask(TaskDetailedModel task)
        {
            SelectedTask = task;
        }

        public ICommand ArchiveTaskCommand { get; set; }
        public ICommand GoToAssignmentPageCommand { get; set; }
        public ICommand GoToUpdatePageCommand { get; set; }
        public ICommand GoToLogTimePageCommand { get; set; }

        public async Task ArchiveTask()
        {
            await _tasksService.ArchiveTask(SelectedTask.Id);
            await _navigator.GoBackAsync();
        }

        public async Task OnGoToAssignmentPageAsync()
        {
            await _navigator.NavigateToAsync<TaskUserAssignmentViewModel>(x => x.SetTask(SelectedTask));
        }

        public async Task OnGoToUpdatePageAsync()
        {
            await _navigator.NavigateToAsync<TaskUpdateViewModel>(x => x.SetSelectedTaskData(SelectedTask));
        }

        private async Task OnGoToLogTimePageAsync()
        {
            await _navigator.NavigateToAsync<TaskLogTimeViewModel>(x => x.TaskId = SelectedTask.Id);
        }
    }
}
