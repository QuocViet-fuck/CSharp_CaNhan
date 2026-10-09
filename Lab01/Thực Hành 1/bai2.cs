using System;

namespace natl_CSharp.Tuan2.TH01.bai2
{
    class bai2
    {
        public static void Main(string []args)
        {
            Console.Write("Nhap ho ten cua ban: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"Chao ban {name}!");

            Console.Read();
        }
    }
}
