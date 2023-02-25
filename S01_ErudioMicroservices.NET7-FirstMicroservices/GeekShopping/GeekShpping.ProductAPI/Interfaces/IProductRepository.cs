using GeekShpping.ProductAPI.Data.ValueObjects;

namespace GeekShpping.ProductAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> GetAllProducts();
        Task<ProductVO> GetProductById(long id);
        Task<ProductVO> CreateProduct(ProductVO vo);
        Task<ProductVO> UpdateProduct(ProductVO vo);
        Task<bool> DeleteProduct(long id);
    }
}
