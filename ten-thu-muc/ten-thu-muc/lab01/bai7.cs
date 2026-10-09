using System;

namespace natl_CSharp.Tuan2.TH01.bai7
{
    class bai7
    {
        public static bool KiemTraNguyenTo(int n){
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        public static void Main()
        {
            Console.Write("Nhap so nguyen n: ");
            bool validN = int.TryParse(Console.ReadLine(), out int n);

            if (!validN)
            {
                Console.WriteLine("Loi: Gia tri nhap vao khong phai la so nguyen!");
            }
            else
            {
                if (KiemTraNguyenTo(n))
                    Console.WriteLine($"{n} la so nguyen to.");
                else
                    Console.WriteLine($"{n} khong phai la so nguyen to.");
            }

            Console.Read();
        }
    }
}