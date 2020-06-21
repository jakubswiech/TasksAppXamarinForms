using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TasksAppXamarin.ApiModels;
using TasksAppXamarin.Models;
using TasksAppXamarin.Services;
using Xamarin.Forms;

namespace TasksAppXamarin.ViewModels
{
    public class SignInUserViewModel : BaseViewModel
    {
        private readonly IUsersService _usersService;
        private readonly INavigator _navigator;
        private readonly ICurrentUser _currentUser;

        private string _username = String.Empty;
        private string _password = String.Empty;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                SetProperty(ref _username, Username, nameof(Username));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                SetProperty(ref _password, _password, nameof(Password));
            }
        }

        public SignInUserViewModel(IUsersService usersService, INavigator navigator, ICurrentUser currentUser)
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            SignInCommand = new Command(async () => await SignInAsync());
        }

        public ICommand SignInCommand { get; set; }

        public async Task SignInAsync()
        {
            await _usersService.SignInUserAsync(new SignInRequest(Username, Password));
            if (_currentUser.IsAuthenticated)
            {
                await _navigator.NavigateToAsync<TasksListViewModel>();
            }
        }

        public async Task GoToRegisterPage()
        {
            await _navigator.NavigateToAsync<RegisterUserViewModel>();
        }
    }
}
