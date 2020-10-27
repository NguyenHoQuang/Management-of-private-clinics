using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DANHSACHBENHNHAN_DTO
    {
        private int _maBenhNhan;
        public int MaBenhNhan
        {
            get { return _maBenhNhan; }
            set { _maBenhNhan = value; }
        }
        private string _hoTenBenhNhan;
        public string HoTenBenhNhan
        {
            get { return _hoTenBenhNhan; }
            set { _hoTenBenhNhan = value; }
        }
        private string _gioiTinh;
        public string GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }
        private string _ngaySinh;
        public string NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }
        private string _diaChi;
        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private string _ngayKham;
        public string NgayKham
        {
            get { return _ngayKham; }
            set { _ngayKham = value; }
        }
        public DANHSACHBENHNHAN_DTO(string hoten, string gioitinh, string ngaysinh, string diachi, string ngaykham)
        {
            NgayKham = ngaykham;
            HoTenBenhNhan = hoten;
            GioiTinh = gioitinh;
            NgaySinh = ngaysinh;
            DiaChi = diachi;
        }
    }
    public class PHIEUKHAMBENH_DTO
    {
        private int _maPhieuKham;
        public int MaPhieuKham
        {
            get { return _maPhieuKham; }
            set { _maPhieuKham = value; }
        }
        private int _maBenhNhan;
        public int MaBenhNhan
        {
            get { return _maBenhNhan; }
            set { _maBenhNhan = value; }
        }
        private int _maLoaiBenh;
        public int MaLoaiBenh
        {
            get { return _maLoaiBenh; }
            set { _maLoaiBenh = value; }
        }
        private string _trieuChung;
        public string TrieuChung
        {
            get { return _trieuChung; }
            set { _trieuChung = value; }
        }
        public PHIEUKHAMBENH_DTO(int mabenhnhan, int mabenh, string trieuchung)
        {
            MaBenhNhan = mabenhnhan;
            MaLoaiBenh = mabenh;
            TrieuChung = trieuchung;
        }
    }
    public class CT_PHIEUKHAMBENH_DTO
    {
        private int _maLoaiThuoc;
        public int MaLoaiThuoc
        {
            get { return _maLoaiThuoc; }
            set { _maLoaiThuoc = value; }
        }
        
        private int _maPhieuKham;
        public int MaPhieuKham
        {
            get { return _maPhieuKham; }
            set { _maPhieuKham = value; }
        }
        private int _maLoaiDonVi;
        public int MaLoaiDonVi
        {
            get { return _maLoaiDonVi; }
            set { _maLoaiDonVi = value; }
        }
        private int _soLuong;
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        private int _maCachDung;
        public int MaCachDung
        {
            get { return _maCachDung; }
            set { _maCachDung = value; }
        }
       
        public CT_PHIEUKHAMBENH_DTO(int maphieukham, int mathuoc, int madonvi, int soluong, int madung)
        {
            MaPhieuKham = maphieukham;
            MaLoaiThuoc = mathuoc;
            MaLoaiDonVi = madonvi;
            SoLuong = soluong;
            MaCachDung = madung;
        }
    }
    public class THUOC_DTO
    {
        private int _maLoaiThuoc;
        public int MaLoaiThuoc
        {
            get { return _maLoaiThuoc; }
            set { _maLoaiThuoc = value; }
        }
        private string _tenLoaiThuoc;
        public string TenLoaiThuoc
        {
            get { return _tenLoaiThuoc; }
            set { _tenLoaiThuoc = value; }
        }
        private int _donGiaThuoc;
        public int DonGiaThuoc
        {
            get { return _donGiaThuoc; }
            set { _donGiaThuoc = value; }
        }
        private int _soLuong;
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        public THUOC_DTO(string tenthuoc, string dongia, string soluong)
        {
            TenLoaiThuoc = tenthuoc;
            DonGiaThuoc = int.Parse(dongia);
            SoLuong = int.Parse(soluong);
        }
    }
    public class BENH_DTO
    {
        private string _maLoaiBenh;
        public string MaLoaiBenh
        {
            get { return _maLoaiBenh; }
            set { _maLoaiBenh = value; }
        }
        private string _tenLoaiBenh;

        public string TenLoaiBenh
        {
            get { return _tenLoaiBenh; }
            set { _tenLoaiBenh = value; }
        }
        public BENH_DTO(string benh)
        {
            TenLoaiBenh = benh;
        }
    }
    public class DONVI_DTO
    {
        private string _maLoaiDonVi;
        public string MaLoaiDonVi
        {
            get { return _maLoaiDonVi; }
            set { _maLoaiDonVi = value; }
        }
        private string _tenLoaiDonVi;
        public string TenLoaiDonVi
        {
            get { return _tenLoaiDonVi; }
            set { _tenLoaiDonVi = value; }
        }
        public DONVI_DTO(string donvi)
        {
            TenLoaiDonVi = donvi;
        }
    }
    public class THAMSO_DTO
    {
        private int _soBenhNhanToiDa;
        public int SoBenhNhanToiDa
        {
            get { return _soBenhNhanToiDa; }
            set { _soBenhNhanToiDa = value; }
        }
        private int _tienKham;
        public int TienKham
        {
            get { return _tienKham; }
            set { _tienKham = value; }
        }
        public THAMSO_DTO(int sobenhnhan, int tienkham)
        {
            SoBenhNhanToiDa = sobenhnhan;
            TienKham = tienkham;
        }
    }
    public class CACHDUNG_DTO
    {
        private int _maCachDung;
        public int MaCachDung
        {
            get { return _maCachDung; }
            set { _maCachDung = value; }
        }
        private string _tenCachDung;
        public string TenCachDung
        {
            get { return _tenCachDung; }
            set { _tenCachDung = value; }
        }
        public CACHDUNG_DTO(string cachdung)
        {
            TenCachDung = cachdung;
        }
    }
    public class DANGNHAP_DTO
    {
        private int _loaiDangNhap;
        public int LoaiDangNhap
        {
            get { return _loaiDangNhap; }
            set { _loaiDangNhap = value; }
        }
        private string _tenDangNhap;
        public string TenDangNhap
        {
            get { return _tenDangNhap; }
            set { _tenDangNhap = value; }
        }
        private string _matKhau;
        public string MatKhau
        {
            get { return _matKhau; }
            set { _matKhau = value; }
        }
        public DANGNHAP_DTO(int loai, string tendangnhap, string matkhau)
        {
            LoaiDangNhap = loai;
            TenDangNhap = tendangnhap;
            MatKhau = matkhau;
        }
    }

}
