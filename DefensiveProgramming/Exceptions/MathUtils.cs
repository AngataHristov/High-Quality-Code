using System;
using System.Collections.Generic;
using System.Text;

class MathUtils
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentException("Array cannot be null");
        }

        if (count < 0)
        {
            throw new ArgumentException("Invalid count value.");
        }

        List<T> result = new List<T>();

        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count < 0)
        {
            throw new ArgumentException("Invalid count value.");
        }

        if (count > str.Length)
        {
            count = str.Length;
        }

        StringBuilder result = new StringBuilder();

        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentException("Number cannot be less or equal to zero.");
        }

        bool isPrime = true;

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = false;
                break;
            }
        }

        return isPrime;
    }
}
