using System;
using System.Collections.Generic;


class NhanVien
{
    public string HoTen { get; set; }
    public double MucLuong { get; set; }
    public int SoNgayVang { get; set; }

    public NhanVien() { HoTen = ""; }

    public void Nhap()
    {
        Console.Write("Nhap ho ten: ");
        HoTen = Console.ReadLine() ?? "";
        Console.Write("Nhap muc luong co ban: ");
        MucLuong = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap so ngay vang: ");
        SoNgayVang = int.Parse(Console.ReadLine() ?? "0");
    }

    public double TinhLuongThucLanh()
    {
        // Tính lương: Mức lương - (số ngày vắng * 100.000)
        double luongThuc = MucLuong - (SoNgayVang * 100000);
        // Trả về 0 nếu bị trừ âm lương
        return luongThuc > 0 ? luongThuc : 0; 
    }

    public void Xuat()
    {
        Console.WriteLine($"- {HoTen} | Luong CB: {MucLuong:N0} | Vang: {SoNgayVang} ngay | Thuc lanh: {TinhLuongThucLanh():N0} VND");
    }
}

class PhongBan
{
    private List<NhanVien> dsNhanVien;

    public PhongBan()
    {
        dsNhanVien = new List<NhanVien>();
    }

    public void NhapDanhSach(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Nhap nhan vien thu {i + 1} ---");
            NhanVien nv = new NhanVien();
            nv.Nhap();
            dsNhanVien.Add(nv);
        }
    }

    public void XuatDanhSach()
    {
        Console.WriteLine("\n--- DANH SACH NHAN VIEN ---");
        foreach (var nv in dsNhanVien)
        {
            nv.Xuat();
        }
    }

    public double TinhTongLuong()
    {
        double tong = 0;
        foreach (var nv in dsNhanVien)
        {
            tong += nv.TinhLuongThucLanh();
        }
        return tong;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Nhap so luong nhan vien trong phong ban (n): ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        PhongBan pb = new PhongBan();
        pb.NhapDanhSach(n);
        pb.XuatDanhSach();

        Console.WriteLine($"\n=> TONG LUONG CUA PHONG BAN: {pb.TinhTongLuong():N0} VND");
    }
}