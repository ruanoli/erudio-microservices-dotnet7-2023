using GeekShopping.Web.Interfaces;
using GeekShopping.Web.Models;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public const string BasePath = "api/v1/product";
        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAs<List<ProductModel>>();
        }
        public async Task<ProductModel> GetProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");

            return await response.ReadContentAs<ProductModel>();
        }
        //public Task<ProductModel> GetProductByName(ProductModel model)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong when calling the API.");

            return await response.ReadContentAs<ProductModel>();
        }
        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong when calling the API.");

            return await response.ReadContentAs<ProductModel>();
        }
        public async Task<bool> DeleteProduct(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something went wrong when calling the API.");

            return await response.ReadContentAs<bool>();
        }   
    }
}
