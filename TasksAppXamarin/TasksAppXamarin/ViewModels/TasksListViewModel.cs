using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TasksAppXamarin.Models;
using TasksAppXamarin.Services;
using Xamarin.Forms;

namespace TasksAppXamarin.ViewModels
{
    public class TasksListViewModel : BaseViewModel
    {
        private readonly ITasksService _tasksService;
        private readonly IUsersService _usersService;
        private readonly INavigator _navigator;

        private List<TaskModel> _items = new List<TaskModel>();

        public List<TaskModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ICommand GoToTaskDetailsCommand { get; set; }

        public TasksListViewModel(ITasksService tasksService, IUsersService usersService, INavigator navigator)
        {
            _tasksService = tasksService ?? throw new ArgumentNullException(nameof(tasksService));
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            GoToTaskDetailsCommand = new Command<ItemTappedEventArgs>(async (e) => await GoToDetailsAsync(e));
        }

        private async Task GoToDetailsAsync(ItemTappedEventArgs e)
        {
            var task = await _tasksService.GetTaskAsync((e.Item as TaskModel).Id);
            task.AssignedUser = task.AssignedUserId.HasValue ? await _usersService.GetUserDetailsAsync(task.AssignedUserId.Value) : null;
            task.OwnerUser = await _usersService.GetUserDetailsAsync(task.OwnerUserId);
            await _navigator.NavigateToAsync<TaskDetailsViewModel>(x => x.SetTask(task));
        }

        public async Task GetTaskListAsync()
        {
            Items = (await _tasksService.GetUserTasksListAsync()).ToList();
        }

        public async Task GoToAddNewTask()
        {
            await _navigator.NavigateToAsync<CreateTaskViewModel>();
        }
    }
}
