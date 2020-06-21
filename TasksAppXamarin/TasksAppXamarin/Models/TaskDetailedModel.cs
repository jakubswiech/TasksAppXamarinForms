using System;
using TasksAppXamarin.Extensions;

namespace TasksAppXamarin.Models
{
    public class TaskDetailedModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid OwnerUserId { get; private set; }
        public Guid? AssignedUserId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Content { get; private set; }
        public int MinutesSpent { get; private set; }
        public string MinutesSpentFormatted => MinutesSpent.FormatMinutes();
        public bool IsActive { get; private set; }
        public User OwnerUser { get; set; }
        public User AssignedUser { get; set; }

        public TaskDetailedModel(Guid id, string name, Guid ownerUserId, Guid? assignedUserId, DateTime createdDate, string content, int minutesSpent, bool isActive)
        {
            Id = id;
            Name = name;
            OwnerUserId = ownerUserId;
            AssignedUserId = assignedUserId;
            CreatedDate = createdDate;
            Content = content;
            MinutesSpent = minutesSpent;
            IsActive = isActive;
        }

        private TaskDetailedModel()
        {
        }
    }
}