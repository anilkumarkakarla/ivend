using System;
using System.Collections.Generic;

namespace CXS.Mpos.Core
{
	public interface IDataBaseService
	{
		List<T> PerformRequest<T> (DataBaseRequest request) where T : new();

		void Initialize (string databaseFileName);

		void Initialize (DataBaseRequest request);
	}
}

