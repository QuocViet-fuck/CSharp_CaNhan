using System;

namespace natl_CSharp.Tuan2.TH01.bai12
{
    class bai12
    {
        public static void XuLyChuoi(string str)
        {
            Console.WriteLine("Chuoi chu thuong: " + str.ToLower());
            Console.WriteLine("Chuoi chu hoa: " + str.ToUpper());

            string[] tu = str.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("So tu trong chuoi: " + tu.Length);
        }
        public static void Main()
        {
            Console.Write("Nhap chuoi: ");
            string input = Console.ReadLine() ?? string.Empty;

            XuLyChuoi(input);

            Console.Read();
        }
    }
}