
using CleanDesign.Application.Interfaces;
using CleanDesign.Domain.Entities;
using CleanDesign.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CleanDesign.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoryByIds(List<string> categoryIds)
        {
            List<Category> categories = new List<Category>();

            // Convert the string IDs to a list of Guids
            List<Guid> categoryGuids = categoryIds
                .Select(id =>
                {
                    bool isValid = Guid.TryParse(id, out var categoryGuidId);
                    return (isValid, categoryGuidId);
                })
                .Where(result => result.isValid)
                .Select(result => result.categoryGuidId)
                .ToList();

            categories = await _context.Category.Where(c => categoryGuids.Contains(c.Id)).ToListAsync();

            return categories;

        }

        public async Task saveCategoryProduct(CategoryProductViewModel product)
        {

            await _context.SaveChangesAsync();
        }
    }
}
