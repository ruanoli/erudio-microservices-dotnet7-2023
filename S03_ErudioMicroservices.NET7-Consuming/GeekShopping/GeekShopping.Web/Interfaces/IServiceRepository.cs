using GeekShopping.Web.Models;

namespace GeekShopping.Web.Interfaces
{
    public interface IServiceRepository
    {
        Task<IEnumerable<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(long id);
        Task<ProductModel> GetProductByName(ProductModel model);
        Task<ProductModel> CreateProduct(ProductModel model);
        Task<ProductModel> UpdateProduct(ProductModel model);
        Task<bool> DeleteProduct(long id);
    }
}
