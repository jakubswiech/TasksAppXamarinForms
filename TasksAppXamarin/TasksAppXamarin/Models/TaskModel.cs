using System;
using System.Collections.Generic;
using System.Text;

namespace TasksAppXamarin.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public TaskModel(Guid id, string name, DateTime createdDate, bool isActive)
        {
            Id = id;
            Name = name;
            CreatedDate = createdDate;
            IsActive = isActive;
        }

        private TaskModel() { }
    }
}
