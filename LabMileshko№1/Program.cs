using System;

public class HW1
{
    static int Min_Index(int[] A)
    {
        int min = 0;
        for(int i=1;i<A.Length;i++)
        {
            if (A[i] < A[min]) min = i;
        }
        return min;
    }
    static int Max_Value(int[] A)
    {
        int max = 0;
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] > A[max]) max = i;
        }
        return A[max];
    }
    public static long QueueTime(int[] customers, int n)
    {
        int[] A = new int[n];
        long value = 0;
        int index;
        for (int i = 0; i < n; i++) A[i] = 0;
        for(int i = 0; i < customers.Length; i++) 
        {
            index = Min_Index(A);
            try
            {
                //Я хочу с экономить память, но будет небольшой проигрыш по производительности
                A[index] += customers[i];
            }
            catch
            {
                value += A[index];
                for(int j=0;j<A.Length;j++)
                {
                    A[j] -= A[index];
                }
                A[index] = customers[i];
            }
        }
        value += Max_Value(A);
        return value;
    }
}

class Program
{
    static void Main()
    {
        int[] Cust = { 5, 3, 4 };
        Console.WriteLine(HW1.QueueTime(Cust, 1));
        //вернёт 12
        Cust = new int[] { 10, 2, 3, 3 };
        Console.WriteLine(HW1.QueueTime(Cust, 2));
        //вернёт 10
        Console.WriteLine(HW1.QueueTime(new int[] { 2, 3, 10 }, 2));
        //вернёт 12
        Console.ReadLine();
    }
}
