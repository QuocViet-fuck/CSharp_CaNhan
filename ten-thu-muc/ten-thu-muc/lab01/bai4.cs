using System;

namespace natl_CSharp.Tuan2.TH01.bai4
{
    class bai4
    {
        public static void Main(string []args)
        {
            Console.Write("Nhap so nguyen x: ");
            bool validX = int.TryParse(Console.ReadLine(), out int x);

            Console.Write("Nhap so nguyen y: ");
            bool validY = int.TryParse(Console.ReadLine(), out int y);

            if (!validX || !validY)
            {
                Console.WriteLine("Loi: Gia tri nhap vao khong phai la so nguyen!");
            }
            else
            {
                long result = (long)Math.Pow(x, y);
                Console.WriteLine($"Ket qua {x} mu {y} la: {result}");
            }

            Console.Read();
        }
    }
}
