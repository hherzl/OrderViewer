using Microsoft.EntityFrameworkCore;
using OrderViewer.Core.DataLayer;
using OrderViewer.Core.DataLayer.Contracts;
using OrderViewer.Core.DataLayer.Mapping;
using OrderViewer.Core.DataLayer.Repositories;

namespace OrderViewer.Tests
{
    public static class RepositoryMocker
    {
        private static string ConnectionString
            => "server=(local);database=AdventureWorks2012;integrated security=yes;";

        public static ISalesRepository GetSalesRepository()
        {
            var options = new DbContextOptionsBuilder<AdventureWorksDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            return new SalesRepository(new AdventureWorksDbContext(options, new AdventureWorksEntityMapper()));
        }

        public static IProductionRepository GetProductionRepository()
        {
            var options = new DbContextOptionsBuilder<AdventureWorksDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;

            return new ProductionRepository(new AdventureWorksDbContext(options, new AdventureWorksEntityMapper()));
        }
    }
}
