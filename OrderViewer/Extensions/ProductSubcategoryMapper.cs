using OrderViewer.Core.EntityLayer;
using OrderViewer.ViewModels;

namespace OrderViewer.Extensions
{
    public static class ProductSubcategoryMapper
    {
        public static ProductSubcategoryViewModel ToProductSubcategoryViewModel(this ProductSubcategory entity)
        {
            return new ProductSubcategoryViewModel
            {
                ProductSubcategoryID = entity.ProductSubcategoryID,
                ProductCategoryID = entity.ProductCategoryID,
                Name = entity.Name,
                ModifiedDate = entity.ModifiedDate
            };
        }
    }
}
