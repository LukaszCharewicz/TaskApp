using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Models
{
	internal class TaskManager
	{
		private readonly TaskList _taskList;
		public TaskManager(TaskList taskList)
		{
			_taskList = taskList;
		}

		public async Task CreateTask(TaskToDo taskToDo)
		{
			await _taskList.AddTask(taskToDo);
		}

		public async Task<IEnumerable<TaskToDo>> GetAllTasks()
		{
			return await _taskList.GetAllTasks();
		}
	}
}
