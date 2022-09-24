using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskApp.Models;
using TaskApp.Enums;
using TaskApp.Commands;

namespace TaskApp.ViewModels
{
	internal class CreateTaskViewModel : ViewModelBase
	{
		private string description;

		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				description = value;
				OnPropertyChanged(nameof(Description));
			}
		}

		private DateTime creationTime = DateTime.Now;
		public DateTime CreationTime
		{
			get
			{
				return creationTime;
			}
		}

		private DateTime deadline = DateTime.Now;
		public DateTime Deadline
		{
			get
			{
				return deadline;
			}
			set
			{
				deadline = value;
				OnPropertyChanged(nameof(Deadline));
			}
		}

		private Enums.TaskState taskState = TaskState.InProgress;
		public Enums.TaskState TaskState
		{
			get
			{
				return taskState;
			}
			set
			{
				taskState = value;
				OnPropertyChanged(nameof(TaskState));
			}
		}

		private bool isImportant = false;
		public bool IsImportant
		{
			get
			{
				return isImportant;
			}
			set
			{
				isImportant = value;
				OnPropertyChanged(nameof(IsImportant));
			}
		}
		public ICommand SubmitCommand { get; set; }
		public ICommand CancelCommand { get; set; }

		public CreateTaskViewModel(TaskManager taskManager)
		{
			SubmitCommand = new CreateTaskCommand(this, taskManager);
			CancelCommand = new CancelCommand();
		}
	}
}
