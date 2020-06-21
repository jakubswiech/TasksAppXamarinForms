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
    public partial class RegisterPage : ContentPage, IView<RegisterUserViewModel>
    {
        private RegisterUserViewModel _viewModel;
        public RegisterPage(RegisterUserViewModel viewModel)
        {
            SetViewModel(viewModel);
            InitializeComponent();
        }

        public void SetViewModel(RegisterUserViewModel viewModel)
        {
            _viewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        private async void SignUpButton_OnClicked(object sender, EventArgs e)
        {
            await _viewModel.RegisterUserAsync(UserNameEntry.Text, EmailEntry.Text, PasswordEntry.Text);
        }
    }
}