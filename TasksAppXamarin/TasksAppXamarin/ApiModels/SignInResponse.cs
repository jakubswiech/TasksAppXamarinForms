using System;

namespace TasksAppXamarin.ApiModels
{
    public class SignInResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
        public string JwtToken { get; set; }
    }
}