using System;

namespace CXS.PosCommon
{
	public class Dispatcher<IOnlineContract, IOfflineContract, IContract>
	{
		public IContract Instance
		{
			get; set;
		}

		public Dispatcher()
		{
			string connectionString = "";

			if (ConnectionManager.ConnectionStatus == ConnectionStatus.Connected)
			{
				//connectionString = ConfigurationManager.ConnectionStrings["OnlineDbContext"].ToString();
				this.Instance = (IContract)Activator.CreateInstance(typeof(IOnlineContract), connectionString);
			}
			else if (ConnectionManager.ConnectionStatus == ConnectionStatus.Disconnected)
			{
				//connectionString = ConfigurationManager.ConnectionStrings["OfflineDbContext"].ToString();
				this.Instance = (IContract)Activator.CreateInstance(typeof(IOfflineContract), connectionString);
			}
		}
	}
}
