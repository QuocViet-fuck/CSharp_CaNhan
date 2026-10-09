using System;

class DaySo
{
    private int[] arr;
    public int Length => arr.Length;

    public DaySo(int n) { arr = new int[n]; }
    public DaySo(int[] a) { arr = (int[])a.Clone(); }

    // Indexer
    public int this[int i]
    {
        get => arr[i];
        set => arr[i] = value;
    }

    public void Nhap()
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"Nhap phan tu thu {i}: ");
            arr[i] = int.Parse(Console.ReadLine() ?? "0");
        }
    }

    public void Xuat()
    {
        Console.WriteLine("Day so: " + string.Join(", ", arr));
    }

    public void TimSoChan()
    {
        Console.Write("Cac so chan trong day: ");
        foreach (int x in arr)
        {
            if (x % 2 == 0) Console.Write(x + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so luong phan tu cua day so (n): ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        DaySo ds = new DaySo(n);
        
        Console.WriteLine("--- Nhap du lieu ---");
        ds.Nhap();

        Console.WriteLine("\n--- Ket qua ---");
        ds.Xuat();
        ds.TimSoChan();
    }
}