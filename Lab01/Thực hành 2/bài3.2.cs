using System;

class Sorter
{
    public static void MySort<T>(T[] arr) where T : IComparable<T>
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                // Nếu arr[i] > arr[j] thì hoán vị
                if (arr[i].CompareTo(arr[j]) > 0)
                {
                    T temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        int[] numbers = { 5, 1, 4, 2, 8 };
        Sorter.MySort(numbers);
        Console.WriteLine("Mang so nguyen sau khi dung MySort: " + string.Join(", ", numbers));
    }
}