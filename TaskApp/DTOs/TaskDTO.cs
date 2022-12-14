using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Enums;

namespace TaskApp.DTOs
{
	internal class TaskDTO
	{
		[Key]
		public Guid Id {get; set; }
		public string Description { get; set; }
		public DateTime CreationTime { get; set; }
		public DateTime Deadline { get; set; }
		public bool IsImportant { get; set; }
	}
}
