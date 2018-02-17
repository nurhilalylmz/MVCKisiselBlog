namespace Blog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ilk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(maxLength: 50),
                        Aciklama = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.Makale",
                c => new
                    {
                        MakaleId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 500),
                        Icerik = c.String(),
                        EklenmeTarihi = c.DateTime(),
                        KategoriId = c.Int(),
                        KullaniciId = c.Int(),
                        ResimId = c.Int(),
                    })
                .PrimaryKey(t => t.MakaleId)
                .ForeignKey("dbo.Kategori", t => t.KategoriId)
                .ForeignKey("dbo.Kullanici", t => t.KullaniciId)
                .ForeignKey("dbo.Resim", t => t.ResimId)
                .Index(t => t.KategoriId)
                .Index(t => t.KullaniciId)
                .Index(t => t.ResimId);
            
            CreateTable(
                "dbo.Kullanici",
                c => new
                    {
                        KullaniciId = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false, maxLength: 50),
                        Soyadi = c.String(nullable: false, maxLength: 50),
                        KullaniciAdi = c.String(nullable: false, maxLength: 50),
                        Parola = c.String(nullable: false, maxLength: 50),
                        MailAdres = c.String(nullable: false, maxLength: 50),
                        Cinsiyet = c.Boolean(),
                        DogumTarihi = c.DateTime(),
                        KayitTarihi = c.DateTime(),
                        Onaylandi = c.Boolean(),
                        Aktif = c.Boolean(),
                        Yazar = c.Boolean(),
                        ResimId = c.Int(),
                        Aciklama = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.KullaniciId)
                .ForeignKey("dbo.Resim", t => t.ResimId)
                .Index(t => t.ResimId);
            
            CreateTable(
                "dbo.Resim",
                c => new
                    {
                        ResimId = c.Int(nullable: false, identity: true),
                        ResimYolu = c.String(),
                    })
                .PrimaryKey(t => t.ResimId);
            
            CreateTable(
                "dbo.Yorum",
                c => new
                    {
                        YorumId = c.Int(nullable: false, identity: true),
                        YorumIcerigi = c.String(),
                        MakaleId = c.Int(),
                        EklenmeTarihi = c.DateTime(),
                        Rumuz = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.YorumId)
                .ForeignKey("dbo.Makale", t => t.MakaleId)
                .Index(t => t.MakaleId);
            
            CreateTable(
                "dbo.Mesaj",
                c => new
                    {
                        MailId = c.Int(nullable: false, identity: true),
                        MesajKonu = c.String(),
                        MesajMail = c.String(),
                        MesajIcerik = c.String(),
                    })
                .PrimaryKey(t => t.MailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorum", "MakaleId", "dbo.Makale");
            DropForeignKey("dbo.Makale", "ResimId", "dbo.Resim");
            DropForeignKey("dbo.Makale", "KullaniciId", "dbo.Kullanici");
            DropForeignKey("dbo.Kullanici", "ResimId", "dbo.Resim");
            DropForeignKey("dbo.Makale", "KategoriId", "dbo.Kategori");
            DropIndex("dbo.Yorum", new[] { "MakaleId" });
            DropIndex("dbo.Kullanici", new[] { "ResimId" });
            DropIndex("dbo.Makale", new[] { "ResimId" });
            DropIndex("dbo.Makale", new[] { "KullaniciId" });
            DropIndex("dbo.Makale", new[] { "KategoriId" });
            DropTable("dbo.Mesaj");
            DropTable("dbo.Yorum");
            DropTable("dbo.Resim");
            DropTable("dbo.Kullanici");
            DropTable("dbo.Makale");
            DropTable("dbo.Kategori");
        }
    }
}
