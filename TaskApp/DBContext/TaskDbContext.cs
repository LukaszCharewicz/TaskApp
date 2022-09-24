using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.DTOs;
using TaskApp.Models;

namespace TaskApp.DBContext
{
	internal class TaskDbContext : DbContext
	{
		public TaskDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<TaskDTO> Tasks { get; set; }
	}
}
