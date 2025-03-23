using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DL;

namespace Template.BL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<T> ReadAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<List<T>> ReadAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<string> UpdateAsync(T entity, int id)
        {
            var existingEntity = await _context.Set<T>().FindAsync(id);
            
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return $"Entity with Id {id} Updated.";

            }
            else
            {
                return $"Entity with Id {id} not found.";
            }
        }
        public async Task<string> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return $"Entity with Id {id} deleted.";
                    
            }
            else
            {
                return $"Entity with Id {id} not found.";
            }
        }
    }
}
