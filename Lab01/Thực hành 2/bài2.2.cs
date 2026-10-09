using System;
using System.Collections.Generic;

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

class PersonList
{
    private List<Person> ds;

    public PersonList() { ds = new List<Person>(); }
    
    public PersonList(PersonList other) 
    {
        ds = new List<Person>();
        foreach(var p in other.ds) ds.Add(new Person(p)); 
    }
    
    public void Add(Person x) => ds.Add(x);
    
    public void Output()
    {
        foreach(var p in ds) p.Output();
    }

    public PersonList LivingPeople()
    {
        PersonList kq = new PersonList();
        foreach(var p in ds) 
        {
            if (p.IsLiving()) kq.Add(p);
        }
        return kq;
    }
}

class Program
{
    static void Main(string[] args)
    {
        PersonList danhSach = new PersonList();
        
        Console.WriteLine("--- Nhap thong tin nguoi thu 1 ---");
        Person p1 = new Person();
        p1.Input();
        danhSach.Add(p1);

        Console.WriteLine("\n--- Nhap thong tin nguoi thu 2 ---");
        Person p2 = new Person();
        p2.Input();
        danhSach.Add(p2);

        Console.WriteLine("\n--- TONG DANH SACH ---");
        danhSach.Output();

        Console.WriteLine("\n--- DANH SACH NGUOI CON SONG ---");
        PersonList dsConSong = danhSach.LivingPeople();
        dsConSong.Output();
    }
}