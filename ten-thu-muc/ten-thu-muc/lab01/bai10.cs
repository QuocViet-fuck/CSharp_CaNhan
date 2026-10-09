using System;

namespace natl_CSharp.Tuan2.TH01.bai10
{
    class bai10
    {
        public static bool KiemTraDoiXung(string str)
        {
            if (string.IsNullOrEmpty(str)) return true;
            int i = 0, j = str.Length - 1;
            while (i < j)
            {
                if (str[i] != str[j]) return false;
                i++;
                j--;
            }
            return true;
        }
        public static void Main()
        {
            Console.Write("Nhap chuoi: ");
            string input = Console.ReadLine() ?? string.Empty;

            if (KiemTraDoiXung(input))
                Console.WriteLine($"Chuoi '{input}' la chuoi doi xung.");
            else
                Console.WriteLine($"Chuoi '{input}' khong phai la chuoi doi xung.");

            Console.Read();
        }
    }
}