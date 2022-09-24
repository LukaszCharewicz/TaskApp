using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskApp.DBContext;
using TaskApp.Models;
using TaskApp.Services.TaskCreators;
using TaskApp.Services.TaskProviders;
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
		private readonly TaskDbContextFactory _taskDbContextFactory;
		private const string CONNECTION_STRING = "Data Source=TaskApp.db";

		public App()
		{
			_taskDbContextFactory = new TaskDbContextFactory(CONNECTION_STRING);
			Services.TaskCreators.ITaskCreator taskCreator = new DatabaseTaskCreator(_taskDbContextFactory);
			Services.TaskProviders.ITaskProvider taskProvider = new DatabaseTaskProvider(_taskDbContextFactory);
			TaskList taskList = new TaskList(taskProvider, taskCreator);
			taskManager = new TaskManager(taskList);
			navigationStore = new NavigationStore();
		}
		protected override void OnStartup(StartupEventArgs e)
		{
			using (TaskDbContext dbContext = _taskDbContextFactory.CreateDbContext())
			{
				dbContext.Database.Migrate();
			}


			this.navigationStore.CurrentViewModel = createTaskListViewModel();

			MainWindow = new MainWindow()
			{
				DataContext = new MainViewModel(navigationStore)
			};

			MainWindow.Show();

			base.OnStartup(e);
		}

		private CreateTaskViewModel createCreateTaskListViewModel()
		{
			return new CreateTaskViewModel(this.taskManager, new Services.NavigationService(this.navigationStore, createTaskListViewModel));
		}
		private TaskListViewModel createTaskListViewModel()
		{
			return new TaskListViewModel(this.taskManager, new Services.NavigationService(navigationStore, createCreateTaskListViewModel));
		}

	}
}
