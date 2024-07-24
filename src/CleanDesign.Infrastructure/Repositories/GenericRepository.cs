﻿using CleanDesign.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanDesign.Infrastructure.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entity;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _entity.AddAsync(entity);
        }
        public void Update(T entity)
        {
            _entity.Update(entity);
        }

        public void Delete(T entity)
        {
            _entity.Remove(entity);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _entity.FindAsync(id) ?? Activator.CreateInstance<T>();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _entity.ToListAsync();
        }

    }
}