using GeekShopping.Web.Interfaces;
using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services
{
    public class ServiceRepository : IServiceRepository
    {
        public Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
        public Task<ProductModel> GetProductById(long id)
        {
            throw new NotImplementedException();
        }
        public Task<ProductModel> GetProductByName(ProductModel model)
        {
            throw new NotImplementedException();
        }
        public Task<ProductModel> CreateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }
        public Task<ProductModel> UpdateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteProduct(long id)
        {
            throw new NotImplementedException();
        }   
    }
}
