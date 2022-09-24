using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskApp.Models;
using TaskApp.Services;
using TaskApp.ViewModels;

namespace TaskApp.Commands
{
	internal class CreateTaskCommand : AsyncCommandBase
	{
		private readonly CreateTaskViewModel createTaskViewModel;
		private readonly TaskManager taskManager;
		private readonly NavigationService taskListViewNavigationService;

		public CreateTaskCommand(CreateTaskViewModel createTaskViewModel, TaskManager taskManager, NavigationService taskListViewNavigationService)
		{
			this.taskManager = taskManager;
			this.createTaskViewModel = createTaskViewModel;
			this.createTaskViewModel.PropertyChanged += OnViewModelPropertyChanged;
			this.taskListViewNavigationService = taskListViewNavigationService;

		}


		public async override Task ExecuteAsync(object parameter)
		{
			TaskToDo taskToDo = new TaskToDo(createTaskViewModel.Description, DateTime.Now, createTaskViewModel.Deadline, createTaskViewModel.IsImportant);
			try
			{
				await taskManager.CreateTask(taskToDo);
				this.taskListViewNavigationService.Navigate();
			}
			catch (Exception)
			{
				MessageBox.Show("Cannot create task.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public override bool CanExecute(object? parameter)
		{
			return !string.IsNullOrEmpty(createTaskViewModel.Description) && base.CanExecute(parameter);
		}

		private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(CreateTaskViewModel.Description))
			{
				OnCanExecutedChanged();
			}
		}
	}
}
