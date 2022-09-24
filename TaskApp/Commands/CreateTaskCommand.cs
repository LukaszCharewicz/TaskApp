using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Models;
using TaskApp.ViewModels;

namespace TaskApp.Commands
{
	internal class CreateTaskCommand : CommandBase
	{
		private readonly CreateTaskViewModel createTaskViewModel;
		private readonly TaskManager taskManager;

		public CreateTaskCommand(CreateTaskViewModel createTaskViewModel, TaskManager taskManager)
		{
			this.taskManager = taskManager;
			this.createTaskViewModel = createTaskViewModel;
			this.createTaskViewModel.PropertyChanged += OnViewModelPropertyChanged;
		}


		public override void Execute(object? parameter)
		{
			TaskToDo taskToDo = new TaskToDo(createTaskViewModel.Description, DateTime.Now, createTaskViewModel.Deadline, createTaskViewModel.TaskState, createTaskViewModel.IsImportant);
			try
			{
				taskManager.CreateTask(taskToDo);
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
