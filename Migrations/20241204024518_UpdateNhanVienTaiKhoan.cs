using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_QLNhanSu.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNhanVienTaiKhoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    MaChucVu = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChucVu__D4639533BA2B82CB", x => x.MaChucVu);
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    BacLuong = table.Column<int>(type: "int", nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    HeSoLuong = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    HeSoCoBan = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Luong__1679C25A34BFF3D9", x => x.BacLuong);
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    MaPhongBan = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PhongBan__D0910CC81F81B278", x => x.MaPhongBan);
                });

            migrationBuilder.CreateTable(
                name: "TrinhDoHocVan",
                columns: table => new
                {
                    MaTrinhDoHocVan = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TrinhDoHocVan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChuyenNganh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TrinhDoH__B3AD801380FB4056", x => x.MaTrinhDoHocVan);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    QueQuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanToc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    SoDienThoai = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    BacLuong = table.Column<int>(type: "int", nullable: true),
                    MaPhongBan = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaChucVu = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaTrinhDoHocVan = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__77B2CA472AA6EA72", x => x.MaNhanVien);
                    table.ForeignKey(
                        name: "FK__NhanVien__BacLuo__5165187F",
                        column: x => x.BacLuong,
                        principalTable: "Luong",
                        principalColumn: "BacLuong");
                    table.ForeignKey(
                        name: "FK__NhanVien__MaPhon__52593CB8",
                        column: x => x.MaPhongBan,
                        principalTable: "PhongBan",
                        principalColumn: "MaPhongBan");
                    table.ForeignKey(
                        name: "FK__NhanVien__MaTrin__534D60F1",
                        column: x => x.MaTrinhDoHocVan,
                        principalTable: "TrinhDoHocVan",
                        principalColumn: "MaTrinhDoHocVan");
                });

            migrationBuilder.CreateTable(
                name: "ChucVu_NhanVien",
                columns: table => new
                {
                    MaChucVu = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaNhanVien = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__ChucVu_Nh__MaChu__5629CD9C",
                        column: x => x.MaChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "MaChucVu");
                    table.ForeignKey(
                        name: "FK__ChucVu_Nh__MaNha__571DF1D5",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "HopDongLaoDong",
                columns: table => new
                {
                    MaHopDong = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    LoaiHopDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayBatDau = table.Column<DateOnly>(type: "date", nullable: false),
                    NgayKetThuc = table.Column<DateOnly>(type: "date", nullable: true),
                    MaNhanVien = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HopDongL__36DD43428AC93BE8", x => x.MaHopDong);
                    table.ForeignKey(
                        name: "FK__HopDongLa__MaNha__59FA5E80",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien");
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    MaNhanVien = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TaiKhoan__3214EC27104B294E", x => x.ID);
                    table.ForeignKey(
                        name: "FK__TaiKhoan__MaNhan__0A9D95DB",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChucVu_NhanVien_MaChucVu",
                table: "ChucVu_NhanVien",
                column: "MaChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_ChucVu_NhanVien_MaNhanVien",
                table: "ChucVu_NhanVien",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "HD_UC_MaNhanVien",
                table: "HopDongLaoDong",
                column: "MaNhanVien",
                unique: true,
                filter: "[MaNhanVien] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_BacLuong",
                table: "NhanVien",
                column: "BacLuong");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaPhongBan",
                table: "NhanVien",
                column: "MaPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaTrinhDoHocVan",
                table: "NhanVien",
                column: "MaTrinhDoHocVan");

            migrationBuilder.CreateIndex(
                name: "UC_MaNhanVien",
                table: "TaiKhoan",
                column: "MaNhanVien",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__TaiKhoan__A9D105348F16C3E8",
                table: "TaiKhoan",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__TaiKhoan__B106EAF815D63A8F",
                table: "TaiKhoan",
                column: "TenTaiKhoan",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChucVu_NhanVien");

            migrationBuilder.DropTable(
                name: "HopDongLaoDong");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "PhongBan");

            migrationBuilder.DropTable(
                name: "TrinhDoHocVan");
        }
    }
}
