using System.Collections.Generic;

namespace OrderViewer.Core.DataLayer.Mapping
{
    public class AdventureWorksEntityMapper : EntityMapper
    {
        public AdventureWorksEntityMapper()
        {
            Mappings = new List<IEntityMap>()
            {
                new SalesOrderHeaderMap(),
                new AddressMap(),
                new ShipMethodMap(),
                new CustomerMap(),
                new PersonMap(),
                new StoreMap(),
                new SalesPersonMap(),
                new SalesTerritoryMap(),
                new SalesOrderDetailMap(),
                new ProductMap(),
                new ProductSubcategoryMap()
            };
        }
    }
}
