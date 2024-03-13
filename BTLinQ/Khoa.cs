using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLinQ
{
    public class Khoa
    {
        public string TenKhoa { get; set; }
        public List<SinhVien> DanhSachSinhVien { get; set; }
        public Khoa(string tenKhoa)
        {
            TenKhoa = tenKhoa;
            DanhSachSinhVien = new List<SinhVien>();
        }
    }
}
