using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class Yorum
    {
        public int YorumId { get; set; }

        public string YorumIcerigi { get; set; }

        public int? MakaleId { get; set; }

        public DateTime? EklenmeTarihi { get; set; }

        public string Rumuz { get; set; }

        public virtual Makale Makale { get; set; }
    }
}
