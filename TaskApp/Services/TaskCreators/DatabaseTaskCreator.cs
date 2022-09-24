using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.DBContext;
using TaskApp.DTOs;
using TaskApp.Models;

namespace TaskApp.Services.TaskCreators
{
	internal class DatabaseTaskCreator : ITaskCreator
	{
		private readonly TaskDbContextFactory _dbContextFactory;

		public DatabaseTaskCreator(TaskDbContextFactory dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}
		
		public async Task CreateTask(TaskToDo task)
		{
			using (TaskDbContext context = _dbContextFactory.CreateDbContext())
			{
				TaskDTO taskDTO = ToTaskDTO(task);
				context.Tasks.Add(taskDTO);
				await context.SaveChangesAsync();
			}

		}

		private TaskDTO ToTaskDTO(TaskToDo task)
		{
			return new TaskDTO()
			{
				Description = task.Description,
				CreationTime = task.CreationTime,
				Deadline = task.Deadline,
				IsImportant = task.IsImportant
			};
		}
	}
}
