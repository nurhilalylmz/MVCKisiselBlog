using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.EntityFrameWork.Mappings
{
    public class KategoriMapping : EntityTypeConfiguration<Kategori>
    {
        public KategoriMapping()
        {
            this.HasKey<int>(x => x.KategoriId);

            this.Property(x => x.KategoriAdi)
                .HasMaxLength(50);
            this.Property(x => x.Aciklama)
               .HasMaxLength(50);
        }

    }
}
