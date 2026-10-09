using System;
using System.Collections;

class Point
{
    public double X { get; set; }
    public double Y { get; set; }
    
    public Point() { X = 0; Y = 0; }
    public Point(double x, double y) { X = x; Y = y; }
    
    public override string ToString() => $"({X}, {Y})";
}

class ArrayPoint
{
    private ArrayList points;

    public ArrayPoint()
    {
        points = new ArrayList();
    }

    public void Add(Point p) => points.Add(p);

    // Indexer
    public Point this[int index]
    {
        get { return (Point)points[index]; }
        set { points[index] = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArrayPoint danhSach = new ArrayPoint();
        
        danhSach.Add(new Point(1.5, 2.5));
        danhSach.Add(new Point(3, 4));

        // Dùng Indexer (danhSach[0]) để lấy ra và in kết quả
        Console.WriteLine("Diem thu 1: " + danhSach[0].ToString());
        Console.WriteLine("Diem thu 2: " + danhSach[1].ToString());
    }
}