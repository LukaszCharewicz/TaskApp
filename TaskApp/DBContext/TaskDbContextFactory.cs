using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.DBContext
{
	internal class TaskDbContextFactory
	{
		private readonly string _connectionString;

		public TaskDbContextFactory(string connectionString)
		{
			_connectionString = connectionString;
		}

		public TaskDbContext CreateDbContext()
		{
			var options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
			return new TaskDbContext(options);
		}
	}
}
