using System;
using NUnit.Framework;
using CXS.Mpos.Core;
using System.Threading;

namespace CXS.Mpos.POS.Tests
{
	[TestFixture ()]
	public class OperationTests
	{
		[Test]
		public void UserScopeClearTest()
		{
			var op = OperationProcessor.Instance;

			var userScopeCheckExpectation = new AutoResetEvent (false);
			var loadUserScopeOperationExpectation = new AutoResetEvent (false);
			var logoutOperationExpectation = new AutoResetEvent (false);

			op.PerformOperation (typeof(LoadUserScopeOperation), null, (Parameters result) => {
				loadUserScopeOperationExpectation.Set ();
			});

			op.PerformOperation (typeof(LogoutOperation), null, (Parameters result) => {
				logoutOperationExpectation.Set ();
			});

			op.PerformOperation (typeof(CheckUserScopeOperation), null, (Parameters result) => {
				userScopeCheckExpectation.Set ();
			});

			Assert.True (loadUserScopeOperationExpectation.WaitOne (TimeSpan.FromSeconds (10)));
			Assert.True (logoutOperationExpectation.WaitOne (TimeSpan.FromSeconds (10)));
			Assert.True (userScopeCheckExpectation.WaitOne (TimeSpan.FromSeconds (10)));
		}
	}
}

