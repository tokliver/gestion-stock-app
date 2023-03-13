using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickLive.Core.DTOs
{
    public class StockDto
    {
        public int StockId { get; set; }
        public string Nom { get; set; }
        public virtual ICollection<ArticleDto> Articles { get; set; }
    }
}
