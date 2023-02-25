using AutoMapper;
using GeekShpping.ProductAPI.Data.ValueObjects;
using GeekShpping.ProductAPI.Interfaces;
using GeekShpping.ProductAPI.Models;
using GeekShpping.ProductAPI.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShpping.ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDatabaseContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MyDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();

            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> GetProductById(long id)
        {
            var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> CreateProduct(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> UpdateProduct(ProductVO vo)
        {
            Product product = _mapper.Map<Product>(vo);

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> DeleteProduct(long id)
        {
            try
            {
                var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

                if(product == null) return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
