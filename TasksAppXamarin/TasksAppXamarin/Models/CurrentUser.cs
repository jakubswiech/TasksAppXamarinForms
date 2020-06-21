using System;

namespace TasksAppXamarin.Models
{
    public class CurrentUser : ICurrentUser
    {
        public Guid? Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string JwtToken { get; private set; }
        public bool IsAuthenticated => !string.IsNullOrWhiteSpace(JwtToken) && Id.HasValue;

        public CurrentUser()
        {
            SetEmptyCurrentUser();
        }

        public void SignOut()
        {
            SetEmptyCurrentUser();
        }

        public void SignIn(Guid id, string userName, string email, string jwtToken)
        {
            Id = id;
            UserName = userName;
            Email = Email;
            JwtToken = jwtToken;
        }

        private void SetEmptyCurrentUser()
        {
            Id = null;
            UserName = string.Empty;
            Email = string.Empty;
            JwtToken = string.Empty;
        }
    }
}