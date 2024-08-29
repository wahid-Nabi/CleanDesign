
using CleanDesign.Domain.Entities;
using CleanDesign.Domain.Interfaces;
using CleanDesign.Domain.ViewModels;

namespace CleanDesign.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product> 
    {
        Task saveCategoryProduct(CategoryProductViewModel product);
        Task<List<Category>> GetCategoryByIds(List<string> categoriesId);
    }
}
