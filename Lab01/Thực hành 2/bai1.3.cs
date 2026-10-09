using System;

class Person
{
    private string id = "";
    private string name = "";
    private int yob;
    private int yod;

    public Person() { id = ""; name = ""; yob = 0; yod = 0; }
    public Person(Person other) 
    { 
        this.id = other.id; this.name = other.name; 
        this.yob = other.yob; this.yod = other.yod; 
    }

    public void Input()
    {
        Console.Write("Nhap ID: "); id = Console.ReadLine() ?? "";
        Console.Write("Nhap Ten: "); name = Console.ReadLine() ?? "";
        Console.Write("Nhap Nam sinh: "); yob = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap Nam mat (nhap 0 neu con song): "); yod = int.Parse(Console.ReadLine() ?? "0");
    }

    public void Output()
    {
        Console.WriteLine($"ID: {id} | Ten: {name} | Nam sinh: {yob} | Nam mat: {(yod == 0 ? "Con song" : yod.ToString())}");
    }

    public bool IsLiving()
    {
        return yod == 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person nguoi1 = new Person();
        Console.WriteLine("--- Nhap thong tin ---");
        nguoi1.Input();
        
        Console.WriteLine("\n--- Thong tin da nhap ---");
        nguoi1.Output();
        
        if (nguoi1.IsLiving())
            Console.WriteLine("Trang thai: Nguoi nay hien van dang song.");
        else
            Console.WriteLine("Trang thai: Nguoi nay da mat.");
    }
}
