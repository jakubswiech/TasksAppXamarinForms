using System;
using System.Collections.Generic;
using System.Text;
using TasksAppXamarin.ViewModels;

namespace TasksAppXamarin.Models
{
    public class User : BaseViewModel
    {
        private Guid _id;
        private string _userName;
        private string _email;

        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                SetProperty(ref _id, _id, nameof(Id));
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                SetProperty(ref _userName, _userName, nameof(UserName));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                SetProperty(ref _email, _email, nameof(Email));
            }
        }
    }
}
