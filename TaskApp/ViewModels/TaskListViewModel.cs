using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskApp.Commands;
using TaskApp.Models;
using TaskApp.Services;
using TaskApp.Stores;

namespace TaskApp.ViewModels
{
	internal class TaskListViewModel : ViewModelBase
	{
		private readonly ObservableCollection<TaskToDoViewModel> _tasksToDo;
		private readonly TaskManager _taskManager;

		public IEnumerable<TaskToDoViewModel> TasksToDo => _tasksToDo;
		public ICommand NavigateToCreateTaskView { get; }

		public TaskListViewModel(TaskManager taskManager,NavigationService createTaskNavigationService)
		{
			_taskManager = taskManager;
			_tasksToDo = new ObservableCollection<TaskToDoViewModel>();

			NavigateToCreateTaskView = new NavigationCommand(createTaskNavigationService);
			UpdateTasks();

		
		}

		private void UpdateTasks()
		{ 
			_tasksToDo.Clear();
			foreach (var task in _taskManager.GetTasks())
			{
				TaskToDoViewModel taskToDoViewModel = new TaskToDoViewModel(task);
				_tasksToDo.Add(taskToDoViewModel);
			}
		}

	}
}
