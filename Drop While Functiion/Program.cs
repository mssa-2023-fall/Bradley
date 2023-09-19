using System;
using System.Linq.Expressions;

public class Program
{
    public static int[] DropWhile(int[] arr, Func<int, bool> pred)
    {
        int remove = 0;
        for (int i = 0; i < arr.Length; i++)
            if (!pred(arr[i]))
            {
                remove = i;
                break;
            }

        if (remove == 0)
            return new int[0];

        int[] result = arr[remove..];
        return result;
    }

}