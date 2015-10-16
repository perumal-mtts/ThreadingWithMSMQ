using Message.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;

namespace Sender
{
	class Program
	{
		static string queueName = ".\\Private$\\Queue1";
		static MessageQueue myQueue;
		static void Main(string[] args)
		{
			if (!MessageQueue.Exists(queueName))
			{
				myQueue = MessageQueue.Create(queueName);
			}
			else
			{
				myQueue = MessageQueue.GetPrivateQueuesByMachine(".")[0];
			}

			Send();

			Console.ReadLine();
		}

		public static void Send()
		{
			for (int i = 0; i < 1000; i++)
			{
				Console.WriteLine("Sending {0} employee", i.ToString());
				Employee employee = new Employee();
				employee.Name = "Employuee " + i.ToString();
				employee.IsActive = i % 2 == 0 ? true : false;

				Thread.Sleep(2000);
				myQueue.Send(employee);
			}
			
		}
	}
}
