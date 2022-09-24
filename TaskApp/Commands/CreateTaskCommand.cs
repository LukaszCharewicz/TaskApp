using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Models;
using TaskApp.Services;
using TaskApp.ViewModels;

namespace TaskApp.Commands
{
	internal class CreateTaskCommand : CommandBase
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


		public override void Execute(object? parameter)
		{
			TaskToDo taskToDo = new TaskToDo(createTaskViewModel.Description, DateTime.Now, createTaskViewModel.Deadline, createTaskViewModel.TaskState, createTaskViewModel.IsImportant);
			try
			{
				taskManager.CreateTask(taskToDo);
				this.taskListViewNavigationService.Navigate();
			}
			catch (Exception)
			{

				throw;
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
				OnCanExecuredChanged();
			}
		}
	}
}
