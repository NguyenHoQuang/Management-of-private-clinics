using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAO;

namespace BUS
{
    public class DANHSACHBENHNHAN_BUS
    {
        //Load danh sách bệnh nhân hiện tại
        public static DataTable LoadDanhSachHienTai()
        {
            return DANHSACHBENHNHAN_DAO.LoadDanhSachHienTai();
        }
        //Thêm một bệnh nhân vào danh sách
        public static void ThemBenhNhan(DANHSACHBENHNHAN_DTO DanhSach)
        {
            DANHSACHBENHNHAN_DAO.ThemBenhNhan(DanhSach);
        }
        //Sửa thông tin của một bệnh nhân
        public static void SuaBenhNhan(DANHSACHBENHNHAN_DTO DanhSach,string MaBenhNhan)
        {
            DANHSACHBENHNHAN_DAO.SuaBenhNhan(DanhSach,MaBenhNhan);
        }
        //Xóa một bệnh nhân ra khỏi dánh sách
        public static void XoaBenhNhan(string mabenhnhan)
        {
            DANHSACHBENHNHAN_DAO.XoaBenhNhan(mabenhnhan);
        }
    }
    public class THUOC_BUS
    {
        //Load danh sách bệnh nhân hiện tại
        public static DataTable LoadThuoc()
        {
            return THUOC_DAO.LoadThuoc();
        }
        //Thêm một bệnh nhân vào danh sách
        public static void ThemThuoc(THUOC_DTO Thuoc)
        {
            THUOC_DAO.ThemThuoc(Thuoc);
        }
        //Sửa thông tin của một bệnh nhân
        public static void SuaThuoc(THUOC_DTO Thuoc, string MaThuoc)
        {
            THUOC_DAO.SuaThuoc(Thuoc,MaThuoc);
        }
        //Xóa một bệnh nhân ra khỏi dánh sách
        public static void XoaThuoc(string MaThuoc)
        {
            THUOC_DAO.XoaThuoc(MaThuoc);
        }
        public static int SoLuongThuoc()
        {
            return THUOC_DAO.SoLuongThuoc();
        }
    }
    public class BENH_BUS
    {
        //Load danh sách bệnh hiện tại
        public static DataTable LoadBenh()
        {
            return BENH_DAO.LoadBenh();
        }
        //Thêm một bệnh vào danh sách
        public static void ThemBenh(BENH_DTO Benh)
        {
            BENH_DAO.ThemBenh(Benh);
        }
        //Sửa thông tin của bệnh 
        public static void SuaBenh(BENH_DTO Benh, string MaBenh)
        {
            BENH_DAO.SuaThuoc(Benh, MaBenh);
        }
        //Xóa một bệnh ra khỏi dánh sách
        public static void XoaBenh(string MaBenh)
        {
            BENH_DAO.XoaBenh(MaBenh);
        }
        public static int SoLuongBenh()
        {
            return BENH_DAO.SoLuongBenh();
        }
    }
    public class DONVI_BUS
    {
        //Load danh sách bệnh hiện tại
        public static DataTable LoadDonVi()
        {
            return DONVI_DAO.LoadDonVi();
        }
        //Thêm một bệnh vào danh sách
        public static void ThemDonVi(DONVI_DTO DonVi)
        {
            DONVI_DAO.ThemDonVi(DonVi);
        }
        //Sửa thông tin của bệnh 
        public static void SuaDonVi(DONVI_DTO DonVi, string MaDV)
        {
            DONVI_DAO.SuaDonVi(DonVi, MaDV);
        }
        //Xóa một bệnh ra khỏi dánh sách
        public static void XoaDonVi(string MaDV)
        {
            DONVI_DAO.XoaDonVi(MaDV);
        }
        public static int SoLuongDonVi()
        {
            return DONVI_DAO.SoLuongDonVi();
        }
    }
    public class CACHDUNG_BUS
    {
        //Load danh sách bệnh hiện tại
        public static DataTable LoadCachDung()
        {
            return CACHDUNG_DAO.LoadCachDung();
        }
        //Thêm một bệnh vào danh sách
        public static void ThemCachDung(CACHDUNG_DTO CachDung)
        {
            CACHDUNG_DAO.ThemCachDung(CachDung);
        }
        //Sửa thông tin của bệnh 
        public static void SuaCachDung(CACHDUNG_DTO CachDung, string MaCD)
        {
            CACHDUNG_DAO.SuaCachDung(CachDung, MaCD);
        }
        //Xóa một bệnh ra khỏi dánh sách
        public static void XoaCachDung(string MaCD)
        {
            CACHDUNG_DAO.XoaCachDung(MaCD);
        }
        public static int SoLuongCachDung()
        {
            return CACHDUNG_DAO.SoLuongCachDung();
        }
    }
    public class PHIEUKHAMBENH_BUS
    {
        public static DataTable LoadChoKham()
        {
            return PHIEUKHAMBENH_DAO.LoadChoKham();
        }
        public static DataTable LoadDaKham()
        {
            return PHIEUKHAMBENH_DAO.LoadDaKham();
        }
        public static DataTable HienThongTin(int MaBenhNhan)
        {
            return PHIEUKHAMBENH_DAO.HienThongTin(MaBenhNhan);
        }
        public static void ThemPhieuKhamBenh(PHIEUKHAMBENH_DTO PhieuKhamBenh)
        {
            PHIEUKHAMBENH_DAO.ThemPhieuKhamBenh(PhieuKhamBenh);
        }
    }
    public class CT_PHIEUKHAMBENH_BUS
    {
        public static int CheckSoLuongThuoc(string TenThuoc,int SoLuong)
        {
            return CT_PHIEUKHAMBENH_DAO.CheckSoLuongThuoc(TenThuoc,SoLuong);
        }
        public static void ThemChiTiet(CT_PHIEUKHAMBENH_DTO CTPK)
        {
            CT_PHIEUKHAMBENH_DAO.ThemChiTiet(CTPK);
        }
        public static DataTable LoadThongTin(int maphieukham)
        {
            return CT_PHIEUKHAMBENH_DAO.LoadThongTin(maphieukham);
        }
    }
    public class HAMPHU_BUS
    {
        public static int FMaThuoc(string ten)
        {
            return HAMPHU_DAO.FMaThuoc(ten);
        }
        public static int FMaBenh(string ten)
        {
            return HAMPHU_DAO.FMaBenh(ten);
        }
        public static int FMaDonVi(string ten)
        {
            return HAMPHU_DAO.FMaDonVi(ten);
        }
        public static int FMaCachDung(string ten)
        {
            return HAMPHU_DAO.FMaCachDung(ten);
        }
        public static int FMaPhieuKham(int mabenhnhan, int mabenh)
        {
            return HAMPHU_DAO.FMaPhieuKham(mabenhnhan,mabenh);
        }
    }
    public class TIMKIEM_BUS
    {
        public static DataTable TimTen(string ten)
        {
            return TIMKIEM_DAO.TimTen(ten);
        }
        public static DataTable TimNgay(DateTime NgayKham)
        {
            return TIMKIEM_DAO.TimNgay(NgayKham);
        }
    }
    public class HOADON_BUS
    {
        public static void TaoHoaDon(int MaBN)
        {
            HOADON_DAO.TaoHoaDon(MaBN);
        }
        public static DataTable XuatHoaDon(int MaBN)
        {
            return HOADON_DAO.XuatHoaDon(MaBN);
        }
    }
    public class CTHD_BUS
    {
        public static void TaoCTHoaDon(int MaBN)
        {
            CTHD_DAO.TaoCTHoaDon(MaBN);
        }
        public static DataTable XuatCTHoaDon(int MaHoaDon)
        {
            return CTHD_DAO.XuatCTHoaDon(MaHoaDon);
        }
    }
    public class BAOCAO_BUS
    {
        public static DataTable ChonThangNam()
        {
            return BAOCAO_DAO.ChonThangNam();
        }
        public static DataTable ChiTietNgay(DateTime ngaydauthang, DateTime ngaycuoithang)
        {
            return BAOCAO_DAO.ChiTietNgay(ngaydauthang,ngaycuoithang);
        }
        public static DataTable ChiTietThuoc(DateTime ngaydauthang, DateTime ngaycuoithang)
        {
            return BAOCAO_DAO.ChiTietThuoc(ngaydauthang, ngaycuoithang);
        }
    }
    public class QUYDINH_BUS
    {
        public static void CaiDat(int sotoida, int tienkham)
        {
            QUYDINH_DAO.CaiDat(sotoida,tienkham);
        }
        public static int BenhNhanToiDa()
        {
            return QUYDINH_DAO.BenhNhanToiDa();
        }
        public static int TienKham()
        {
            return QUYDINH_DAO.TienKham();
        }

    }
    public class DANGNHAP_BUS
    {
        public static int TrangThai(string TenDangNhap, string MatKhau)
        {
            return DANGNHAP_DAO.TrangThai(TenDangNhap,MatKhau);
        }
        public static DataTable LoadTaiKhoan()
        {
            return DANGNHAP_DAO.LoadTaiKhoan();
        }
        public static void ThemTaiKhoan(DANGNHAP_DTO TaiKhoan)
        {
            DANGNHAP_DAO.ThemTaiKhoan(TaiKhoan);
        }
        public static void CapNhatTaiKhoan(DANGNHAP_DTO TaiKhoan)
        {
            DANGNHAP_DAO.CapNhatTaiKhoan(TaiKhoan);
        }
        public static void XoaTaiKhoan(string TenTaiKhoan)
        {
            DANGNHAP_DAO.XoaTaiKhoan(TenTaiKhoan);
        }
        public static void CapNhatLoai(string TenTaiKhoan, int Loai)
        {
            DANGNHAP_DAO.CapNhatLoai(TenTaiKhoan, Loai);
        }        
        public static void CapNhatMatKhau(string TenTaiKhoan, string MatKhau)
        {
            DANGNHAP_DAO.CapNhatMatKhau(TenTaiKhoan,MatKhau);
        }
    }
    public class THONGTIN_BUS
    {
        public static DataTable LoadThongTin()
        {
            return THONGTIN_DAO.LoadThongTin();
        }
        public static void ThemThongTin(string ThongTin)
        {
            THONGTIN_DAO.ThemThongTin(ThongTin);
        }
    }
}
