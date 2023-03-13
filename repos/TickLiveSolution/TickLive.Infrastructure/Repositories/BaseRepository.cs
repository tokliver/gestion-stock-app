using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickLive.Core.Entities;
using TickLive.Core.Interfaces;
using TickLive.Infrastructure.Data;

namespace TickLive.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TickLiveContext _context;
        protected readonly DbSet<T> _entities;
        public BaseRepository(TickLiveContext context)
        {
            _context = context;
            _entities = context.Set<T>();

        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _entities.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null) return false;

                _entities.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                

                _entities.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<T> SelectAsync(int id)
        {
            try
            {
                return await _entities.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _entities.ToArrayAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _entities.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null) return null;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _entities.AnyAsync(p => p.Id.Equals(id));
        }

    }
}
