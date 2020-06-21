using RestSharp;

namespace TasksAppXamarin.Configurations
{
    public interface IApiConfiguration
    {
        string BaseUri { get; }
        string SignInUri { get; }
        string RegisterUserUri { get; }
        string GetUsersUri { get; }
        string GetUserUri { get; }
        string CreateTaskUri { get; }
        string GetTasksUri { get; }
        string GetTaskUri { get; }
        string ArchiveTaskUri { get; }  
        string AssignUserToTaskUri { get;  }
        string UpdateTaskUri { get; }
        string LogTimeForTaskUri { get; }
    }
}
