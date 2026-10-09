using System;

namespace natl_CSharp.Tuan2.TH01.bai9
{
    class bai9
    {
        public static void TimMinMax(double a, double b, double c, out double max, out double min)
        {
            max = Math.Max(a, Math.Max(b, c));
            min = Math.Min(a, Math.Min(b, c));
        }
        public static void Main()
        {
            Console.Write("Nhap so thuc a: ");
            bool validA = double.TryParse(Console.ReadLine(), out double a);

            Console.Write("Nhap so thuc b: ");
            bool validB = double.TryParse(Console.ReadLine(), out double b);

            Console.Write("Nhap so thuc c: ");
            bool validC = double.TryParse(Console.ReadLine(), out double c);

            if (!validA || !validB || !validC)
            {
                Console.WriteLine("Loi: Gia tri nhap vao khong phai la so thuc!");
            }
            else
            {
                TimMinMax(a, b, c, out double max, out double min);
                Console.WriteLine($"So lon nhat trong 3 so {a}, {b}, {c} la: {max}");
                Console.WriteLine($"So nho nhat trong 3 so {a}, {b}, {c} la: {min}");
            }

            Console.Read();
        }
    }
}