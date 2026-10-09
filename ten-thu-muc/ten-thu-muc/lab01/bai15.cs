using System;
using System.Collections.Generic;

namespace natl_CSharp.Tuan2.TH01.bai15
{
    class bai15
    {
        public static void Main(string []args)
        {
            int n;
            int[] a = NhapMang(out n);
            InMang(a);
            TimMinMax(a, out int max, out int min);
            Console.WriteLine($"Gia tri lon nhat: {max}, Gia tri nho nhat: {min}");
            int[] mangNguyenTo = LayMangNguyenTo(a);
            InMang(mangNguyenTo);

            Console.Read();
        }

        public static int[] NhapMang(out int n)
        {
            Console.Write("Nhap so phan tu n: ");
            n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = int.Parse(Console.ReadLine());
            }
            return a;
        }

        public static void InMang(int[] a)
        {
            Console.WriteLine("Cac phan tu trong mang: " + string.Join(" ", a));
        }

        public static void TimMinMax(int[] a, out int max, out int min)
        {
            max = a[0];
            min = a[0];
            foreach (int item in a)
            {
                if (item > max) max = item;
                if (item < min) min = item;
            }
        }
        public static bool KiemTraNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        public static int[] LayMangNguyenTo(int[] a)
        {
            List<int> list = new List<int>();
            foreach (int item in a)
            {
                if (KiemTraNguyenTo(item))
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }
    }
}