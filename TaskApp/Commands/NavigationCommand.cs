using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Stores;
using TaskApp.ViewModels;
using TaskApp.Models;
using TaskApp.Services;

namespace TaskApp.Commands
{
	internal class NavigationCommand : CommandBase
	{
		private readonly NavigationService navigationService;

		public NavigationCommand(NavigationService navigationService)
		{
			this.navigationService = navigationService;
		}

		public override void Execute(object? parameter)
		{
			this.navigationService.Navigate();
		}
	}
}
