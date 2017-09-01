using Microsoft.Extensions.Options;
using OrderViewer.Core.DataLayer;
using OrderViewer.Core.DataLayer.Contracts;
using OrderViewer.Core.DataLayer.Mapping;
using OrderViewer.Core.DataLayer.Repositories;

namespace OrderViewer.Tests
{
    public static class RepositoryMocker
    {
        public static ISalesRepository GetSalesRepository()
        {
            var appSettings = Options.Create(new AppSettings
            {
                ConnectionString = "server=(local);database=AdventureWorks2012;integrated security=yes;"
            });

            return new SalesRepository(new AdventureWorksDbContext(appSettings, new AdventureWorksEntityMapper()));
        }

        public static IProductionRepository GetProductionRepository()
        {
            var appSettings = Options.Create(new AppSettings
            {
                ConnectionString = "server=(local);database=AdventureWorks2012;integrated security=yes;"
            });

            return new ProductionRepository(new AdventureWorksDbContext(appSettings, new AdventureWorksEntityMapper()));
        }
    }
}
