using BTLinQ;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Khoa> danhSachKhoa = new List<Khoa>
        {
            new Khoa("Cong nghe so"),
            new Khoa("Dien - Dien Tu")
        };

        danhSachKhoa[0].DanhSachSinhVien.Add(new SinhVien("Nguyen Van A", 8.5));
        danhSachKhoa[0].DanhSachSinhVien.Add(new SinhVien("Tran Van B", 2.5));
        danhSachKhoa[0].DanhSachSinhVien.Add(new SinhVien("Le Thi C", 9.0));
        danhSachKhoa[0].DanhSachSinhVien.Add(new SinhVien("Tran Van Khoa", 8.5));
        danhSachKhoa[0].DanhSachSinhVien.Add(new SinhVien("Nguyen Van Khoa", 5.5));
        danhSachKhoa[1].DanhSachSinhVien.Add(new SinhVien("Pham Van D", 6.5));
        danhSachKhoa[1].DanhSachSinhVien.Add(new SinhVien("Hoang Thi E", 3.5));
        danhSachKhoa[1].DanhSachSinhVien.Add(new SinhVien("Nguyen Van F", 7.5));
        danhSachKhoa[1].DanhSachSinhVien.Add(new SinhVien("Le Van Khoa", 2.5));
        danhSachKhoa[1].DanhSachSinhVien.Add(new SinhVien("Nguyen Ba Khoa", 9.5));

        // Danh sách sinh viên theo khoa, sắp xếp theo tên
        var dsSinhVienTheoKhoa = from khoa in danhSachKhoa
                                 from sv in khoa.DanhSachSinhVien
                                 orderby khoa.TenKhoa, sv.Ten
                                 select new { TenKhoa = khoa.TenKhoa, TenSinhVien = sv.Ten, DiemTrungBinh = sv.DiemTrungBinh };
        Console.WriteLine("\nDanh sach sinh viên theo khoa, sap xep theo ten: \n");
        foreach (var sv in dsSinhVienTheoKhoa)
        {
            Console.WriteLine($"Ten Khoa: {sv.TenKhoa}, Sinh vien: {sv.TenSinhVien}, Diem trung binh: {sv.DiemTrungBinh}");
        }

        // Danh sách sinh viên có điểm trung bình lớn hơn 7.0
        var dsSinhVienDiemTBLonHon7 = from khoa in danhSachKhoa
                                      from sv in khoa.DanhSachSinhVien
                                      where sv.DiemTrungBinh > 7.0
                                      select new { TenKhoa = khoa.TenKhoa, TenSinhVien = sv.Ten, DiemTrungBinh = sv.DiemTrungBinh };

        Console.WriteLine("\nDanh sach sinh vien co diem trung binh lon hon 7.0:\n");
        foreach (var sv in dsSinhVienDiemTBLonHon7)
        {
            Console.WriteLine($"Sinh vien: {sv.TenSinhVien},Ten Khoa: {sv.TenKhoa}, Diem trung binh: {sv.DiemTrungBinh}");
        }

        // Danh sách sinh viên có điểm trung bình bé hơn 4.0
        var dsSinhVienDiemTBNhoHon4 = from khoa in danhSachKhoa
                                      from sv in khoa.DanhSachSinhVien
                                      where sv.DiemTrungBinh < 4.0
                                      select new { TenKhoa = khoa.TenKhoa, TenSinhVien = sv.Ten, DiemTrungBinh = sv.DiemTrungBinh };

        Console.WriteLine("\nDanh sach sinh viên co diem trung binh bé hơn 7.0:\n");
        foreach (var sv in dsSinhVienDiemTBNhoHon4)
        {
            Console.WriteLine($"Sinh vien: {sv.TenSinhVien}, Ten Khoa: {sv.TenKhoa}, Diem trung binh: {sv.DiemTrungBinh}");
        }

        // Kiểm tra sinh viên nào có tên là "Khoa"
        var svKhoa = from khoa in danhSachKhoa
                     from sv in khoa.DanhSachSinhVien
                     where sv.Ten.Contains("Khoa")
                     select new { TenKhoa = khoa.TenKhoa, TenSinhVien = sv.Ten, DiemTrungBinh = sv.DiemTrungBinh };

        Console.WriteLine("\nSinh vien co ten la 'Khoa': \n");
        foreach (var sv in svKhoa)
        {
            Console.WriteLine($"Sinh vien: {sv.TenSinhVien}, Ten Khoa: {sv.TenKhoa}, Diem trung binh: {sv.DiemTrungBinh}");
        }

        // In danh sách sinh viên có thông tin khoa
        var dsSinhVienCoThongTinKhoa = from khoa in danhSachKhoa
                                       from sv in khoa.DanhSachSinhVien
                                       select new { TenKhoa = khoa.TenKhoa, TenSinhVien = sv.Ten, DiemTrungBinh = sv.DiemTrungBinh };
        Console.WriteLine("\nDanh sach sinh vien co thong tin khoa: \n");
        foreach (var sv in dsSinhVienCoThongTinKhoa)
        {
            Console.WriteLine($"Ten Khoa: {sv.TenKhoa}, Sinh vien: {sv.TenSinhVien}, Diem trung binh: {sv.DiemTrungBinh}");
        }

        // Tìm sinh viên giỏi nhất
        var sinhVienGioiNhat = (from khoa in danhSachKhoa
                                from sv in khoa.DanhSachSinhVien
                                orderby sv.DiemTrungBinh descending
                                select new { TenKhoa = khoa.TenKhoa, TenSinhVien = sv.Ten, DiemTrungBinh = sv.DiemTrungBinh }).First();

        Console.WriteLine($"\nSinh vien gioi nhat: Sinh vien: {sinhVienGioiNhat.TenSinhVien}, Ten Khoa: {sinhVienGioiNhat.TenKhoa}, Diem trung binh: {sinhVienGioiNhat.DiemTrungBinh}");
    }
}