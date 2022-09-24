using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskApp.Models;
using TaskApp.Stores;
using TaskApp.ViewModels;
using TaskApp.Views;

namespace TaskApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly TaskManager taskManager;
		private readonly NavigationStore navigationStore;

		public App()
		{
			taskManager = new TaskManager();
			navigationStore = new NavigationStore();
		}
		protected override void OnStartup(StartupEventArgs e)
		{
			this.navigationStore.CurrentViewModel = new TaskListViewModel(this.navigationStore);

			MainWindow = new MainWindow()
			{
				DataContext = new MainViewModel(navigationStore)
			};

			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}
