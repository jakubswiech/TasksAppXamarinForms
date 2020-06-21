using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using TasksAppXamarin.ApiModels;
using TasksAppXamarin.Configurations;
using TasksAppXamarin.Models;
using TasksAppXamarin.Repositories;

namespace TasksAppXamarin.Services
{
    public class TasksService : ITasksService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IApiConfiguration _apiConfiguration;

        public TasksService(IGenericRepository genericRepository, IApiConfiguration apiConfiguration)
        {
            _genericRepository = genericRepository ?? throw new ArgumentNullException(nameof(genericRepository));
            _apiConfiguration = apiConfiguration ?? throw new ArgumentNullException(nameof(apiConfiguration));
        }
        public async Task<IEnumerable<TaskModel>> GetUserTasksListAsync()
        {
            var request = new RestRequest(_apiConfiguration.GetTasksUri);

            var response = await _genericRepository.GetAsync<IEnumerable<TaskListResponseModel>>(request);
            if (response == null)
            {
                response = new List<TaskListResponseModel>();
            }
            return response.Select(x => new TaskModel(x.Id, x.Name, x.CreatedDate, x.IsActive));
        }

        public async Task<TaskDetailedModel> GetTaskAsync(Guid taskId)
        {
            var request = new RestRequest(_apiConfiguration.GetTaskUri);
            request.AddParameter(nameof(taskId), taskId, ParameterType.UrlSegment);

            var taskResponse = await _genericRepository.GetAsync<TaskResponseModel>(request);
            return new TaskDetailedModel(taskResponse.Id, taskResponse.Name, taskResponse.OwnerUserId,
                taskResponse.AssignedUserId, taskResponse.CreatedDate, taskResponse.Content, taskResponse.MinutesSpent,
                taskResponse.IsActive);
        }

        public async Task AddTask(CreateTaskRequestModel createTaskRequest)
        {
            var request = new RestRequest(_apiConfiguration.CreateTaskUri);
            request.AddJsonBody(createTaskRequest);

            await _genericRepository.PostAsync<object>(request);
        }

        public async Task ArchiveTask(Guid taskId)
        {
            var request = new RestRequest(_apiConfiguration.ArchiveTaskUri);
            request.AddJsonBody(new
            {
                TaskId = taskId
            });

            await _genericRepository.DeleteAsync<object>(request);
        }

        public async Task AssignUserToTaskAsync(Guid taskId, Guid userId)
        {
            var request = new RestRequest(_apiConfiguration.AssignUserToTaskUri);
            request.AddJsonBody(new
            {
                TaskId = taskId,
                UserId = userId
            });

            await _genericRepository.PostAsync<object>(request);
        }

        public async Task UpdateTaskAsync(Guid taskId, string name, string content)
        {
            var request = new RestRequest(_apiConfiguration.UpdateTaskUri);
            request.AddJsonBody(new
            {
                TaskId = taskId,
                Name = name,
                Content = content
            });

            await _genericRepository.PutAsync<object>(request);
        }

        public async Task LogTimeAsync(Guid taskId, int hours, int minutes)
        {
            var minutesSpent = hours * 60 + minutes;
            var request = new RestRequest(_apiConfiguration.LogTimeForTaskUri);
            request.AddJsonBody(new
            {
                TaskId = taskId,
                MinutesSpent = minutesSpent
            });

            await _genericRepository.PostAsync<object>(request);
        }
    }
}