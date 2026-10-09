using System;

class Point
{
    private double x, y;

    public double X { get { return x; } set { x = value; } }
    public double Y { get { return y; } set { y = value; } }

    public Point() { x = 0; y = 0; }
    public Point(double x, double y) { this.x = x; this.y = y; }

    public void Input()
    {
        Console.Write("Nhap toa do X: "); 
        x = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nhap toa do Y: "); 
        y = double.Parse(Console.ReadLine() ?? "0");
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"({x}, {y})";
    }

    public static Point operator +(Point a, Point b) => new Point(a.x + b.x, a.y + b.y);
    public static Point operator -(Point a, Point b) => new Point(a.x - b.x, a.y - b.y);
    public static Point operator -(Point a) => new Point(-a.x, -a.y);

    public double DistanceTo(Point other) => Math.Sqrt(Math.Pow(this.x - other.x, 2) + Math.Pow(this.y - other.y, 2));
    public static double Distance(Point a, Point b) => Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));

    public Point MidpointWith(Point other) => new Point((this.x + other.x) / 2, (this.y + other.y) / 2);
    public static Point Midpoint(Point a, Point b) => new Point((a.x + b.x) / 2, (a.y + b.y) / 2);
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Nhap diem A ---");
        Point pA = new Point();
        pA.Input();

        Console.WriteLine("--- Nhap diem B ---");
        Point pB = new Point();
        pB.Input();

        Console.Write("Diem A: "); pA.Output();
        Console.Write("Diem B: "); pB.Output();

        Console.WriteLine($"Khoang cach A va B: {Point.Distance(pA, pB)}");
        
        Point trungDiem = Point.Midpoint(pA, pB);
        Console.WriteLine($"Trung diem cua A va B: {trungDiem.ToString()}");
    }
}