
using CleanDesign.Application.Interfaces;

namespace CleanDesign.Infrastructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken)
                                 .ConfigureAwait(false);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
