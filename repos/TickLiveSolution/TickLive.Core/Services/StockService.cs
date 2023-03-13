using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickLive.Core.Entities;
using TickLive.Core.Interfaces;

namespace TickLive.Core.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Stock>> GetStocks()
        {
           return  await _unitOfWork.StockRepository.SelectAsync();

        }
    }
}
