namespace HaberSistemi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Olustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Haber",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Baslik = c.String(nullable: false, maxLength: 200),
                    KisaAciklama = c.String(),
                    OkunmaSayisi = c.Int(nullable: false),
                    Aciklama = c.String(),
                    AktifMi = c.Boolean(nullable: false),
                    EklemeTarihi = c.DateTime(nullable: false),
                    Resim = c.String(maxLength: 200),
                    Kullanici_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kullanici", t => t.Kullanici_ID)
                .Index(t => t.Kullanici_ID);

            CreateTable(
                "dbo.Kullanici",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    AdSoyad = c.String(maxLength: 50),
                    Email = c.String(),
                    Sifre = c.String(nullable: false),
                    KayitTarihi = c.DateTime(nullable: false),
                    Aktif = c.Boolean(nullable: false),
                    Rol_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rol", t => t.Rol_ID)
                .Index(t => t.Rol_ID);
            CreateTable(
                "dbo.Kategori",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    KategoriAdi = c.String(maxLength: 150),
                    ParentID = c.Int(nullable: false),
                    URL = c.String(maxLength: 150),
                    KayitTarihi = c.DateTime(nullable: false),
                    AktifMi = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Rol",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    RolAdi = c.String(maxLength: 100),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Resim",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ResimUrl = c.String(),
                    Haber_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Haber", t => t.Haber_ID)
                .Index(t => t.Haber_ID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Resim", "Haber_ID", "dbo.Haber");
            DropForeignKey("dbo.Haber", "Kullanici_ID", "dbo.Kullanici");
            DropForeignKey("dbo.Kullanici", "Rol_ID", "dbo.Rol");
            DropForeignKey("dbo.Haber", "Kategori_ID", "dbo.Kategori");
            DropIndex("dbo.Resim", new[] { "Haber_ID" });
            DropIndex("dbo.Kullanici", new[] { "Rol_ID" });
            DropIndex("dbo.Haber", new[] { "Kullanici_ID" });
            DropIndex("dbo.Haber", new[] { "Kategori_ID" });
            DropTable("dbo.Resim");
            DropTable("dbo.Rol");
            DropTable("dbo.Kullanici");
            DropTable("dbo.Kategori");
            DropTable("dbo.Haber");
        }
    }
}