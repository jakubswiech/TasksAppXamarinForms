using System.Collections.Generic;
using System.Text;

namespace TasksAppXamarin.ApiModels
{
    public struct SignInRequest
    {
        public string UserName { get; }
        public string Password { get; }

        public SignInRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
