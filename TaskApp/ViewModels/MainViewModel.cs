using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Models;
using TaskApp.ViewModels;

namespace TaskApp.ViewModels
{
	internal class MainViewModel : ViewModelBase
	{
		public ViewModelBase CurrentViewModel { get; }

		public MainViewModel(TaskManager taskManager)
		{
			CurrentViewModel = new CreateTaskViewModel(taskManager);
		}
	}
}
