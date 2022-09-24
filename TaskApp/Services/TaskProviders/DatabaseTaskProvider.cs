using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.DBContext;
using TaskApp.DTOs;
using TaskApp.Models;

namespace TaskApp.Services.TaskProviders
{
    internal class DatabaseTaskProvider : ITaskProvider
    {
        private readonly TaskDbContextFactory _dbContextFactory;

        public DatabaseTaskProvider(TaskDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<TaskToDo>> GetAllTask()
        {
            using (TaskDbContext context = _dbContextFactory.CreateDbContext())
            {
               IEnumerable<TaskDTO> taskDTOs =  await context.Tasks.ToListAsync();
               return taskDTOs.Select(x => new TaskToDo(x.Description, x.CreationTime, x.Deadline, x.IsImportant));
            } 
        }
    }
}
