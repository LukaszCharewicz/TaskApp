using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Models;

namespace TaskApp.Services.TaskProviders
{
    internal interface ITaskProvider
    {
        Task<IEnumerable<TaskToDo>> GetAllTask();
    }
}
