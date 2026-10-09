using System;
using System.Collections.Generic;

abstract class ThiSinh
{
    public string SBD { get; set; }
    public string HoTen { get; set; }
    public double Bai1 { get; set; }
    public double Bai2 { get; set; }
    public double Bai3 { get; set; }
    public double TongDiem { get; protected set; }

    public ThiSinh() { SBD = ""; HoTen = ""; }

    public virtual void Nhap()
    {
        Console.Write("Nhap SBD: "); SBD = Console.ReadLine() ?? "";
        Console.Write("Nhap Ho ten: "); HoTen = Console.ReadLine() ?? "";
        Console.Write("Diem Bai 1: "); Bai1 = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Diem Bai 2: "); Bai2 = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Diem Bai 3: "); Bai3 = double.Parse(Console.ReadLine() ?? "0");
    }

    public abstract void TinhTongDiem();

    public virtual void Xuat()
    {
        Console.Write($"SBD: {SBD} | Ten: {HoTen,-15} | B1: {Bai1} | B2: {Bai2} | B3: {Bai3} ");
    }
}

class ThiSinhChuyen : ThiSinh
{
    public double TiengAnh { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Diem Tieng Anh: "); 
        TiengAnh = double.Parse(Console.ReadLine() ?? "0");
    }

    public override void TinhTongDiem()
    {
        double diemThuong = 0;
        // Điểm thưởng Tiếng Anh: 7-8 cộng 1đ, 9-10 cộng 2đ[cite: 15]
        if (TiengAnh >= 7 && TiengAnh <= 8) diemThuong = 1;
        else if (TiengAnh >= 9 && TiengAnh <= 10) diemThuong = 2;

        TongDiem = Bai1 + Bai2 + Bai3 + diemThuong;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"| Anh: {TiengAnh} -> Tong: {TongDiem} (He Chuyen)");
    }
}
class ThiSinhSieuCup : ThiSinh
{
    public double CSDL { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Diem CSDL: "); 
        CSDL = double.Parse(Console.ReadLine() ?? "0");
    }

    public override void TinhTongDiem()
    {
        // Siêu cúp: Tổng 4 bài thi[cite: 15]
        TongDiem = Bai1 + Bai2 + Bai3 + CSDL;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"| CSDL: {CSDL} -> Tong: {TongDiem} (He Sieu Cup)");
    }
}
class CuocThi
{
    private List<ThiSinh> danhSachTS = new List<ThiSinh>();

    public void NhapDanhSach()
    {
        Console.Write("Nhap so luong thi sinh tham gia: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Thi sinh thu {i + 1} ---");
            Console.WriteLine("1. Thi sinh he Chuyen");
            Console.WriteLine("2. Thi sinh he Sieu cup");
            Console.Write("Chon he thi (1 hoac 2): ");
            int heThi = int.Parse(Console.ReadLine() ?? "1");

            ThiSinh ts;
            if (heThi == 1) ts = new ThiSinhChuyen();
            else ts = new ThiSinhSieuCup();

            ts.Nhap();
            ts.TinhTongDiem();
            danhSachTS.Add(ts);
        }
    }

    public void XuatKetQua()
    {
        Console.WriteLine("\n--- KET QUA CUOC THI ---");
        foreach (var ts in danhSachTS)
        {
            ts.Xuat();
        }
    }
}

class Program
{
    static void Main()
    {
        // Viết liền chữ cuocThiTinHoc
        CuocThi cuocThiTinHoc = new CuocThi(); 
        cuocThiTinHoc.NhapDanhSach();
        cuocThiTinHoc.XuatKetQua();
    }
}