namespace FE2_BT_2406.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableSV : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChuyenNganhs",
                c => new
                    {
                        MaChuyenNganh = c.Int(nullable: false, identity: true),
                        TenChuyenNganh = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaChuyenNganh);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        MaMonHoc = c.Int(nullable: false, identity: true),
                        TenMonHoc = c.String(nullable: false),
                        MaChuyenNganh = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaMonHoc)
                .ForeignKey("dbo.ChuyenNganhs", t => t.MaChuyenNganh, cascadeDelete: true)
                .Index(t => t.MaChuyenNganh);
            
            CreateTable(
                "dbo.DangKyMonHocs",
                c => new
                    {
                        MaDangKy = c.Int(nullable: false, identity: true),
                        MaMonHoc = c.Int(nullable: false),
                        MaSinhVien = c.String(nullable: false, maxLength: 128),
                        ThoiGianDangKy = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaDangKy)
                .ForeignKey("dbo.MonHocs", t => t.MaMonHoc, cascadeDelete: true)
                .ForeignKey("dbo.SinhViens", t => t.MaSinhVien, cascadeDelete: true)
                .Index(t => t.MaMonHoc)
                .Index(t => t.MaSinhVien);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        MaSinhVien = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(nullable: false),
                        GioiTinh = c.Boolean(nullable: false),
                        MaChuyenNganh = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSinhVien)
                .ForeignKey("dbo.ChuyenNganhs", t => t.MaChuyenNganh, cascadeDelete: false)
                .Index(t => t.MaChuyenNganh);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DangKyMonHocs", "MaSinhVien", "dbo.SinhViens");
            DropForeignKey("dbo.SinhViens", "MaChuyenNganh", "dbo.ChuyenNganhs");
            DropForeignKey("dbo.DangKyMonHocs", "MaMonHoc", "dbo.MonHocs");
            DropForeignKey("dbo.MonHocs", "MaChuyenNganh", "dbo.ChuyenNganhs");
            DropIndex("dbo.SinhViens", new[] { "MaChuyenNganh" });
            DropIndex("dbo.DangKyMonHocs", new[] { "MaSinhVien" });
            DropIndex("dbo.DangKyMonHocs", new[] { "MaMonHoc" });
            DropIndex("dbo.MonHocs", new[] { "MaChuyenNganh" });
            DropTable("dbo.SinhViens");
            DropTable("dbo.DangKyMonHocs");
            DropTable("dbo.MonHocs");
            DropTable("dbo.ChuyenNganhs");
        }
    }
}
