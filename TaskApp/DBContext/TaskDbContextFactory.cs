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
		private readonly Action<SqliteDbContextOptionsBuilder>? _connectionString;

		public TaskDbContextFactory(Action<SqliteDbContextOptionsBuilder>? connectionString)
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
