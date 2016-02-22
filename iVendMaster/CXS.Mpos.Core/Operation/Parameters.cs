using System;
using System.Collections.Generic;

namespace CXS.Mpos.Core
{
	public class Parameters : Dictionary<string, object>
	{
		public void AddParameters (Parameters source)
		{
			if (source != null) {
				foreach (var param in source) {
					if (this.ContainsKey (param.Key)) {
						this [param.Key] = param.Value;
					} else {
						this.Add (param.Key, param.Value);
					}
				}
			}
		}
	}
}

