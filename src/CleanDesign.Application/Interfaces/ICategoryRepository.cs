
using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;
using CleanDesign.Domain.Interfaces;

namespace CleanDesign.Application.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
         Task<CategoryResponseViewModel> GetCategoryByName(string name);

    }
}
