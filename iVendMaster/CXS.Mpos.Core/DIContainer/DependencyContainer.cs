using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CXS.Mpos.Core
{
	public class DependencyContainer
	{
		private Dictionary<Type, object> Dependencies;
		public DependencyConfig Config;
		private const string UserScopeName = "UserScope";
		public Parameters UserScope;

		public DependencyContainer ()
		{
			Dependencies = new Dictionary<Type, object> ();
			UserScope = new Parameters ();
		}

		public DependencyContainer (DependencyConfig config)
		{
			Dependencies = new Dictionary<Type, object> ();
			Config = config;
			UserScope = new Parameters ();
		}

		private object GetDependency (Type type)
		{
			if (this.Dependencies.ContainsKey (type)) {
				return Dependencies [type];
			} else if (Config != null) {
				DependencyTemplate template = Config.GetTemplate (type);
				if (template != null) {
					Object instance = Activator.CreateInstance (template.Type);
					if (instance != null) {
						Parameters parameters = template.Parameters;
						foreach (KeyValuePair<string, object> parameter in parameters) {
							PropertyInfo property = instance.GetType ().GetRuntimeProperty (parameter.Key);
							if (property != null) {
								property.SetValue (instance, parameter.Value);
							}
						}
						if (Dependencies.ContainsKey (type)) {
							Dependencies [type] = instance;
						} else {
							Dependencies.Add (type, instance);
						}
						return instance;
					}
				}
			}
			return null;
		}

		public void ResolveDependencies (object obj, Parameters parameters)
		{
			if (obj == null)
				throw new ArgumentNullException ("obj");

			foreach (PropertyInfo property in obj.GetType().GetRuntimeProperties()) {
				string key = property.Name;
				var requiredAttribute = property.GetCustomAttribute<InjectionRequiredAttribute> ();
				var optionalAttribute = property.GetCustomAttribute<InjectionOptionalAttribute> ();

				if (optionalAttribute == null && requiredAttribute == null) {
					continue;
				}

				if (optionalAttribute != null && optionalAttribute.Name != null) {
					key = optionalAttribute.Name;
				}

				if (requiredAttribute != null && requiredAttribute.Name != null) {
					key = requiredAttribute.Name;
				}

				object value = null;

				if (parameters.ContainsKey (key)) {
					value = parameters [key];
				} 

				if (value == null) {
					value = GetDependency (property.PropertyType);
				}

				if (value == null && key.Equals (UserScopeName) && property.PropertyType.Equals (UserScope.GetType ())) {
					value = UserScope;
				}

				if (value == null && UserScope.ContainsKey (key)) {
					value = UserScope [key];
				}

				if (value != null && property.PropertyType.GetTypeInfo ().IsAssignableFrom (value.GetType ().GetTypeInfo ())) {
					ResolveDependencies(value, parameters);
					property.SetValue (obj, value);
				} else {
					if (optionalAttribute != null) {
						property.SetValue (obj, null);
					}

					if (requiredAttribute != null) {
						throw new DependencyNotFoundException ("Dependency NAME: " + key + " TYPE: " + property.PropertyType.ToString () + " not found");
					}
				}
			}
		}
	}
}