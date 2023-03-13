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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TickLiveContext _context;
        private readonly IRepository<Article> _articleRepository;
        private readonly IRepository<Stock> _stockRepository;
        public UnitOfWork(TickLiveContext context)
        {
            _context = context;
        }

        public IRepository<Stock> StockRepository => _stockRepository ?? new BaseRepository<Stock>(_context);

        public IRepository<Article> ArticleRepository => _articleRepository ?? new BaseRepository<Article>(_context);


        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
