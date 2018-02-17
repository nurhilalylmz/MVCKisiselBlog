using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class Makale{
    public Makale()
    {
        Yorum = new HashSet<Yorum>();

    }


    public int MakaleId { get; set; }


    public string Baslik { get; set; }

    public string Icerik { get; set; }

    public DateTime? EklenmeTarihi { get; set; }

    public int? KategoriId { get; set; }

        public int? KullaniciId { get; set; }

        public int? ResimId { get; set; }

    public virtual Kategori Kategori { get; set; }


        public virtual Kullanici Kullanici { get; set; }
        public virtual Resim Resim { get; set; }

    public virtual ICollection<Yorum> Yorum { get; set; }
}
}

