using System;
using System.Collections.Generic;

public class ConsoleMenu
{
    protected List<string> danhSachChucNang = new List<string>();
    
    public event Action<int> Choose;

    public void AddOption(string option)
    {
        danhSachChucNang.Add(option);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            for (int i = 0; i < danhSachChucNang.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {danhSachChucNang[i]}");
            }
            Console.WriteLine("0. Thoat chuong trinh");
            
            Console.Write("Thuc hien: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine($"\n=> Ban thuc hien chuc nang {choice}");
                
                if (choice == 0) break; // Bấm 0 thì thoát vòng lặp Menu
                
                Choose?.Invoke(choice);
            }
            else
            {
                Console.WriteLine("Vui long nhap so hop le!");
            }
        }
    }
}

public class PTBac2Console : ConsoleMenu
{
    public PTBac2Console()
    {
        // Khởi tạo các menu item cho bài toán này
        AddOption("Giai phuong trinh bac 2 (ax^2 + bx + c = 0)");
        AddOption("Gioi thieu ung dung");

        // Đăng ký Event xử lý ngay trong Constructor
        this.Choose += HandleMenuChoice;
    }

    private void HandleMenuChoice(int choice)
    {
        switch (choice)
        {
            case 1:
                GiaiPTBac2();
                break;
            case 2:
                Console.WriteLine("Day la chuong trinh Giai Phuong Trinh Bac 2 ke thua tu ConsoleMenu.");
                break;
            default:
                Console.WriteLine("Chuc nang khong ton tai!");
                break;
        }
    }

    private void GiaiPTBac2()
    {
        Console.Write("Nhap he so a: ");
        double a = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap he so b: ");
        double b = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap he so c: ");
        double c = double.Parse(Console.ReadLine() ?? "0");

        if (a == 0)
        {
            Console.WriteLine("Day khong phai la phuong trinh bac 2 (a phai khac 0).");
            return;
        }

        double delta = b * b - 4 * a * c;
        if (delta < 0)
            Console.WriteLine("Phuong trinh vo nghiem.");
        else if (delta == 0)
            Console.WriteLine($"Phuong trinh co nghiem kep x1 = x2 = {-b / (2 * a)}");
        else
            Console.WriteLine($"Phuong trinh co 2 nghiem: x1 = {(-b + Math.Sqrt(delta)) / (2 * a):F2}, x2 = {(-b - Math.Sqrt(delta)) / (2 * a):F2}");
    }
}

class Program
{
    static void Main()
    {
        PTBac2Console app = new PTBac2Console();
        app.Run();
    }
}