using TickLive.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickLive.Core.Entities
{
    public class Article : BaseEntity
    {
        public string Nom { get; private set; }
        public double PrixVenteHT { get; private set; }
        public double PrixVenteTTC { get; private set; }
        public int QuantiteStock { get; set; }
        public ArticleType Type { get; set; }
        public double TauxTVA { get; set; }
        public bool IsVenteEmporter { get; set; }
    }
}
