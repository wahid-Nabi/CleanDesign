
using CleanDesign.Application.Interfaces;
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
    }
}
