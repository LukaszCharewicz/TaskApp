using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskApp.Models;
using TaskApp.ViewModels;

namespace TaskApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly TaskManager taskManager;

		public App()
		{
			taskManager = new TaskManager();
		}
		protected override void OnStartup(StartupEventArgs e)
		{
			MainWindow = new MainWindow()
			{
				DataContext = new MainViewModel(taskManager)
			};

			MainWindow.Show();

			base.OnStartup(e);
		}
	}
}
