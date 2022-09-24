using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Enums;

namespace TaskApp.Models
{
	internal class TaskToDo
	{
		public string Description { get; }
		public DateTime CreationTime { get; }
		public DateTime Deadline { get; }
		public bool IsImportant { get; }

		public TaskToDo(string description, DateTime creationTime, DateTime deadline, TaskState state, bool isImportant)
		{
			Description = description;
			Deadline = deadline;
			IsImportant = isImportant;
			CreationTime = DateTime.Now;
		}
	}
}
