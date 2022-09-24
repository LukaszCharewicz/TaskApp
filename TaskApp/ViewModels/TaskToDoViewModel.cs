using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Enums;
using TaskApp.Models;

namespace TaskApp.ViewModels
{
	internal class TaskToDoViewModel : ViewModelBase
	{
		private readonly TaskToDo _task;


		public string Description => _task.Description;
		public string CreationTime => _task.CreationTime.ToString("g");
		public string Deadline => _task.Deadline.ToString("d");
		public TaskState State => _task.State;
		public bool IsImportant => _task.IsImportant;

		public TaskToDoViewModel(TaskToDo task)
		{
			_task = task;
		}

	}
}
