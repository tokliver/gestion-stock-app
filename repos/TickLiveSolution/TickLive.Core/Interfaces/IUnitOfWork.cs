using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickLive.Core.Entities;

namespace TickLive.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Stock> StockRepository { get; }
        IRepository<Article> ArticleRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
