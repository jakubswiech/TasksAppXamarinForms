using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TasksAppXamarin.ApiModels;
using TasksAppXamarin.Pages;
using TasksAppXamarin.Services;
using Xamarin.Forms;

namespace TasksAppXamarin.ViewModels
{
    public class RegisterUserViewModel : IViewModel
    {
        private readonly IUsersService _service;
        private readonly INavigator _navigator;

        public RegisterUserViewModel(IUsersService service, INavigator navigator)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
        }

        public async Task RegisterUserAsync(string userName, string email, string password)
        {
            await _service.RegisterUserAsync(new RegisterUserRequest(userName, password, email));
            await _navigator.NavigateToAsync<SignInUserViewModel>();
        }
    }
}
