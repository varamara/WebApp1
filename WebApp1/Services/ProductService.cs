using WebApp1.Models.Entities;
using WebApp1.Repositories;

namespace WebApp1.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepo;

        public ProductService(ProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<ProductEntity> CreateProductAsync(string productName, string? productDescription, string? productImage, decimal productPrice, int categoryId)
        {
            var entity = new ProductEntity
            {
                ProductName = productName,
                ProductDescription = productDescription,
                ProductImage = productImage,
                ProductPrice = productPrice,
                ProductCategoryId = categoryId
            };

            var result = await _productRepo.AddAsync(entity);
            return result;
        }


        public async Task<ProductEntity> GetProductAsync(int productId)
        {
            return await _productRepo.GetAsync(x => x.Id == productId);
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsAsync()
        {
            return await _productRepo.GetAllAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _productRepo.GetAllWhereAsync(x => x.ProductCategoryId == categoryId);
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _productRepo.GetAsync(x => x.Id == productId);
            if (product != null)
            {
                return await _productRepo.DeleteAsync(product);
            }
            return false;
        }
    }
}
