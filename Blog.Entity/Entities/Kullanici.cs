using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class Kullanici { 
    public Kullanici()
    {
       
        Makale = new HashSet<Makale>();

    }

    public int KullaniciId { get; set; }


    public string Adi { get; set; }


    public string Soyadi { get; set; }


    public string KullaniciAdi { get; set; }


    public string Parola { get; set; }


    public string MailAdres { get; set; }

    public bool? Cinsiyet { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public bool? Onaylandi { get; set; }

    public bool? Aktif { get; set; }

    public bool? Yazar { get; set; }

    public int? ResimId { get; set; }

    public string Aciklama { get; set; }

  

    public virtual ICollection<Makale> Makale { get; set; }
    public virtual Resim Resim { get; set; }

}
}
