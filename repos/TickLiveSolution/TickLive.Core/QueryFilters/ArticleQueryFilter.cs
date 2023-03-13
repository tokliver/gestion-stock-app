using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickLive.Core.QueryFilters
{
    public class ArticleQueryFilter
    {
        public int? Id { get; set; }
        public string Nom { get; set; }
        public double? PrixVenteUnitaireMin { get; set; }
        public double? PrixVenteUnitaireMax{ get; set; }

    }
}
