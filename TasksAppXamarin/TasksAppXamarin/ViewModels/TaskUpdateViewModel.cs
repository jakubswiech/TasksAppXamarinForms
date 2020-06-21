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
    public class TaskUpdateViewModel : BaseViewModel
    {
        private readonly ITasksService _tasksService;
        private readonly INavigator _navigator;
        private string _content;
        private string _name;

        public Guid TaskId { get; set; }
        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value, nameof(Content));
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, nameof(Name));
        }

        public ICommand UpdateTaskCommand { get; set; }

        public TaskUpdateViewModel(ITasksService tasksService, INavigator navigator)
        {
            _tasksService = tasksService ?? throw new ArgumentNullException(nameof(tasksService));
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            UpdateTaskCommand = new Command(async () => await UpdateTaskAsync());
        }

        public void SetSelectedTaskData(TaskDetailedModel task)
        {
            Name = task.Name;
            Content = task.Content;
            TaskId = task.Id;
        }

        private async Task UpdateTaskAsync()
        {
            await _tasksService.UpdateTaskAsync(TaskId, Name, Content);
            await _navigator.GoBackAsync();
            await _navigator.GoBackAsync();
        }
    }
}
