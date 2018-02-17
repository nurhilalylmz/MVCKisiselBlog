using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class Resim { 
    public Resim()
    {
        Kullanici = new HashSet<Kullanici>();
        Makale = new HashSet<Makale>();
    }


    public int ResimId { get; set; }

    public string ResimYolu { get; set; }


    public virtual ICollection<Kullanici> Kullanici { get; set; }

    public virtual ICollection<Makale> Makale { get; set; }
}
}
