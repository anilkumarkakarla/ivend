using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXS.PosCommon
{
	public interface IAppSettings
	{
		string WebApiUrl
		{
			get;
			set;
		}
	}
}
