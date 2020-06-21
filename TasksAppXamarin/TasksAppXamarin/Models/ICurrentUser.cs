using System;

namespace TasksAppXamarin.Models
{
    public interface ICurrentUser
    {
        Guid? Id { get; }
        string UserName { get; }
        string Email { get; }
        string JwtToken { get; }
        bool IsAuthenticated { get; }
        void SignOut();
        void SignIn(Guid id, string userName, string email, string jwtToken);
    }
}
