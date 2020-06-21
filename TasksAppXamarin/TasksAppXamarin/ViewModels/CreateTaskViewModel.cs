using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TasksAppXamarin.ApiModels;
using TasksAppXamarin.Services;
using Xamarin.Forms;

namespace TasksAppXamarin.ViewModels
{
    public class CreateTaskViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;
        private readonly ITasksService _tasksService;
        private string _name;
        private string _content;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                SetProperty(ref _name, _name, nameof(Name));
            }
        }

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                SetProperty(ref _content, _content, nameof(Content));
            }
        }

        public CreateTaskViewModel(INavigator navigator, ITasksService tasksService)
        {
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            _tasksService = tasksService ?? throw new ArgumentNullException(nameof(tasksService));
            AddTaskCommand = new Command(async () => await AddTaskAsync());
        }

        public ICommand AddTaskCommand { get; set; }

        public async Task AddTaskAsync()
        {
            await _tasksService.AddTask(new CreateTaskRequestModel(Name, Content));
            await _navigator.GoBackAsync();
        }
    }
}
