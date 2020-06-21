using System;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.NewtonsoftJson;
using TasksAppXamarin.Configurations;
using TasksAppXamarin.Models;

namespace TasksAppXamarin.Factories
{
    public class RestClientFactory : IRestClientFactory
    {
        private readonly IApiConfiguration _apiConfiguration;
        private readonly ICurrentUser _currentUser;

        public RestClientFactory(IApiConfiguration apiConfiguration, ICurrentUser currentUser)
        {
            _apiConfiguration = apiConfiguration ?? throw new ArgumentNullException(nameof(apiConfiguration));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
        }

        public IRestClient Create()
        {
            var client = new RestClient(_apiConfiguration.BaseUri)
            {
                Authenticator = _currentUser.IsAuthenticated ? new JwtAuthenticator(_currentUser.JwtToken) : null,
                ThrowOnAnyError = false,
                FailOnDeserializationError = true
            };
            client.UseNewtonsoftJson();

            return client;
        }
    }
}