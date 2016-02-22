using CXS.Core.Entities;

namespace CXS.Core.Framework.Data
{
	public abstract class BaseRepository<T> : IRepository<T> where T : class
	{
		protected IvendDbContext IvendDbContext;
		public BaseRepository(IvendDbContext dbContext)
		{
			this.IvendDbContext = dbContext;
		}
	}
}
