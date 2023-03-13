using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickLive.Core.Entities
{
    public class Stock : BaseEntity
    {
        public string Nom { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public Stock()
        {
            Articles = new HashSet<Article>();
        }
    }
}
