using System;

class SorterDelegate
{
    public static void DelegateSort<T>(T[] arr, Comparison<T> compareFunc)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (compareFunc(arr[i], arr[j]) > 0)
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
        string[] names = { "Nam", "An", "Binh" };

        SorterDelegate.DelegateSort(names, (x, y) => x.CompareTo(y));
        
        Console.WriteLine("Mang chuoi sap xep bang Delegate: " + string.Join(", ", names));
    }
}