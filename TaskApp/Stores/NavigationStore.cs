using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.ViewModels;

namespace TaskApp.Stores
{
	internal class NavigationStore
	{
		private ViewModelBase _currentViewModel;
		public ViewModelBase CurrentViewModel
		{
			get { return _currentViewModel; }
			set
			{
				_currentViewModel = value;
			}
		}

	}
}
