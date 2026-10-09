using System;

class PhanSo
{
    public int TuSo { get; set; }
    public int MauSo { get; set; }

    public PhanSo() { TuSo = 0; MauSo = 1; }
    public PhanSo(int tu, int mau) { TuSo = tu; MauSo = mau == 0 ? 1 : mau; }
    public PhanSo(PhanSo p) { TuSo = p.TuSo; MauSo = p.MauSo; }

    public override string ToString() => $"{TuSo}/{MauSo}";

    public static PhanSo operator +(PhanSo a) => a;
    public static PhanSo operator -(PhanSo a) => new PhanSo(-a.TuSo, a.MauSo);

    public static PhanSo operator +(PhanSo a, PhanSo b) => new PhanSo(a.TuSo * b.MauSo + b.TuSo * a.MauSo, a.MauSo * b.MauSo);
    public static PhanSo operator -(PhanSo a, PhanSo b) => new PhanSo(a.TuSo * b.MauSo - b.TuSo * a.MauSo, a.MauSo * b.MauSo);
    public static PhanSo operator *(PhanSo a, PhanSo b) => new PhanSo(a.TuSo * b.TuSo, a.MauSo * b.MauSo);
    public static PhanSo operator /(PhanSo a, PhanSo b) => new PhanSo(a.TuSo * b.MauSo, a.MauSo * b.TuSo);

    public static bool operator ==(PhanSo a, PhanSo b) => (a.TuSo * b.MauSo) == (b.TuSo * a.MauSo);
    public static bool operator !=(PhanSo a, PhanSo b) => !(a == b);
    public static bool operator >(PhanSo a, PhanSo b) => (a.TuSo * b.MauSo) > (b.TuSo * a.MauSo);
    public static bool operator <(PhanSo a, PhanSo b) => (a.TuSo * b.MauSo) < (b.TuSo * a.MauSo);
    public static bool operator >=(PhanSo a, PhanSo b) => (a.TuSo * b.MauSo) >= (b.TuSo * a.MauSo);
    public static bool operator <=(PhanSo a, PhanSo b) => (a.TuSo * b.MauSo) <= (b.TuSo * a.MauSo);
    
    // Thêm các hàm bắt buộc khi dùng toán tử == để tránh cảnh báo
    public override bool Equals(object obj) => obj is PhanSo so && this == so;
    public override int GetHashCode() => HashCode.Combine(TuSo, MauSo);
}

class Program
{
    static void Main(string[] args)
    {
        PhanSo ps1 = new PhanSo(1, 2); // 1/2
        PhanSo ps2 = new PhanSo(3, 4); // 3/4

        Console.WriteLine($"Phan so 1: {ps1}");
        Console.WriteLine($"Phan so 2: {ps2}");

        Console.WriteLine($"Cong: {ps1} + {ps2} = {ps1 + ps2}");
        Console.WriteLine($"Tru: {ps1} - {ps2} = {ps1 - ps2}");
        Console.WriteLine($"Nhan: {ps1} * {ps2} = {ps1 * ps2}");
        
        if (ps2 > ps1) Console.WriteLine($"{ps2} lon hon {ps1}");
    }
}
