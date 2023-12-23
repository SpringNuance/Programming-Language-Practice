using System;

namespace ArrayExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an array of integers
            int[] numbers = { 1, 2, 3, 4, 5 };

            // Use a for loop to iterate over the array
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
