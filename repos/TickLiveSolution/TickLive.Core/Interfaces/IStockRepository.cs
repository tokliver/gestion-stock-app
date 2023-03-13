using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickLive.Core.Entities;

namespace TickLive.Core.Interfaces
{
    public interface IStockRepository : IRepository<Stock>
    {
        Task<IEnumerable<Stock>> GetStocks();

    }
}
