using System;

class Mang2Chieu
{
    private int[,] arr;
    private int soDong, soCot;

    public Mang2Chieu(int n, int m) 
    { 
        soDong = n; 
        soCot = m; 
        arr = new int[n, m]; 
    }

    public int this[int i, int j]
    {
        get => arr[i, j];
        set => arr[i, j] = value;
    }

    public void Nhap()
    {
        for (int i = 0; i < soDong; i++)
            for (int j = 0; j < soCot; j++)
            {
                Console.Write($"Nhap phan tu [{i},{j}]: ");
                arr[i, j] = int.Parse(Console.ReadLine() ?? "0");
            }
    }

    private bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
            if (number % i == 0) return false;
        return true;
    }

    public void TimSoNguyenTo()
    {
        Console.Write("Cac so nguyen to trong mang: ");
        for (int i = 0; i < soDong; i++)
            for (int j = 0; j < soCot; j++)
                if (IsPrime(arr[i, j])) 
                    Console.Write(arr[i, j] + " ");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so dong (n): ");
        int n = int.Parse(Console.ReadLine() ?? "0");
        
        Console.Write("Nhap so cot (m): ");
        int m = int.Parse(Console.ReadLine() ?? "0");

        Mang2Chieu mang = new Mang2Chieu(n, m);
        
        Console.WriteLine("--- Nhap du lieu mang ---");
        mang.Nhap();

        Console.WriteLine("\n--- Ket qua ---");
        mang.TimSoNguyenTo();
    }
}