using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using MVVMHookupDemo.Services;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace MVVMHookupDemo.Customers
{
	public class CustomerListViewModel : INotifyPropertyChanged
	{
		private ICustomersRepository _repo = new CustomersRepository();
		private ObservableCollection<Customer> _customers;
		public CustomerListViewModel()
		{
			DeleteCommand = new RelayCommand(OnDelete, CanDelete);
		}

		public async void LoadCustomers()
		{
			if (DesignerProperties.GetIsInDesignMode(
				new System.Windows.DependencyObject()))
				return;
			Customers = new ObservableCollection<Customer>(await _repo.GetCustomersAsync());
		}

		private bool CanDelete()
		{
			return SelectedCustomer != null;
		}

		private void OnDelete()
		{
			Customers.Remove(SelectedCustomer);
		}

		public RelayCommand DeleteCommand { get; private set; }
		private Customer _selectedCustomer;

		public Customer SelectedCustomer
		{
			get { return _selectedCustomer; }
			set
			{
				_selectedCustomer = value;
				DeleteCommand.RaiseCanExecuteChanged();
			}
		}

		public ObservableCollection<Customer> Customers
		{
			get
			{
				return _customers;
			}
			set
			{
				if (_customers != value)
				{
					_customers = value;
					PropertyChanged(this, new PropertyChangedEventArgs("Customers"));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged = delegate { };
	}
}
