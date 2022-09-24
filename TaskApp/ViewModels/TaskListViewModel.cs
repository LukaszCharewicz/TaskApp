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

		public IEnumerable<TaskToDoViewModel> TasksToDo => _tasksToDo;
		public ICommand NavigateToCreateTaskView { get; }

		public ICommand ReloadTaskCommand { get; }

		public TaskListViewModel(TaskManager taskManager, NavigationService createTaskNavigationService)
		{
			_taskManager = taskManager;
			_tasksToDo = new ObservableCollection<TaskToDoViewModel>();
			ReloadTaskCommand = new ReloadTaskCommand(taskManager, this);
			NavigateToCreateTaskView = new NavigationCommand(createTaskNavigationService);
		}

		public static TaskListViewModel LoadViewModel(TaskManager taskManager, NavigationService createTaskNavigationService)
		{
			TaskListViewModel viewModel = new TaskListViewModel(taskManager, createTaskNavigationService);
			viewModel.ReloadTaskCommand.Execute(null);
			return viewModel;
		}


		public void UpdateTasks(IEnumerable<TaskToDo> tasks)
		{ 
			_tasksToDo.Clear();
			foreach (var task in tasks)
			{
				TaskToDoViewModel taskToDoViewModel = new TaskToDoViewModel(task);
				_tasksToDo.Add(taskToDoViewModel);
			}
		}

	}
}
