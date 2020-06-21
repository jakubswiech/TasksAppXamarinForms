using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TasksAppXamarin.ApiModels;
using TasksAppXamarin.Models;

namespace TasksAppXamarin.Services
{
    public interface ITasksService : IService
    {
        Task<IEnumerable<TaskModel>> GetUserTasksListAsync();
        Task<TaskDetailedModel> GetTaskAsync(Guid taskId);
        Task AddTask(CreateTaskRequestModel createTaskRequest);
        Task ArchiveTask(Guid taskId);
        Task AssignUserToTaskAsync(Guid taskId, Guid userId);
        Task UpdateTaskAsync(Guid taskId, string name, string content);
        Task LogTimeAsync(Guid taskId, int hours, int minutes);
    }
}