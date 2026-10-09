using System;

class DonThuc
{
    public double HeSo { get; set; }
    public int SoMu { get; set; }

    public DonThuc(double heSo, int soMu)
    {
        HeSo = heSo;
        SoMu = soMu;
    }

    public double TinhGiaTri(double x)
    {
        return HeSo * Math.Pow(x, SoMu);
    }
}

class DaThuc
{
    private DonThuc[] dsDonThuc;
    public int Bac { get; private set; }

    // a. Constructor
    public DaThuc(int n)
    {
        Bac = n;
        dsDonThuc = new DonThuc[n + 1];
    }

    public DonThuc this[int i]
    {
        get => dsDonThuc[i];
        set => dsDonThuc[i] = value;
    }

    public void Nhap()
    {
        for (int i = 0; i <= Bac; i++)
        {
            Console.Write($"Nhap he so a_{i} (cho x^{i}): ");
            double heSo = double.Parse(Console.ReadLine() ?? "0");
            dsDonThuc[i] = new DonThuc(heSo, i);
        }
    }

    public void Xuat()
    {
        Console.Write("P(x) = ");
        for (int i = 0; i <= Bac; i++)
        {
            if (dsDonThuc[i].HeSo != 0)
            {
                if (i > 0 && dsDonThuc[i].HeSo > 0) Console.Write(" + ");
                else if (dsDonThuc[i].HeSo < 0) Console.Write(" - ");

                Console.Write($"{Math.Abs(dsDonThuc[i].HeSo)}x^{i}");
            }
        }
        Console.WriteLine();
    }

    public double TinhGiaTri(double x)
    {
        double tong = 0;
        for (int i = 0; i <= Bac; i++)
        {
            tong += dsDonThuc[i].TinhGiaTri(x);
        }
        return tong;
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Nhap bac cua da thuc (n): ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        DaThuc p = new DaThuc(n);
        
        Console.WriteLine("--- Nhap cac he so ---");
        p.Nhap();
        
        Console.WriteLine("\n--- Da thuc vua nhap ---");
        p.Xuat();

        Console.Write("\nNhap gia tri x can tinh: ");
        double x = double.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine($"Gia tri cua P({x}) = {p.TinhGiaTri(x)}");
    }
}