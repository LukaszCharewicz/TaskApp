using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskApp.Models;
using TaskApp.ViewModels;

namespace TaskApp.Commands
{
	internal class ReloadTaskCommand : AsyncCommandBase
	{
		private readonly TaskManager _taskManager;
		private readonly TaskListViewModel _taskListViewModel;

		public ReloadTaskCommand()
		{
		}

		public ReloadTaskCommand(TaskManager taskManager, TaskListViewModel taskListViewModel)
		{
			_taskManager = taskManager;
			_taskListViewModel = taskListViewModel;
		}

		public override async Task ExecuteAsync(object parameter)
		{
			try
			{
				IEnumerable<TaskToDo> tasks = await _taskManager.GetAllTasks();
				_taskListViewModel.UpdateTasks
			}
			catch (Exception)
			{
				MessageBox.Show("Cannot load tasks.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
