using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXS.PosCommon
{
	public static class ConnectionManager
	{
		public static ConnectionStatus ConnectionStatus
		{
			get
			{
				return CheckConnection();
			}
		}

		public static ConnectionStatus CheckConnection()
		{
			ConnectionStatus status;

			int i = 0;
			while (i < 3)
			{
				try
				{
					status = ConnectionStatus.Connected;

					if (status == ConnectionStatus.Connected)
					{
						return status;
					}
					
				}
				catch
				{
					status = ConnectionStatus.Unknown;
				}
			}

			return ConnectionStatus.Disconnected;
		}

	}
}
