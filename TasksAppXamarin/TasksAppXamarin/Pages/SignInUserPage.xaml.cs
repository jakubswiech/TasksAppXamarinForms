using System;
using Acr.UserDialogs;
using TasksAppXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksAppXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInUserPage : ContentPage, IView<SignInUserViewModel>
    {
        private SignInUserViewModel _viewModel;
        public SignInUserPage(SignInUserViewModel viewModel)
        {
            SetViewModel(viewModel);
            InitializeComponent();
        }

        public void SetViewModel(SignInUserViewModel viewModel)
        {
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
        private async void RegisterButton_OnClicked(object sender, EventArgs e)
        {
            await _viewModel.GoToRegisterPage();
        }
    }
}