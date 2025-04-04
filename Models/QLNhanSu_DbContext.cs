using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_QLNhanSu.Models;

public partial class QLNhanSu_DbContext : DbContext
{
    public QLNhanSu_DbContext()
    {
    }

    public QLNhanSu_DbContext(DbContextOptions<QLNhanSu_DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<ChucVuNhanVien> ChucVuNhanViens { get; set; }

    public virtual DbSet<HopDongLaoDong> HopDongLaoDongs { get; set; }

    public virtual DbSet<Luong> Luongs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TrinhDoHocVan> TrinhDoHocVans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HP\\SQLEXPRESS;Initial Catalog=QL_NhanSu;Trust Server Certificate=True;Trusted_Connection=true;User ID=user_qlns;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.MaChucVu).HasName("PK__ChucVu__D4639533BA2B82CB");

            entity.ToTable("ChucVu");

            entity.Property(e => e.MaChucVu)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ChucVuNhanVien>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ChucVu_NhanVien");

            entity.Property(e => e.MaChucVu)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.MaChucVuNavigation).WithMany()
                .HasForeignKey(d => d.MaChucVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChucVu_Nh__MaChu__5629CD9C");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany()
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChucVu_Nh__MaNha__571DF1D5");
        });

        modelBuilder.Entity<HopDongLaoDong>(entity =>
        {
            entity.HasKey(e => e.MaHopDong).HasName("PK__HopDongL__36DD43428AC93BE8");

            entity.ToTable("HopDongLaoDong");

            entity.HasIndex(e => e.MaNhanVien, "HD_UC_MaNhanVien").IsUnique();

            entity.Property(e => e.MaHopDong)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.MaNhanVienNavigation).WithOne(p => p.HopDongLaoDong)
                .HasForeignKey<HopDongLaoDong>(d => d.MaNhanVien)
                .HasConstraintName("FK__HopDongLa__MaNha__59FA5E80");
        });

        modelBuilder.Entity<Luong>(entity =>
        {
            entity.HasKey(e => e.BacLuong).HasName("PK__Luong__1679C25A34BFF3D9");

            entity.ToTable("Luong");

            entity.Property(e => e.BacLuong).ValueGeneratedNever();
            entity.Property(e => e.HeSoCoBan).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.HeSoLuong).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.LuongCoBan).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA472AA6EA72");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.MaChucVu)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaPhongBan)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaTrinhDoHocVan)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.HasOne(d => d.BacLuongNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.BacLuong)
                .HasConstraintName("FK__NhanVien__BacLuo__5165187F");

            entity.HasOne(d => d.MaPhongBanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaPhongBan)
                .HasConstraintName("FK__NhanVien__MaPhon__52593CB8");

            entity.HasOne(d => d.MaTrinhDoHocVanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaTrinhDoHocVan)
                .HasConstraintName("FK__NhanVien__MaTrin__534D60F1");

            entity.HasOne(nv => nv.TaiKhoan)
              .WithOne(tk => tk.MaNhanVienNavigation) // Chỉ rõ quan hệ
              .HasForeignKey<TaiKhoan>(d => d.MaNhanVien); // Chỉ định khóa ngoại
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPhongBan).HasName("PK__PhongBan__D0910CC81F81B278");

            entity.ToTable("PhongBan");

            entity.Property(e => e.MaPhongBan)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaiKhoan__3214EC27104B294E");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.MaNhanVien, "UC_MaNhanVien").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__TaiKhoan__A9D105348F16C3E8").IsUnique();

            entity.HasIndex(e => e.TenTaiKhoan, "UQ__TaiKhoan__B106EAF815D63A8F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MatKhau).IsUnicode(false);
            entity.Property(e => e.TenTaiKhoan).HasMaxLength(255);

            entity.HasOne(d => d.MaNhanVienNavigation)
                .WithOne(p => p.TaiKhoan)
                .HasForeignKey<TaiKhoan>(d => d.MaNhanVien)
                .HasConstraintName("FK__TaiKhoan__MaNhan__0A9D95DB");
        });

        modelBuilder.Entity<TrinhDoHocVan>(entity =>
        {
            entity.HasKey(e => e.MaTrinhDoHocVan).HasName("PK__TrinhDoH__B3AD801380FB4056");

            entity.ToTable("TrinhDoHocVan");

            entity.Property(e => e.MaTrinhDoHocVan)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TrinhDoHocVan1).HasColumnName("TrinhDoHocVan");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
