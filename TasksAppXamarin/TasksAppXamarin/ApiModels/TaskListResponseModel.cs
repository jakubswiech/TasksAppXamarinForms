using System;

namespace TasksAppXamarin.ApiModels
{
    public class TaskListResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerUserId { get; set; }
        public Guid? AssignedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
	}
}
