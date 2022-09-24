using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.ViewModels
{
	internal class TaskListViewModel : ViewModelBase
	{
		private readonly ObservableCollection<TaskToDoViewModel> _tasksToDo;
		public IEnumerable<TaskToDoViewModel> TasksToDo => _tasksToDo;

		public TaskListViewModel()
		{
			_tasksToDo = new ObservableCollection<TaskToDoViewModel>();
		}
	}
}
