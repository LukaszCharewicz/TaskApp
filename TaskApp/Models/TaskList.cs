using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Models
{
	internal class TaskList
	{
		private readonly List<Task> tasks;
		public TaskList()
		{
			tasks = new List<Task>();
		}
	}
}
