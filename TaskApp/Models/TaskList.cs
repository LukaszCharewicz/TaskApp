using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Services.TaskCreators;
using TaskApp.Services.TaskProviders;

namespace TaskApp.Models
{
	internal class TaskList
	{
		private readonly ITaskProvider _taskProvider;
		private readonly ITaskCreator _taskCreator;


		public TaskList(ITaskProvider taskProvider, ITaskCreator taskCreator)
		{
			_taskProvider = taskProvider;
			_taskCreator = taskCreator;
		}

		public async Task<IEnumerable<TaskToDo>> GetAllTasks()
		{
			return await _taskProvider.GetAllTask();
		}

		public async 
		Task
AddTask(TaskToDo task)
		{
			await _taskCreator.CreateTask(task);
		}

	}
}
