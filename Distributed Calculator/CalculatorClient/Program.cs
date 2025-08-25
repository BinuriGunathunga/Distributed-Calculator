// using System;

// class Program
// {
//     static void Main()
//     {
       
//         int a = 15;
//         int b = 70;
//         int sum = a + b;

//         Console.WriteLine($"Sum of {a} and {b} is: {sum}");
//     }
// }



using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int sum = a + b;

        Console.WriteLine($"Sum of {a} and {b} is: {sum}");
    }
}
