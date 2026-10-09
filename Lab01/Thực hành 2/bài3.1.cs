using System;

class SinhVien : IComparable<SinhVien>
{
    public string Ten { get; set; }
    public double Diem { get; set; }

    public SinhVien(string ten, double diem) { Ten = ten; Diem = diem; }

    public override string ToString() => $"{Ten} - {Diem} diem";

    public int CompareTo(SinhVien other)
    {
        // Sắp xếp tăng dần theo điểm
        return this.Diem.CompareTo(other.Diem); 
    }
}

class Program
{
    static void Main()
    {
        SinhVien[] ds = {
            new SinhVien("An", 8.5),
            new SinhVien("Binh", 6.0),
            new SinhVien("Cuong", 9.0)
        };

        Console.WriteLine("--- Truoc khi sap xep ---");
        foreach (var sv in ds) Console.WriteLine(sv);

        Array.Sort(ds);

        Console.WriteLine("\n--- Sau khi sap xep bang Array.Sort (Bai 3.1) ---");
        foreach (var sv in ds) Console.WriteLine(sv);
    }
}