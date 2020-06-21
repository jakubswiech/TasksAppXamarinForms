using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using TasksAppXamarin.Aop;
using TasksAppXamarin.ApiModels;
using TasksAppXamarin.Exceptions;
using TasksAppXamarin.Factories;

namespace TasksAppXamarin.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        #region Private fields
        private readonly IRestClientFactory _restClientFactory;

        #endregion

        #region Constructor
        public GenericRepository(IRestClientFactory restClientFactory)
        {
            _restClientFactory = restClientFactory;
        }
        #endregion

        #region Public methods
        public async Task<T> GetAsync<T>(IRestRequest restRequest)
        {
            return await CallAsync(async (client) => await client.ExecuteGetAsync<T>(restRequest));
        }

        public async Task<T> PostAsync<T>(IRestRequest restRequest)
        {
            return await CallAsync(async (client) => await client.ExecutePostAsync<T>(restRequest));
        }

        public async Task<T> PutAsync<T>(IRestRequest restRequest)
        {
            return await CallAsync(async (client) => await client.ExecuteAsync<T>(restRequest, Method.PUT));
        }

        public async Task<T> DeleteAsync<T>(IRestRequest restRequest)
        {
            return await CallAsync(async (client) => await client.ExecuteAsync<T>(restRequest, Method.DELETE));
        }
        #endregion

        #region Private methods
        [Loading, HandleException]
        private async Task<T> CallAsync<T>(Func<IRestClient, Task<IRestResponse<T>>> callFunction)
        {
            var client = _restClientFactory.Create();
            var responseMessage = await callFunction(client);

            if (responseMessage.IsSuccessful)
            {
                return responseMessage.Data;
            }

            if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                return await ServiceAuthenticationError(responseMessage);
            }

            return await HttpRequestError(responseMessage);
        }

        private Task<T> ServiceAuthenticationError<T>(IRestResponse<T> response)
        {
            throw new ServiceAuthenticationException(response.ErrorMessage ?? response.StatusDescription);
        }

        private Task<T> HttpRequestError<T>(IRestResponse<T> response)
        {
            var errorMessage = DeserializeError(response);

            throw !string.IsNullOrWhiteSpace(errorMessage) ?
                new HttpRequestException(errorMessage) :
                new HttpRequestException(string.Empty);
        }

        private string DeserializeError<T>(IRestResponse<T> response)
        {
            try
            {
                var error = JsonConvert.DeserializeObject<ErrorViewModel>(response.Content);
                return error.ErrorMessage;

            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion
    }
}