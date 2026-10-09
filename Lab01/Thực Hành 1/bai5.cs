using System;

namespace natl_CSharp.Tuan2.TH01.bai5
{
    class bai5
    {
        public static void Main(string []args)
        {
            double x = 0, y = 0;
        bool daNhap = false;

        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
            Console.WriteLine("2. Tinh x^y");
            Console.WriteLine("3. Tinh can bac 2 cua x va y");
            Console.WriteLine("4. Thoat");
            Console.Write("Chon chuc nang: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Nhap x: ");
                    while (!double.TryParse(Console.ReadLine(), out x))
                        Console.Write("Nhap lai x (so thuc): ");

                    Console.Write("Nhap y: ");
                    while (!double.TryParse(Console.ReadLine(), out y))
                        Console.Write("Nhap lai y (so thuc): ");

                    daNhap = true;
                    break;

                case "2":
                    if (!daNhap) { Console.WriteLine("Vui long chon chuc nang 1 de nhap x, y truoc!"); break; }
                    Console.WriteLine($"Ket qua {x}^{y} = {Math.Pow(x, y)}");
                    break;

                case "3":
                    if (!daNhap) { Console.WriteLine("Vui long chon chuc nang 1 de nhap x, y truoc!"); break; }
                    Console.WriteLine(x >= 0 ? $"Can bac 2 cua x ({x}) = {Math.Sqrt(x)}" : "x < 0, khong tinh duoc can bac 2 thuc.");
                    Console.WriteLine(y >= 0 ? $"Can bac 2 cua y ({y}) = {Math.Sqrt(y)}" : "y < 0, khong tinh duoc can bac 2 thuc.");
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Lieu chon khong hop le!");
                    break;
            }
        }

        Console.Read();
        }
    }
}
