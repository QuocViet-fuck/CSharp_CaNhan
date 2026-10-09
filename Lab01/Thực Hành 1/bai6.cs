using System;

namespace natl_CSharp.Tuan2.TH01.bai6
{
    class bai6
    {
        public static int TimMax(int a, int b, int c){
            return Math.Max(a, Math.Max(b, c));
        }

        public static void Main()
        {
            Console.Write("Nhap so nguyen a: ");
            bool validA = int.TryParse(Console.ReadLine(), out int a);

            Console.Write("Nhap so nguyen b: ");
            bool validB = int.TryParse(Console.ReadLine(), out int b);

            Console.Write("Nhap so nguyen c: ");
            bool validC = int.TryParse(Console.ReadLine(), out int c);

            if (!validA || !validB || !validC)
            {
                Console.WriteLine("Loi: Gia tri nhap vao khong phai la so nguyen!");
            }
            else
            {
                int max = TimMax(a, b, c);
                Console.WriteLine($"So lon nhat trong 3 so {a}, {b}, {c} la: {max}");
            }

            Console.Read();
        }
    }
}