
using CleanDesign.Application.Interfaces;
using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;
using CleanDesign.Domain.Interfaces;

namespace CleanDesign.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public async Task<CategoryResponseViewModel> GetCategoryByName(string name)
        {
            throw new NotImplementedException();
            if(string.IsNullOrEmpty(name)) {
                return resul
            }
        }
    }
}
