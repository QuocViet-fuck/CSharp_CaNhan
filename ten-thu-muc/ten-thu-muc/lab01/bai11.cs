using System;

namespace natl_CSharp.Tuan2.TH01.bai11
{
    class bai11
    {
        public static string DaoChuoi(string str)
        {
            if (str == null) return null;
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static void Main()
        {
            Console.Write("Nhap chuoi: ");
            string input = Console.ReadLine() ?? string.Empty;

            string daoChuoi = DaoChuoi(input);
            Console.WriteLine($"Chuoi sau khi dao nguoc: {daoChuoi}");

            Console.Read();
        }
    }
}