using System;

namespace TasksAppXamarin.ApiModels
{
    public class TaskResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerUserId { get; set; }
        public Guid? AssignedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int MinutesSpent { get; set; }
        public bool IsActive { get; set; }
    }
}