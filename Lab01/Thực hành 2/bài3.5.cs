using System;
using System.Collections.Generic;

abstract class NhanVien
{
    public string MaNV { get; set; }
    public string HoTen { get; set; }

    public NhanVien() { MaNV = ""; HoTen = ""; }

    public virtual void Nhap()
    {
        Console.Write("Nhap ma nhan vien: ");
        MaNV = Console.ReadLine() ?? "";
        Console.Write("Nhap ho ten: ");
        HoTen = Console.ReadLine() ?? "";
    }

    public virtual void Xuat()
    {
        Console.Write($"[{MaNV}] {HoTen} ");
    }


    public abstract double TinhLuong();
}

class NhanVienKinhDoanh : NhanVien
{
    public double LuongCoBan { get; set; }
    public int SoHopDong { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap luong co ban: ");
        LuongCoBan = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap so hop dong ky ket duoc: ");
        SoHopDong = int.Parse(Console.ReadLine() ?? "0");
    }

    public override double TinhLuong()
    {
        return LuongCoBan + (SoHopDong * 500000);
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"| NV Kinh Doanh | Luong thuc lanh: {TinhLuong():N0} VND");
    }
}

// 3. LỚP CON: NHÂN VIÊN SẢN XUẤT
class NhanVienSanXuat : NhanVien
{
    public int SoSanPham { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap so luong san pham: ");
        SoSanPham = int.Parse(Console.ReadLine() ?? "0");
    }

    public override double TinhLuong()
    {
        // Lương = Số sản phẩm * 1000
        double luong = SoSanPham * 1000;
        // Nếu > 3000 sản phẩm thì thưởng thêm 5%
        if (SoSanPham > 3000)
        {
            luong += luong * 0.05; 
        }
        return luong;
    }

    public override void Xuat()
    {
        base.Xuat();
        Console.WriteLine($"| NV San Xuat | Luong thuc lanh: {TinhLuong():N0} VND");
    }
}

// 4. HÀM MAIN
class Program
{
    static void Main()
    {
        List<NhanVien> danhSachNV = new List<NhanVien>();

        Console.Write("Nhap so luong nhan vien: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhan vien thu {i + 1} ---");
            Console.WriteLine("1. Nhan vien kinh doanh");
            Console.WriteLine("2. Nhan vien san xuat");
            Console.Write("Chon loai nhan vien (1 hoac 2): ");
            int loai = int.Parse(Console.ReadLine() ?? "1");

            NhanVien nv;
            if (loai == 1) nv = new NhanVienKinhDoanh();
            else nv = new NhanVienSanXuat();

            nv.Nhap();
            danhSachNV.Add(nv);
        }

        Console.WriteLine("\n--- DANH SACH LUONG NHAN VIEN ---");
        foreach (var nv in danhSachNV)
        {
            nv.Xuat();
        }
    }
}