using System;

namespace natl_CSharp.Tuan2.TH01.bai1
{
    class bai1
    {
        public static void Main(string []args)
        {
            Console.Write("Nhap ho ten: ");
            string hoTen = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Ho ten vua nhap: " + hoTen);
        }
    }
}
