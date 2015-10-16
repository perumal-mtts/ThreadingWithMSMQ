using Message.Core;
using System;
using System.Messaging;
using System.Threading;

namespace Message.Receiver
{
	public class QueueListener
	{
		#region Fields
		private Thread _listener;
		private bool _isStopped;
		private int _messageLength;
		private string queuePath = ".\\Private$\\Queue1";
		#endregion

		#region Events
		public event EventHandler<MessageEventArgs> DataReceived;
		#endregion

		#region Methods
		public void Start()
		{
			_listener = new Thread(new ThreadStart(this.Monitor));
			_listener.Start();
		}

		public void Stop()
		{
			_isStopped = true;
			_listener.Abort();
		}

		public void Monitor()
		{
			while (_isStopped == false)
			{
				if (MessageQueue.Exists(queuePath))
				{
					if (_messageLength != MessageQueue.GetPrivateQueuesByMachine(".").Length)
					{
						if (MessageQueue.GetPrivateQueuesByMachine(".").Length != 0)
						{
							MessageQueue messageQueue = MessageQueue.GetPrivateQueuesByMachine(".")[0];

							if (messageQueue != null)
							{
								if (messageQueue.CanRead)
								{
									if (_messageLength != messageQueue.GetAllMessages().Length)
									{
										_messageLength = messageQueue.GetAllMessages().Length;
										messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Employee) });

										Employee employee = (Employee)messageQueue.GetAllMessages()[_messageLength == 0 ? 0 : _messageLength - 1].Body;
										DataReceived(this, new MessageEventArgs(employee));
									}
								}
							}
						}
					}

				}
			}
		}
		#endregion
	}
}
