using Blog.DAL.EntityFrameWork.Mappings;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.EntityFrameWork.Context
{
    public class BlogDbContext : DbContext
    {

        public BlogDbContext() : base("BlogDbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BlogDbContext>());
        }

        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Makale> Makale { get; set; }
        public virtual DbSet<Resim> Resim { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }
        public virtual DbSet<Mesaj> Mesaj { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KategoriMapping());
            modelBuilder.Configurations.Add(new KullaniciMapping());

            modelBuilder.Configurations.Add(new MakaleMapping());
            modelBuilder.Configurations.Add(new ResimMapping());

            modelBuilder.Configurations.Add(new YorumMapping());
            modelBuilder.Configurations.Add(new MesajMapping());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Add(new OneToManyCascadeDeleteConvention());
        }
    }


}