using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TasksAppXamarin.Models;
using TasksAppXamarin.Services;
using Xamarin.Forms;

namespace TasksAppXamarin.ViewModels
{
    public class TaskUserAssignmentViewModel : BaseViewModel
    {
        private readonly ITasksService _tasksService;
        private readonly IUsersService _usersService;
        private readonly INavigator _navigator;
        private List<User> _users;
        private User _selectedUser;
        public TaskDetailedModel SelectedTask { get; set; }

        public User SelectedUser
        {
            get => _selectedUser;
            set => SetProperty(ref _selectedUser, value, nameof(SelectedUser));
        }

        public List<User> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        public ICommand AssignUserToTaskCommand { get; set; }

        public TaskUserAssignmentViewModel(ITasksService tasksService, IUsersService usersService, INavigator navigator)
        {
            _tasksService = tasksService ?? throw new ArgumentNullException(nameof(tasksService));
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            AssignUserToTaskCommand = new Command(async () => await AssignUserToTaskAsync());
        }

        public async Task GetUsersAsync()
        {
            var users = await _usersService.GetUsersAsync();
            Users = users.ToList();
            SelectedUser = Users.SingleOrDefault(x => x.Id == SelectedTask.AssignedUserId);
        }

        public void SetTask(TaskDetailedModel task)
        {
            SelectedTask = task;
        }

        private async Task AssignUserToTaskAsync()
        {
            await _tasksService.AssignUserToTaskAsync(SelectedTask.Id, SelectedUser.Id);
            await _navigator.GoBackAsync();
            await _navigator.GoBackAsync();
        }
    }
}
