using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.EntityFrameWork.Mappings
{
    public class MakaleMapping : EntityTypeConfiguration<Makale>
    {
        public MakaleMapping()
        {
            this.HasKey<int>(x => x.MakaleId);
            HasOptional(x => x.Kategori)
                .WithMany(x => x.Makale)
                .HasForeignKey(x => x.KategoriId);
            HasOptional(x => x.Kullanici)
                .WithMany(x => x.Makale)
                .HasForeignKey(x => x.KullaniciId);
            HasOptional(x => x.Resim)
                .WithMany(x => x.Makale)
                .HasForeignKey(x => x.ResimId);
            this.Property(x => x.Baslik)
                .HasMaxLength(500);

        }
    }
}