namespace TasksAppXamarin.Configurations
{
    public class ApiConfiguration : IApiConfiguration
    {
        public string BaseUri { get; set; }
        public string SignInUri { get; set; }
        public string RegisterUserUri { get; set; }
        public string GetUsersUri { get; set; }
        public string GetUserUri { get; set; }
        public string CreateTaskUri { get; set; }
        public string GetTasksUri { get; set; }
        public string GetTaskUri { get; set; }
        public string ArchiveTaskUri { get; set; }
        public string AssignUserToTaskUri { get; set; }
        public string UpdateTaskUri { get; set;  }
        public string LogTimeForTaskUri { get; set; }
    }
}