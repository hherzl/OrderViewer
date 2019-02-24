using OrderViewer.Core.EntityLayer;

namespace OrderViewer.ViewModels
{
    public static class ProductSubcategoryMapper
    {
        public static ProductSubcategoryViewModel ToViewModel(this ProductSubcategory entity)
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
