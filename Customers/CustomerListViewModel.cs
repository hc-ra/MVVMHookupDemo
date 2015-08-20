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

namespace MVVMHookupDemo.Customers
{
	public class CustomerListViewModel
	{
		private ICustomersRepository _repo = new CustomersRepository();
		private ObservableCollection<Customer> _customers;
		public CustomerListViewModel()
		{
			if(DesignerProperties.GetIsInDesignMode(
				new System.Windows.DependencyObject()))
				return;
			Customers = new ObservableCollection<Customer>(_repo.GetCustomersAsync().Result);
			Debug.WriteLine(Customers.Count);
		}
		public ObservableCollection<Customer> Customers
		{
			get
			{
				return _customers;
			}
			set
			{
				_customers = value;
			}
		}
	}
}
