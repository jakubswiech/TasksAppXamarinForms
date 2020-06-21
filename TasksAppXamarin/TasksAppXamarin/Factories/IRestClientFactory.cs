using RestSharp;

namespace TasksAppXamarin.Factories
{
    public interface IRestClientFactory
    {
        IRestClient Create();
    }
}
