using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using TasksAppXamarin.Aop;
using TasksAppXamarin.ApiModels;
using TasksAppXamarin.Configurations;
using TasksAppXamarin.Models;
using TasksAppXamarin.Repositories;

namespace TasksAppXamarin.Services
{
    public class UsersService : IUsersService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IApiConfiguration _apiConfiguration;

        public UsersService(IGenericRepository genericRepository, ICurrentUser currentUser, IApiConfiguration apiConfiguration)
        {
            _genericRepository = genericRepository ?? throw new ArgumentNullException(nameof(genericRepository));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _apiConfiguration = apiConfiguration ?? throw new ArgumentNullException(nameof(apiConfiguration));
        }
        [HandleException]
        public async Task SignInUserAsync(SignInRequest signInRequest)
        {
            var request = new RestRequest(_apiConfiguration.SignInUri, DataFormat.Json);
            request.AddJsonBody(signInRequest);

            var result = await _genericRepository.PostAsync<SignInResponse>(request);
            if (result != null)
            {
                _currentUser.SignIn(result.Id, result.UserName, result.Email, result.JwtToken);
            }
        }

        public async Task RegisterUserAsync(RegisterUserRequest registerUserRequest)
        {
            var request = new RestRequest(_apiConfiguration.RegisterUserUri);
            request.AddJsonBody(registerUserRequest);

            await _genericRepository.PostAsync<string>(request);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var request = new RestRequest(_apiConfiguration.GetUsersUri);

            return await _genericRepository.GetAsync<IEnumerable<User>>(request);
        }

        public async Task<User> GetUserDetailsAsync(Guid userId)
        {
            var request = new RestRequest(_apiConfiguration.GetUserUri);
            request.AddParameter(nameof(userId), userId, ParameterType.UrlSegment);

            return await _genericRepository.GetAsync<User>(request);
        }
    }
}
