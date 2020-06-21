using System.Threading.Tasks;
using RestSharp;

namespace TasksAppXamarin.Repositories
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(IRestRequest restRequest);
        Task<T> PostAsync<T>(IRestRequest restRequest);
        Task<T> PutAsync<T>(IRestRequest restRequest);
        Task<T> DeleteAsync<T>(IRestRequest restRequest);
    }
}
