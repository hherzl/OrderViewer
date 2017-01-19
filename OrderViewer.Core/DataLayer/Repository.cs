using System;

namespace OrderViewer.Core.DataLayer
{
    public abstract class Repository
    {
        protected readonly AdventureWorksDbContext DbContext;
        protected Boolean Disposed;

        public Repository(AdventureWorksDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();

                    Disposed = true;
                }
            }
        }
    }
}
