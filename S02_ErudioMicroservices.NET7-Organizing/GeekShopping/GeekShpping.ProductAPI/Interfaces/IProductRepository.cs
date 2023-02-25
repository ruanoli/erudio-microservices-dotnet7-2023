using GeekShpping.ProductAPI.Data.ValueObjects;

namespace GeekShpping.ProductAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindById(long id);
        Task<ProductVO> CreateProduct(ProductVO vo);
        Task<ProductVO> UpdateProduct(ProductVO vo);
        Task<bool> DeleteProduct(long id);
    }
}
