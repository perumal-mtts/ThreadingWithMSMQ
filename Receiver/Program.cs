using Message.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Message.Receiver
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Listerner Starting");
			QueueListener listner = new QueueListener();
			listner.DataReceived += listner_DataReceived;
			listner.Start();
		}

		static void listner_DataReceived(object sender, MessageEventArgs e)
		{
			Employee employee = e.Employee as Employee;
			
			if (employee != null)
			{
				Console.WriteLine("----------------------------------");
				Console.WriteLine("\n Name :	" + employee.Name);
				Console.WriteLine("\n Is Active :	" + employee.IsActive);
				Console.WriteLine("----------------------------------");
			}
		}
	}
}
