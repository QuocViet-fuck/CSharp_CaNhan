using System;

namespace natl_CSharp.Tuan2.TH01.bai8
{
    class bai8
    {
        public static void HoanVi(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }
        public static void Main()
        {
            Console.Write("Nhap so thuc a: ");
            bool validA = double.TryParse(Console.ReadLine(), out double a);

            Console.Write("Nhap so thuc b: ");
            bool validB = double.TryParse(Console.ReadLine(), out double b);

            if (!validA || !validB)
            {
                Console.WriteLine("Loi: Gia tri nhap vao khong phai la so thuc!");
            }
            else
            {
                HoanVi(ref a, ref b);
                Console.WriteLine($"Sau khi hoan vi: a = {a}, b = {b}");
            }

            Console.Read();
        }
    }
}