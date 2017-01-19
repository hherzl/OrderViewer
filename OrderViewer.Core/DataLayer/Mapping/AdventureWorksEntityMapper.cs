using System.Collections.Generic;

namespace OrderViewer.Core.DataLayer.Mapping
{
    public class AdventureWorksEntityMapper : EntityMapper
    {
        public AdventureWorksEntityMapper()
        {
            Mappings = new List<IEntityMap>()
            {
                new SalesOrderHeaderMap() as IEntityMap,
                new AddressMap() as IEntityMap,
                new ShipMethodMap() as IEntityMap,
                new CustomerMap() as IEntityMap,
                new PersonMap() as IEntityMap,
                new StoreMap() as IEntityMap,
                new SalesPersonMap() as IEntityMap,
                new SalesTerritoryMap() as IEntityMap,
                new SalesOrderDetailMap() as IEntityMap,
                new ProductMap() as IEntityMap,
                new ProductSubcategoryMap() as IEntityMap
            };
        }
    }
}
