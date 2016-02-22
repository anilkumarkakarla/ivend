using System;
using System.Threading;
using System.Threading.Tasks;

namespace CXS.Mpos.Core
{
	public abstract class AbstractLogStorage
	{
		protected LogManager LogManager;
		protected LogConfiguration LogConfiguration;

		protected void InitializeAbstractLogStorageCore ()
		{
			LogManager.Initialize (this.LogConfiguration, this);
			this.LogManager = LogManager.GetInstance ();

			if (!this.LogManager.IsDebugMode ()) {
				Task.Factory.StartNew (() => {
					while (true) {
						this.SaveLogTick ();
					}
				}, TaskCreationOptions.LongRunning);
			}
		}

		public abstract void InitializeLogFolder (string logFolderName);

		protected abstract void SaveLogTick ();

		protected abstract bool IsLogFileSizeExceeded (ulong filesize);

		protected abstract void CaptureUnhandledException (object sender, object e);
	}
}