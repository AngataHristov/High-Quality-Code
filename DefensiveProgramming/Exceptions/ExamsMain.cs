using System;
using System.Collections.Generic;

class ExamsMain
{
    private static void Main()
    {
        var substr = MathUtils.Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = MathUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = MathUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = MathUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(MathUtils.ExtractEnding("I love C#", 2));
        Console.WriteLine(MathUtils.ExtractEnding("Nakov", 4));
        Console.WriteLine(MathUtils.ExtractEnding("beer", 4));
        Console.WriteLine(MathUtils.ExtractEnding("Hi", 100));

        var validPrime = 23;

        try
        {
            var isPrime = MathUtils.CheckPrime(validPrime);

            Console.WriteLine(validPrime + " is prime: " + isPrime);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        var invalidNumber = -23;

        try
        {
            var isPrime = MathUtils.CheckPrime(invalidNumber);

            Console.WriteLine(validPrime + " is prime: " + isPrime);

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}