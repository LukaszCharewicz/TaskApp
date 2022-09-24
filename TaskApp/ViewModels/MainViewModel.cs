using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Models;
using TaskApp.Stores;
using TaskApp.ViewModels;

namespace TaskApp.ViewModels
{
	internal class MainViewModel : ViewModelBase
	{
		private readonly NavigationStore navigationStore;

		public ViewModelBase CurrentViewModel => this.navigationStore.CurrentViewModel;


		public MainViewModel(NavigationStore navigationStore)
		{
			this.navigationStore = navigationStore;
			this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
		}

		private void OnCurrentViewModelChanged()
		{
			OnPropertyChanged(nameof(CurrentViewModel));
		}
	}
}
