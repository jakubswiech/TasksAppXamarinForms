using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TasksAppXamarin.Services;
using Xamarin.Forms;

namespace TasksAppXamarin.ViewModels
{
    public class TaskLogTimeViewModel : BaseViewModel
    {
        private readonly ITasksService _tasksService;
        private readonly INavigator _navigator;
        private int _hours;
        private int _minutes;
        public Guid TaskId { get; set; }

        public int Hours
        {
            get => _hours;
            set => SetProperty(ref _hours, value, nameof(Hours));
        }

        public int Minutes
        {
            get => _minutes;
            set => SetProperty(ref _minutes, value, nameof(Minutes));
        }

        public TaskLogTimeViewModel(ITasksService tasksService, INavigator navigator)
        {
            _tasksService = tasksService ?? throw new ArgumentNullException(nameof(tasksService));
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            LogTimeCommand = new Command(async () => await LogTimeAsync());
        }

        private async Task LogTimeAsync()
        {
            await _tasksService.LogTimeAsync(TaskId, Hours, Minutes);
            await _navigator.GoBackAsync();
            await _navigator.GoBackAsync();
        }

        public ICommand LogTimeCommand { get; set; }
    }
}
