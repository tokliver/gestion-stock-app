using TickLive.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TickLive.Core.Entities
{
    public class Article : BaseEntity
    {

        public string Nom { get; private set; }
        public double PrixVenteUnitaire { get; set; }
        public double PrixVenteHT { get; private set; }
        public double PrixVenteTTC { get; private set; }
        public int QuantiteStock { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public ArticleType ArticleType { get; set; }
        public double TauxTVA { get; set; }
        public bool IsVenteEmporter { get; set; }

        public int? StockId { get; set; }

        public virtual Stock Stock { get; set; }
    }
}
