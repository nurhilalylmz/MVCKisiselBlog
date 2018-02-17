using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class Kategori
    {
        public Kategori()
        {
            Makale = new HashSet<Makale>();
        }

        public int KategoriId { get; set; }

        public string KategoriAdi { get; set; }

        public string Aciklama { get; set; }

        public virtual ICollection<Makale> Makale { get; set; }
    }
}