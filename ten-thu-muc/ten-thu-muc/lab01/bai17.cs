using System;

namespace natl_CSharp.Tuan2.TH01.bai17
{
    class bai17
    {
        public static void Main(string []args)
        {
            Console.Write("Nhap so dong n: ");
            bool validN = int.TryParse(Console.ReadLine(), out int n);

            Console.Write("Nhap so cot m: ");
            bool validM = int.TryParse(Console.ReadLine(), out int m);

            if (!validN || !validM || n <= 0 || m <= 0)
            {
                Console.WriteLine("Loi: Gia tri nhap vao khong hop le!");
                return;
            }

            int[,] A = SinhMangNgauNhien(n, m);
            InMang(A);

            TachMangChanLe(A, out int[] mangChan, out int[] mangLe);

            Console.WriteLine("\nMang chan:");
            Console.WriteLine(string.Join(", ", mangChan));

            Console.WriteLine("\nMang le:");
            Console.WriteLine(string.Join(", ", mangLe));

            Console.Read();
        }

        public static int[,] SinhMangNgauNhien(int n, int m)
        {
            Random rand = new Random();
            int[,] A = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    A[i, j] = rand.Next(10, 101); // Sinh ngẫu nhiên trong đoạn [10, 100]
                }
            }
            return A;
        }

        public static void InMang(int[,] A)
        {
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            Console.WriteLine($"--- Ma tran A[{n}x{m}] ---");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{A[i, j],6}");
                }
                Console.WriteLine();
            }
        }

        public static void TachMangChanLe(int[,] A, out int[] mangChan, out int[] mangLe)
        {
            List<int> listChan = new List<int>();
            List<int> listLe = new List<int>();

            foreach (int item in A)
            {
                if (item % 2 == 0) listChan.Add(item);
                else listLe.Add(item);
            }

            mangChan = listChan.ToArray();
            mangLe = listLe.ToArray();
        }
    }
}
