using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class sqlConectionData
    {
        private static string Connect;
        public static void ConnectionString()
        {
            SqlConnection cnn;
            try
            {
                Connect = @"Data Source=DESKTOP-3S97GI2;Initial Catalog=QuanLyPhongMachTu;Integrated Security=True";
                cnn = new SqlConnection(Connect);
                cnn.Open();
            }
            catch (Exception ex)
            {
                Connect = @"Data Source=.\;Initial Catalog=QLPhongMach;Integrated Security=True";
            }
        }
        public static SqlConnection KetNoi()
        {
            SqlConnection cnn = new SqlConnection(Connect);
            return cnn;
        }
    }
    public class DANHSACHBENHNHAN_DAO
    {
        //load danh sách các bệnh nhân hiện có
        public static DataTable LoadDanhSachHienTai()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("LoadBenhNhan", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //thêm bệnh nhân vào danh sách
        public static void ThemBenhNhan(DANHSACHBENHNHAN_DTO DanhSach)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("ThemBenhNhan", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NgayKham",SqlDbType.SmallDateTime);
            cmd.Parameters.Add("@TenBenhNhan",SqlDbType.NVarChar,50);
            cmd.Parameters.Add("@GioiTinh",SqlDbType.NVarChar,4);
            cmd.Parameters.Add("@NgaySinh",SqlDbType.SmallDateTime);
            cmd.Parameters.Add("@DiaChi",SqlDbType.NVarChar,100);
            cmd.Parameters["@NgayKham"].Value = DanhSach.NgayKham;
            cmd.Parameters["@TenBenhNhan"].Value = DanhSach.HoTenBenhNhan;
            cmd.Parameters["@GioiTinh"].Value = DanhSach.GioiTinh;
            cmd.Parameters["@NgaySinh"].Value = DanhSach.NgaySinh;
            cmd.Parameters["@DiaChi"].Value = DanhSach.DiaChi;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //cập nhật thông tin bệnh nhân
        public static void SuaBenhNhan(DANHSACHBENHNHAN_DTO DanhSach,string MaBenhNhan)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SuaBenhNhan", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NgayKham", SqlDbType.SmallDateTime);
            cmd.Parameters.Add("@TenBenhNhan", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 4);
            cmd.Parameters.Add("@NgaySinh", SqlDbType.SmallDateTime);
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@MaBenhNhan",SqlDbType.Int);
            cmd.Parameters["@NgayKham"].Value = DanhSach.NgayKham;
            cmd.Parameters["@TenBenhNhan"].Value = DanhSach.HoTenBenhNhan;
            cmd.Parameters["@GioiTinh"].Value = DanhSach.GioiTinh;
            cmd.Parameters["@NgaySinh"].Value = DanhSach.NgaySinh;
            cmd.Parameters["@DiaChi"].Value = DanhSach.DiaChi;
            cmd.Parameters["@MaBenhNhan"].Value = MaBenhNhan;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //xóa một bệnh nhân
        public static void XoaBenhNhan(string MaBenhNhan)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("XoaMotBenhNhan", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBenhNhan", SqlDbType.VarChar, 5);
            cmd.Parameters["@MaBenhNhan"].Value = MaBenhNhan;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
    public class THUOC_DAO
    {
        //load danh sach thuoc hien tai
        public static DataTable LoadThuoc()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("LoadThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //thêm một loại thuốc vào danh sách
        public static void ThemThuoc(THUOC_DTO Thuoc)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("ThemThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenThuoc",SqlDbType.NVarChar,50);
            cmd.Parameters.Add("@DonGia",SqlDbType.Money);
            cmd.Parameters.Add("@SoLuong",SqlDbType.Int);
            cmd.Parameters["@TenThuoc"].Value = Thuoc.TenLoaiThuoc;
            cmd.Parameters["@DonGia"].Value = Thuoc.DonGiaThuoc;
            cmd.Parameters["@SoLuong"].Value = Thuoc.SoLuong;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //cập nhật thông tin loại thuốc
        public static void SuaThuoc(THUOC_DTO Thuoc, string MaThuoc)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SuaThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DonGia", SqlDbType.Money);
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
            cmd.Parameters.Add("@MaThuoc",SqlDbType.Int);
            cmd.Parameters["@TenThuoc"].Value = Thuoc.TenLoaiThuoc;
            cmd.Parameters["@DonGia"].Value = Thuoc.DonGiaThuoc;
            cmd.Parameters["@SoLuong"].Value = Thuoc.SoLuong;
            cmd.Parameters["@MaThuoc"].Value = MaThuoc;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //xóa một loại thuốc
        public static void XoaThuoc(string MaThuoc)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("XoaThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaThuoc", SqlDbType.VarChar, 5);
            cmd.Parameters["@MaThuoc"].Value = MaThuoc;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Lay so luong thuoc hien co
        public static int SoLuongThuoc()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SoThuocHienCo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int soluong = Convert.ToInt32(cmd.Parameters["@SoLuong"].Value);
            cnn.Close();
            return soluong;
        }
    }
    public class BENH_DAO
    {
        //load danh sach thuoc hien tai
        public static DataTable LoadBenh()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("LoadBenh", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //thêm một loại Bệnh vào danh sách
        public static void ThemBenh(BENH_DTO Benh)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("ThemBenh", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenBenh", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenBenh"].Value = Benh.TenLoaiBenh;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //cập nhật thông tin loại thuốc
        public static void SuaThuoc(BENH_DTO Benh, string MaBenh)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SuaBenh", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenBenh", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaBenh", SqlDbType.Int);
            cmd.Parameters["@TenBenh"].Value = Benh.TenLoaiBenh;
            cmd.Parameters["@MaBenh"].Value = MaBenh;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //xóa một loại bệnh
        public static void XoaBenh(string MaBenh)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("XoaBenh", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBenh", SqlDbType.VarChar, 5);
            cmd.Parameters["@MaBenh"].Value = MaBenh;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Lay so luong thuoc hien co
        public static int SoLuongBenh()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SoBenhHienCo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int soluong = Convert.ToInt32(cmd.Parameters["@SoLuong"].Value);
            cnn.Close();
            return soluong;
        }
    }
    public class DONVI_DAO
    {
        public static DataTable LoadDonVi()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("LoadDonVi", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //thêm một loại đone vị vào danh sách
        public static void ThemDonVi(DONVI_DTO DonVi)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("ThemDonVi", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenDonVi", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenDonVi"].Value = DonVi.TenLoaiDonVi;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //cập nhật thông tin loại đơn vị
        public static void SuaDonVi(DONVI_DTO DONVI, string MaDV)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SuaDonVi", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenDonVi", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaDonVi", SqlDbType.Int);
            cmd.Parameters["@TenDonVi"].Value = DONVI.TenLoaiDonVi;
            cmd.Parameters["@MaDonVi"].Value = MaDV;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //xóa một loại đơn vị
        public static void XoaDonVi(string MaDV)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("XoaDonVi", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaDonVi", SqlDbType.VarChar, 5);
            cmd.Parameters["@MaDonVi"].Value = MaDV;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Lay so luong đơn vị hien co
        public static int SoLuongDonVi()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SoDonViHienCo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int soluong = Convert.ToInt32(cmd.Parameters["@SoLuong"].Value);
            cnn.Close();
            return soluong;
        }
    }
    public class CACHDUNG_DAO
    {
        public static DataTable LoadCachDung()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("LoadCachDung", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //thêm một loại đone vị vào cách dùng
        public static void ThemCachDung(CACHDUNG_DTO CachDung)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("ThemCachDung", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenCachDung", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenCachDung"].Value = CachDung.TenCachDung;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //cập nhật thông tin loại cách dùng
        public static void SuaCachDung(CACHDUNG_DTO CachDung, string MaCD)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SuaCachDung", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenCachDung", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaCD", SqlDbType.Int);
            cmd.Parameters["@TenCachDung"].Value = CachDung.TenCachDung;
            cmd.Parameters["@MaCD"].Value = MaCD;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //xóa một loại cách dùng
        public static void XoaCachDung(string MaCD)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("XoaCachDung", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaCD", SqlDbType.VarChar, 5);
            cmd.Parameters["@MaCD"].Value = MaCD;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Lay so luong cách dùng hien co
        public static int SoLuongCachDung()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SoCachDungHienCo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int soluong = Convert.ToInt32(cmd.Parameters["@SoLuong"].Value);
            cnn.Close();
            return soluong;
        }
    }
    public class PHIEUKHAMBENH_DAO
    {
        public static DataTable LoadChoKham()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("LoadChoKham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static DataTable LoadDaKham()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("LoadDaKham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static DataTable HienThongTin(int MaBenhNhan)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("HienThongTin", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            cmd.Parameters.Add("@MaBenhNhan",SqlDbType.Int);
            cmd.Parameters["@MaBenhNhan"].Value = MaBenhNhan;
            cnn.Open();
            da.Fill(dtb);
            cnn.Close();
            return dtb;
        }
        public static void ThemPhieuKhamBenh(PHIEUKHAMBENH_DTO PhieuKhamBenh)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("ThemPhieuKhamBenh", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBenhNhan", SqlDbType.Int);
            cmd.Parameters.Add("@MaBenh", SqlDbType.Int);
            cmd.Parameters.Add("@TrieuChung", SqlDbType.NVarChar,50);
            cmd.Parameters["@MaBenhNhan"].Value = PhieuKhamBenh.MaBenhNhan;
            cmd.Parameters["@MaBenh"].Value = PhieuKhamBenh.MaLoaiBenh;
            cmd.Parameters["@TrieuChung"].Value = PhieuKhamBenh.TrieuChung;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
    public class CT_PHIEUKHAMBENH_DAO
    {
        public static int CheckSoLuongThuoc(string TenThuoc, int SoLuong)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("KiemTraThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
            cmd.Parameters.Add("@KetQua", SqlDbType.Int);
            cmd.Parameters["@TenThuoc"].Value = TenThuoc;
            cmd.Parameters["@SoLuong"].Value = SoLuong;
            cmd.Parameters["@KetQua"].Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int KetQua = Convert.ToInt32(cmd.Parameters["@KetQua"].Value);
            cnn.Close();
            return KetQua;
        }
        public static void ThemChiTiet(CT_PHIEUKHAMBENH_DTO CT_PhieuKhamBenh)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("ThemCTPhieuKhamBenh", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPhieuKham", SqlDbType.Int);
            cmd.Parameters.Add("@MaThuoc", SqlDbType.Int);
            cmd.Parameters.Add("@MaDonVi", SqlDbType.Int);
            cmd.Parameters.Add("@MaCachDung", SqlDbType.Int);
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
            cmd.Parameters["@MaPhieuKham"].Value = CT_PhieuKhamBenh.MaPhieuKham;
            cmd.Parameters["@MaThuoc"].Value = CT_PhieuKhamBenh.MaLoaiThuoc;
            cmd.Parameters["@MaDonVi"].Value = CT_PhieuKhamBenh.MaLoaiDonVi;
            cmd.Parameters["@SoLuong"].Value = CT_PhieuKhamBenh.SoLuong;
            cmd.Parameters["@MaCachDung"].Value = CT_PhieuKhamBenh.MaCachDung;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static DataTable LoadThongTin(int maphieukham)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("LoadThongTin", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            cmd.Parameters.Add("@MaPhieuKham",SqlDbType.Int);
            cmd.Parameters["@MaPhieuKham"].Value = maphieukham;
            cnn.Open();
            cmd.ExecuteNonQuery();
            da.Fill(dtb);
            cnn.Close();
            return dtb;
        }
    }
    public class HAMPHU_DAO
    {
        public static int FMaThuoc(string ten)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("FMaThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenThuoc",SqlDbType.NVarChar,50);
            cmd.Parameters["@TenThuoc"].Value = ten;
            cmd.Parameters.Add("@KetQua", SqlDbType.Int).Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int KQ = Convert.ToInt32(cmd.Parameters["@KetQua"].Value);
            cnn.Close();
            return KQ;
        }
        public static int FMaDonVi(string ten)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("FMaDonVi", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenDonVi", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenDonVi"].Value = ten;
            cmd.Parameters.Add("@KetQua", SqlDbType.Int).Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int KQ = Convert.ToInt32(cmd.Parameters["@KetQua"].Value);
            cnn.Close();
            return KQ;
        }
        public static int FMaBenh(string ten)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("FMaBenh", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenBenh", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenBenh"].Value = ten;
            cmd.Parameters.Add("@KetQua", SqlDbType.Int).Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int KQ = Convert.ToInt32(cmd.Parameters["@KetQua"].Value);
            cnn.Close();
            return KQ;
        }
        public static int FMaCachDung(string ten)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("FMaCachDung", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenCachDung", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenCachDung"].Value = ten;
            cmd.Parameters.Add("@KetQua", SqlDbType.Int).Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int KQ = Convert.ToInt32(cmd.Parameters["@KetQua"].Value);
            cnn.Close();
            return KQ;
        }
        public static int FMaPhieuKham(int mabenhnhan, int mabenh)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("FMaPhieuKham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBenhNhan", SqlDbType.Int);
            cmd.Parameters.Add("@MaBenh", SqlDbType.Int);
            cmd.Parameters["@MaBenhNhan"].Value = mabenhnhan;
            cmd.Parameters["@MaBenh"].Value = mabenh;
            cmd.Parameters.Add("@KetQua", SqlDbType.Int).Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int KQ = Convert.ToInt32(cmd.Parameters["@KetQua"].Value);
            cnn.Close();
            return KQ;
        }
    }
    public class TIMKIEM_DAO
    {
        public static DataTable TimTen(string ten)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("TimTen", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            cmd.Parameters.Add("@TenBenhNhan",SqlDbType.NVarChar,50);
            cmd.Parameters["@TenBenhNhan"].Value = ten;
            cnn.Open();
            cmd.ExecuteNonQuery();
            da.Fill(dtb);
            cnn.Close();
            return dtb;
        }
        public static DataTable TimNgay(DateTime NgayKham)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("TimNgay", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            cmd.Parameters.Add("@NgayKham", SqlDbType.SmallDateTime);
            cmd.Parameters["@NgayKham"].Value = NgayKham.Date;
            cnn.Open();
            cmd.ExecuteNonQuery();
            da.Fill(dtb);
            cnn.Close();
            return dtb;
        }
    }
    public class HOADON_DAO
    {
        public static void TaoHoaDon(int MaBN)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("TaoHoaDon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBenhNhan", SqlDbType.Int);
            cmd.Parameters["@MaBenhNhan"].Value = MaBN;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static DataTable XuatHoaDon(int MaBN)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("XuatHoaDon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBenhNhan", SqlDbType.Int);
            cmd.Parameters["@MaBenhNhan"].Value = MaBN;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            cnn.Open();
            cmd.ExecuteNonQuery();
            da.Fill(dtb);
            cnn.Close();
            return dtb;
        }
    }
    public class CTHD_DAO
    {
        public static DataTable XuatCTHoaDon(int MaHoaDon)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("XuatCTHoaDon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaHoaDon", SqlDbType.Int);
            cmd.Parameters["@MaHoaDon"].Value = MaHoaDon;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            cnn.Open();
            cmd.ExecuteNonQuery();
            da.Fill(dtb);
            cnn.Close();
            return dtb;
        }
        public static void TaoCTHoaDon(int MaBN)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("TaoCTHoaDon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBenhNhan", SqlDbType.Int);
            cmd.Parameters["@MaBenhNhan"].Value = MaBN;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
    public class BAOCAO_DAO
    {
        public static DataTable ChonThangNam()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("ChonThang", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static DataTable ChiTietNgay(DateTime Ngaydauthang, DateTime ngaycuoithang)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("ChiTietBaoCao", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            cmd.Parameters.Add("@NgayDauThang", SqlDbType.SmallDateTime);
            cmd.Parameters.Add("@NgayCuoiThang", SqlDbType.SmallDateTime);
            cmd.Parameters["@NgayDauThang"].Value = Ngaydauthang;
            cmd.Parameters["@NgayCuoiThang"].Value = Ngaydauthang;
            cnn.Open();
            cmd.ExecuteNonQuery();
            da.Fill(dtb);
            cnn.Close();
            return dtb;
        }
        public static DataTable ChiTietThuoc(DateTime Ngaydauthang, DateTime ngaycuoithang)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("ChiTietThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            cmd.Parameters.Add("@NgayDauThang", SqlDbType.SmallDateTime);
            cmd.Parameters.Add("@NgayCuoiThang", SqlDbType.SmallDateTime);
            cmd.Parameters["@NgayDauThang"].Value = Ngaydauthang;
            cmd.Parameters["@NgayCuoiThang"].Value = Ngaydauthang;
            cnn.Open();
            cmd.ExecuteNonQuery();
            da.Fill(dtb);
            cnn.Close();
            return dtb;
        }
    }
    public class QUYDINH_DAO
    {
        public static void CaiDat(int sotoida, int tienkham)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("CaiDat", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SoToiDa", SqlDbType.Int);
            cmd.Parameters.Add("@TienKham", SqlDbType.Int);
            cmd.Parameters["@SoToiDa"].Value = sotoida;
            cmd.Parameters["@TienKham"].Value = tienkham;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static int BenhNhanToiDa()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("BenhNhanToiDa", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@KetQua", SqlDbType.Int);
            cmd.Parameters["@KetQua"].Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int kq = Convert.ToInt32(cmd.Parameters["@KetQua"].Value);
            cnn.Close();
            return kq;
        }
        public static int TienKham()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("SoTienKham", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@KetQua", SqlDbType.Money);
            cmd.Parameters["@KetQua"].Direction = ParameterDirection.Output;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int kq = Convert.ToInt32(cmd.Parameters["@KetQua"].Value);
            cnn.Close();
            return kq;
        }
    }
    public class DANGNHAP_DAO
    {
        public static int TrangThai(string TenDangNhap, string MatKhau)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("DangNhapTaiKhoan", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar ,50);
            cmd.Parameters.Add("@MK", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@KetQua",SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters["@TaiKhoan"].Value = TenDangNhap;
            cmd.Parameters["@MK"].Value = MatKhau; ;
            cnn.Open();
            cmd.ExecuteNonQuery();
            int kq = Convert.ToInt32(cmd.Parameters["@KetQua"].Value);
            cnn.Close();
            return kq;
        }
        public static DataTable LoadTaiKhoan()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("LoadTaiKhoan", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        public static void ThemTaiKhoan(DANGNHAP_DTO TaiKhoan)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("ThemTaiKhoan", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoaiDangNhap", SqlDbType.Int).Value = TaiKhoan.LoaiDangNhap;
            cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50).Value = TaiKhoan.TenDangNhap;
            cmd.Parameters.Add("@Pass", SqlDbType.NVarChar, 50).Value = TaiKhoan.MatKhau;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void CapNhatTaiKhoan(DANGNHAP_DTO TaiKhoan)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("CapNhatTaiKhoan", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoaiTaiKhoan", SqlDbType.Int).Value = TaiKhoan.LoaiDangNhap;
            cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50).Value = TaiKhoan.TenDangNhap;
            cmd.Parameters.Add("@Pass", SqlDbType.NVarChar, 50).Value = TaiKhoan.MatKhau;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void XoaTaiKhoan(string TenTaiKhoan)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("XoaTaiKhoan", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenTaiKhoan", SqlDbType.NVarChar, 50).Value = TenTaiKhoan;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void CapNhatLoai(string TenDangNhap,int Loai)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("CapNhatLoai", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoaiTaiKhoan", SqlDbType.Int).Value = Loai;
            cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50).Value = TenDangNhap;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void CapNhatMatKhau(string TenDangNhap, string MatKhau)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("CapNhatMatKhau", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Pass", SqlDbType.NVarChar, 50).Value = MatKhau;
            cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar, 50).Value = TenDangNhap;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
    public class THONGTIN_DAO
    {
        public static void ThemThongTin(string ThongTin)
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("ThemThongTin", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ThongTin", SqlDbType.NVarChar,1000).Value = ThongTin;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static DataTable LoadThongTin()
        {
            SqlConnection cnn = sqlConectionData.KetNoi();
            SqlCommand cmd = new SqlCommand("LoadInfo", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
    }
}
