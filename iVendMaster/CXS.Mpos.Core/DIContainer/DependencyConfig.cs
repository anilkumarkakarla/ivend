using System;
using System.Collections.Generic;
using System.Reflection;

namespace CXS.Mpos.Core
{		
	public class DependencyConfig
	{
		private Dictionary<Type, DependencyTemplate> Templates;

		public DependencyConfig  ()
		{
			Templates = new Dictionary<Type, DependencyTemplate>();
		}

		public void Define(Type iType, Type classType,  Parameters parameters = null)
		{
			Templates.Add(iType, new DependencyTemplate (classType, parameters));
		}

		public DependencyTemplate GetTemplate(Type type)
		{
			if (Templates.ContainsKey(type)){
				return this.Templates [type];
 			}
		
			return null;
		}
	}
}