using System;

class SinhVien
{
    public string HoTen = ""; 
    public int NamSinh;

    public void Nhap()
    {
        Console.Write("Nhap ho ten sinh vien: ");
        HoTen = Console.ReadLine() ?? ""; 
        
        Console.Write("Nhap nam sinh: ");
        NamSinh = int.Parse(Console.ReadLine() ?? "0"); 
    }

    public void XuatTuoi()
    {
        int tuoi = DateTime.Now.Year - NamSinh;
        Console.WriteLine($"Sinh vien {HoTen} nam nay {tuoi} tuoi.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo một sinh viên mới và gọi các hàm
        SinhVien sv = new SinhVien();
        sv.Nhap();
        sv.XuatTuoi();
    }
}