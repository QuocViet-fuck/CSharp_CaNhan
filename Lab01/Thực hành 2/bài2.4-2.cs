using System;

class PhanSo
{
    public int TuSo { get; set; }
    public int MauSo { get; set; }

    public PhanSo(int tu, int mau) { TuSo = tu; MauSo = mau == 0 ? 1 : mau; }

    // Quá tải toán tử cộng
    public static PhanSo operator +(PhanSo a, PhanSo b)
    {
        int tuMoi = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
        int mauMoi = a.MauSo * b.MauSo;
        return new PhanSo(tuMoi, mauMoi).RutGon();
    }

    private int UCLN(int a, int b)
    {
        a = Math.Abs(a); b = Math.Abs(b);
        while (a != 0 && b != 0) { if (a > b) a %= b; else b %= a; }
        return a | b;
    }

    public PhanSo RutGon()
    {
        int ucln = UCLN(TuSo, MauSo);
        return new PhanSo(TuSo / ucln, MauSo / ucln);
    }

    public override string ToString() => MauSo == 1 ? $"{TuSo}" : $"{TuSo}/{MauSo}";
}

class DayPhanSo
{
    private PhanSo[] ds;

    public DayPhanSo(int n)
    {
        ds = new PhanSo[n];
    }

    public void Nhap()
    {
        for (int i = 0; i < ds.Length; i++)
        {
            Console.WriteLine($"--- Nhap phan so thu {i + 1} ---");
            Console.Write("Tu so: ");
            int tu = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Mau so: ");
            int mau = int.Parse(Console.ReadLine() ?? "1");
            ds[i] = new PhanSo(tu, mau);
        }
    }

    public void Xuat()
    {
        Console.Write("Day phan so: ");
        Console.WriteLine(string.Join(", ", (object[])ds));
    }

    public PhanSo TinhTong()
    {
        PhanSo tong = new PhanSo(0, 1); // Khởi tạo tổng = 0
        for (int i = 0; i < ds.Length; i++)
        {
            tong = tong + ds[i]; // Sử dụng toán tử + đã overload
        }
        return tong;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Nhap so luong phan so (n): ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        DayPhanSo dayPS = new DayPhanSo(n);
        dayPS.Nhap();
        
        Console.WriteLine("\n--- Ket qua ---");
        dayPS.Xuat();
        Console.WriteLine($"Tong day phan so la: {dayPS.TinhTong()}");
    }
}