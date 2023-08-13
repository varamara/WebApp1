using WebApp1.Models.Entities;
using WebApp1.Repositories;

namespace WebApp1.Services
{
    public class ProductCategoryService
    {
        private readonly ProductCategoryRepository _productCategoryRepo;

        public ProductCategoryService(ProductCategoryRepository productCategoryRepo)
        {
            _productCategoryRepo = productCategoryRepo;
        }

        public async Task<ProductCategoryEntity> CreateProductCategoryAsync(string categoryName)
        {
            var entity = new ProductCategoryEntity { CategoryName = categoryName };
            var result = await _productCategoryRepo.AddAsync(entity);
            return result;
        }

        public async Task<ProductCategoryEntity> GetProductCategoryAsync(int id)
        {
            var result = await _productCategoryRepo.GetAsync(x => x.Id == id);
            return result;
        }

        public async Task<ProductCategoryEntity> GetProductCategoryAsync(string categoryName)
        {
            var result = await _productCategoryRepo.GetAsync(x => x.CategoryName == categoryName);
            return result;
        }

        public async Task<IEnumerable<ProductCategoryEntity>> GetProductCategoriesAsync()
        {
            var result = await _productCategoryRepo.GetAllAsync();
            return result;
        }
    }
}
