using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TasksAppXamarin.ApiModels;
using TasksAppXamarin.Models;

namespace TasksAppXamarin.Services
{
    public interface IUsersService : IService
    {
        Task SignInUserAsync(SignInRequest signInRequest);
        Task RegisterUserAsync(RegisterUserRequest registerUserRequest);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserDetailsAsync(Guid userId);
    }
}