
using CleanDesign.Application.Interfaces;
using CleanDesign.Application.ViewModels;
using CleanDesign.Domain.Entities;
using CleanDesign.Domain.Interfaces;
using CleanDesign.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace CleanDesign.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category?> GetCategoryByName(string name)
        {

            Category? category = await _context.Category.FirstOrDefaultAsync(c => c.Name == name).ConfigureAwait(false);
            return category;
        }
    }
}
