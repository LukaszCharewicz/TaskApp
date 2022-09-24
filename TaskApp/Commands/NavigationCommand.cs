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
		private readonly Func<ViewModelBase> createViewModel;

		public NavigationCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
		{
			this.navigationStore = navigationStore;
			this.createViewModel = createViewModel;
		}

		public override void Execute(object? parameter)
		{
			this.navigationStore.CurrentViewModel = this.createViewModel();
		}
	}
}
