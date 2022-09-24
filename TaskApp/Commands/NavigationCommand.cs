using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Stores;
using TaskApp.ViewModels;
using TaskApp.Models;

namespace TaskApp.Commands
{
	internal class NavigationCommand : CommandBase
	{
		private readonly NavigationStore navigationStore;

		public NavigationCommand(NavigationStore navigationStore)
		{
			this.navigationStore = navigationStore;
		}

		public override void Execute(object? parameter)
		{
			this.navigationStore.CurrentViewModel = new CreateTaskViewModel(new TaskManager());
		}
	}
}
