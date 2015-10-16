using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Message.Core;

namespace Message.Receiver
{
	public class MessageEventArgs : EventArgs
	{
		public Employee Employee
		{
			get;
			set;
		}

		public MessageEventArgs(Employee employee)
		{
			this.Employee = employee;
		}
	}
}
