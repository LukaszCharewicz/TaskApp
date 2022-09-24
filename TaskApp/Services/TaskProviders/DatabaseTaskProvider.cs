using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Models;

namespace TaskApp.Services.TaskProviders
{
    internal class DatabaseTaskProvider : ITaskProvider
    {
        public Task<IEnumerable<TaskToDo>> GetAllTask()
        {
            throw new NotImplementedException();
        }
    }
}
