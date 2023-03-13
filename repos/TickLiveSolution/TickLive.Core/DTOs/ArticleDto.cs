using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickLive.Core.Entities;
using TickLive.Core.Enumerations;

namespace TickLive.Core.DTOs
{
    public class ArticleDto
    {
        public int? Id { get; set; }
        public string Nom { get;  set; }
        public double PrixVenteUnitaire { get; set; }
        public double PrixVenteHT { get;  set; }
        public double PrixVenteTTC { get;  set; }
        public int QuantiteStock { get; set; }
        public string ArticleType { get; set; }
        public double TauxTVA { get; set; }
        public bool IsVenteEmporter { get; set; }


        public  int? StockId { get; set; }
    }
}
