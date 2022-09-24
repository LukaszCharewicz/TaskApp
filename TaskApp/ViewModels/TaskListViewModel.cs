using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskApp.Commands;
using TaskApp.Services;
using TaskApp.Stores;

namespace TaskApp.ViewModels
{
	internal class TaskListViewModel : ViewModelBase
	{
		private readonly ObservableCollection<TaskToDoViewModel> _tasksToDo;

		public IEnumerable<TaskToDoViewModel> TasksToDo => _tasksToDo;
		public ICommand NavigateToCreateTaskView { get; }

		public TaskListViewModel(NavigationService createTaskNavigationService)
		{
			_tasksToDo = new ObservableCollection<TaskToDoViewModel>();

			NavigateToCreateTaskView = new NavigationCommand(createTaskNavigationService);
		}
	}
}
