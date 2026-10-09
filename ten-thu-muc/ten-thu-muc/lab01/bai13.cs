using System;

namespace natl_CSharp.Tuan2.TH01.bai13
{
    class bai13
    {
        public static void Main(string []args)
        {
            SinhVien sv = new SinhVien();
            sv.Nhap();
            sv.Xuat();
            
            Console.Read();
        }
    }
    class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public int NamThuMay { get; set; }

        public void Nhap()
        {
            Console.Write("Nhap Ma SV: ");
            MaSV = Console.ReadLine();
            Console.Write("Nhap Ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap Dia chi: ");
            DiaChi = Console.ReadLine();
            Console.Write("Nhap Sinh vien nam thu may: ");
            NamThuMay = int.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine($"Ma SV: {MaSV} | Ho ten: {HoTen} | Dia chi: {DiaChi} | SV Nam thứ: {NamThuMay}");
        }
    }
}