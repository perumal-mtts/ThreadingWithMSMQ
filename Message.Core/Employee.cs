using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.Core
{
	[Serializable]
	public class Employee
	{
		public Employee()
		{
		}

		public string Name
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}
	}
}
