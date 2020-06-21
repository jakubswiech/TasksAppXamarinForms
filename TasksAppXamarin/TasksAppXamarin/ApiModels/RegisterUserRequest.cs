namespace TasksAppXamarin.ApiModels
{
    public class RegisterUserRequest
    {
        public string UserName { get; }
        public string Password { get; }
        public string Email { get;  }

        public RegisterUserRequest(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}