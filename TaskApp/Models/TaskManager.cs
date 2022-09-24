using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Models
{
	internal class TaskManager
	{
		private readonly List<TaskToDo> _taskList;
		public TaskManager()
		{
			_taskList = new List<TaskToDo>();
		}

		public void CreateTask(TaskToDo taskToDo)
		{
			_taskList.Add(taskToDo);
		}

		public List<TaskToDo> GetTasks()
		{
			return _taskList;
		}
	}
}
