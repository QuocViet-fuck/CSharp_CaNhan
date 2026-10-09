using System;

namespace natl_CSharp.Tuan2.TH01.bai14
{
    class bai14
    {
        public static void Main(string []args)
        {
            NhanVien nv = new NhanVien();
            nv.Nhap();
            nv.Xuat();

            Console.Read();
        }
    }

    class NhanVien
    {
        public string HoTen { get; set; }
        public double MucLuong { get; set; }
        public int SoNgayVang { get; set; }

        public void Nhap()
        {
            Console.Write("Nhap ho ten nhan vien: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap muc luong co ban: ");
            MucLuong = double.Parse(Console.ReadLine());
            Console.Write("Nhap so ngay vang: ");
            SoNgayVang = int.Parse(Console.ReadLine());
        }

        public double TinhLuong()
        {
            double luong = MucLuong - (SoNgayVang * 100000);
            return luong < 0 ? 0 : luong;
        }

        public void Xuat()
        {
            Console.WriteLine($"Ho ten: {HoTen} | Luong co ban: {MucLuong:N0} VNĐ | Ngay vang: {SoNgayVang} | Luong thuc nhan: {TinhLuong():N0} VNĐ");
        }
    }
}