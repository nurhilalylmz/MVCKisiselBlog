using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.EntityFrameWork.Mappings
{
    public class KullaniciMapping : EntityTypeConfiguration<Kullanici>
    {
        public KullaniciMapping()
        {
            this.HasKey<int>(x => x.KullaniciId);
            HasOptional(x => x.Resim)
                .WithMany(x => x.Kullanici)
                .HasForeignKey(x => x.ResimId);
            this.Property(x => x.Adi)
                .HasMaxLength(50).IsRequired();
            this.Property(x => x.Soyadi)
               .HasMaxLength(50).IsRequired();
            this.Property(x => x.KullaniciAdi)
                .HasMaxLength(50).IsRequired();
            this.Property(x => x.Parola)
                .HasMaxLength(50).IsRequired();
            this.Property(x => x.MailAdres)
                .HasMaxLength(50).IsRequired();
            this.Property(x => x.Aciklama)
                .HasMaxLength(200).IsRequired();
        }
    }
}
