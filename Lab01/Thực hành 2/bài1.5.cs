using System;

class DonThuc
{
    public double a { get; set; }
    public int n { get; set; }

    public DonThuc(double a, int n)
    {
        this.a = a;
        this.n = Math.Max(0, n); // Đảm bảo số mũ n không âm
    }

    // (a) Tính giá trị đơn thức
    public double TinhGiaTri(double x)
    {
        return a * Math.Pow(x, n);
    }

    // (b) Đạo hàm đơn thức
    public DonThuc DaoHam()
    {
        if (n == 0) return new DonThuc(0, 0); // Đạo hàm của hằng số là 0
        return new DonThuc(a * n, n - 1);
    }

    public override string ToString() => $"{a}x^{n}";
}

class Program
{
    static void Main()
    {
        DonThuc dt = new DonThuc(3, 2); // 3x^2
        Console.WriteLine($"Don thuc P(x) = {dt}");
        Console.WriteLine($"Gia tri tai x = 2 la: {dt.TinhGiaTri(2)}"); // 3 * 2^2 = 12
        
        DonThuc daoHam = dt.DaoHam();
        Console.WriteLine($"Dao ham Q(x) = {daoHam}"); // 6x^1
    }
}