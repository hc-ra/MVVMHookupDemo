using MVVMHookupDemo.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MVVMHookupDemo
{
	class MainWindowViewModel : INotifyPropertyChanged
	{
		public object CurrentViewModel { get; set; }

		public MainWindowViewModel()
		{
			CurrentViewModel = new CustomerListViewModel();
			_timer.Elapsed += (s, e) =>
				NotificationMessage = "At the tone the time will be: " + DateTime.Now.ToLocalTime();
			_timer.Start();
		}

		private Timer _timer = new Timer(5000);

		private string _notificationMessage;

		public string NotificationMessage
		{
			get { return _notificationMessage; }
			set { 
				if (value == _notificationMessage)
					return;
				_notificationMessage = value;
				PropertyChanged(this, new PropertyChangedEventArgs("NotificationMessage"));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged = delegate { };
	}
}
