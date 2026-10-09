using System;

namespace natl_CSharp.Tuan2.TH01.bai3
{
    class bai3  
    {
        public static void Main(string []args)
        {
            Console.Write("Nhap so nguyen x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine());

            long result = (long)Math.Pow(x, y);
            Console.WriteLine($"Ket qua {x} mu {y} la: {result}");

            Console.Read();
        }
    }
}
