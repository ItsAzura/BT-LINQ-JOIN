using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLinQ
{
    public class SinhVien
    {
        public string Ten { get; set; }
        public double DiemTrungBinh { get; set; }

        public SinhVien(string ten, double diemTrungBinh)
        {
            Ten = ten;
            DiemTrungBinh = diemTrungBinh;
        }

    }
}
