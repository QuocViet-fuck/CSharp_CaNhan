using System;

namespace natl_CSharp.Tuan2.TH01.bai16
{
    class bai16
    {
        public static void Main(string []args)
        {
            Run();
            Console.Read();
        }
        public static void Run()
        {
            Console.Write("Nhap so luong nguoi n: ");
            int n = int.Parse(Console.ReadLine());
            string[] dsHoTen = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhap ho ten nguoi thu {i + 1}: ");
                dsHoTen[i] = Console.ReadLine();
            }

            Array.Sort(dsHoTen);

            Console.WriteLine("\nDanh sach ho ten sau khi sap xep tăng dan:");
            foreach (string hoTen in dsHoTen)
            {
                Console.WriteLine(hoTen);
            }
        }
    }
}
