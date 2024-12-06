using System;
using System.Diagnostics.SymbolStore;

#nullable enable
namespace Day05_G02
{
    internal class Program
    {
        static void Main()
        {
            // Task 1
            #region Task1
            try
            {
                Console.WriteLine("Enter first integer:");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter second integer:");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine($"Result: {a / b}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero.");
            }
            finally
            {
                Console.WriteLine("Operation complete");
            }
            // The purpose of the finally block is to execute code regardless of whether an exception is thrown or not.
            #endregion

            // Task 2
            #region Task2
            void TestDefensiveCode()
            {
                Console.WriteLine("Enter a positive integer for X:");
                int.TryParse(Console.ReadLine(), out int x);
                while (x <= 0)
                {
                    Console.WriteLine("Invalid input. Enter a positive integer for X:");
                    int.TryParse(Console.ReadLine(), out x);
                }

                Console.WriteLine("Enter a positive integer for Y (greater than 1):");
                int.TryParse(Console.ReadLine(), out int y);
                while (y <= 1)
                {
                    Console.WriteLine("Invalid input. Enter a positive integer for Y (greater than 1):");
                    int.TryParse(Console.ReadLine(), out y);
                }
            }
            // int.TryParse improves robustness by preventing exceptions due to invalid input format.
            #endregion

            // Task 3
            #region Task3
            int? nullableInt = null;
            int defaultValue = nullableInt ?? -1;
            Console.WriteLine($"Default value: {defaultValue}");
            if (nullableInt.HasValue)
            {
                Console.WriteLine($"Value: {nullableInt.Value}");
            }
            else
            {
                Console.WriteLine("nullableInt does not have a value.");
            }
            // Exception: InvalidOperationException occurs when accessing Value on a null Nullable<T>.
            #endregion

            // Task 4
            #region Task4
            int[] array = new int[5];
            try
            {
                Console.WriteLine(array[10]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index is out of bounds.");
            }
            // Checking array bounds prevents runtime errors.
            #endregion

            // Task 5
            #region Task5
            int[,] matrix = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"Enter value for matrix[{i},{j}]:");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < 3; i++)
            {
                int rowSum = 0, colSum = 0;
                for (int j = 0; j < 3; j++)
                {
                    rowSum += matrix[i, j];
                    colSum += matrix[j, i];
                }
                Console.WriteLine($"Sum of row {i}: {rowSum}");
                Console.WriteLine($"Sum of column {i}: {colSum}");
            }
            // GetLength(dimension) returns the size of the specified dimension in a multi-dimensional array.
            #endregion

            // Task 6
            
            #region Task6
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[2];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[4];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine($"Enter value for jaggedArray[{i}][{j}]:");
                    jaggedArray[i][j] = int.Parse(Console.ReadLine());
                }
            }

            foreach (var row in jaggedArray)
            {
                foreach (var value in row)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
            // Memory allocation differs as jagged arrays consist of arrays of arrays, whereas rectangular arrays are contiguous.
            #endregion

            // Task 7
            #region Task7
            string? nullableString = null;
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();
            nullableString = string.IsNullOrEmpty(input) ? null : input;
            Console.WriteLine(nullableString!);
            // Nullable reference types help avoid null reference exceptions by distinguishing between nullable and non-nullable types.
            #endregion

            // Task 8
            #region Task8
            int valueType = 10;
            object boxed = valueType; 
            try
            {
                int unboxed = (int)boxed;
                
                Console.WriteLine($"Unboxed value: {unboxed}");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Invalid cast during unboxing.");
            }
            // Boxing and unboxing incur performance overhead due to heap allocation and type checking.
            #endregion

            // Task 9
            #region Task9
            void SumAndMultiply(int x, int y, out int sum, out int product)
            {
                sum = x + y;
                product = x * y;
            }

            SumAndMultiply(3, 4, out int sumResult, out int productResult);
            Console.WriteLine($"Sum: {sumResult}, Product: {productResult}");
            // Out parameters must be initialized inside the method.
            #endregion

            // Task 10
            #region Task10
            void PrintStringMultipleTimes(string text, int times = 5)
            {
                for (int i = 0; i < times; i++)
                {
                    Console.WriteLine(text);
                }
            }

            PrintStringMultipleTimes(text: "Hello", times: 3);
            // Optional parameters must appear at the end of the parameter list to avoid ambiguity.
            #endregion

            // Task 11
            #region Task11
            int?[] nullableIntArray = null;
            Console.WriteLine(nullableIntArray?.Length ?? 0);
            // The null propagation operator (?.) prevents NullReferenceException by safely accessing members.
            #endregion

            // Task 12
            #region Task12
            Console.WriteLine("Enter a day of the week:");
            string day = Console.ReadLine();
            int dayNumber = day switch
            {
                "Monday" => 1,
                "Tuesday" => 2,
                "Wednesday" => 3,
                "Thursday" => 4,
                "Friday" => 5,
                "Saturday" => 6,
                "Sunday" => 7,
                _ => 0
            };
            Console.WriteLine($"Day number: {dayNumber}");
            // Switch expressions are concise and reduce code complexity compared to if statements.
            #endregion

            // Task 13
            #region Task13
            int SumArray(params int[] numbers)
            {
                int sum = 0;
                foreach (var number in numbers)
                {
                    sum += number;
                }
                return sum;
            }

            Console.WriteLine($"Sum: {SumArray(1, 2, 3, 4, 5)}");
            Console.WriteLine($"Sum: {SumArray(new int[] { 1, 2, 3 })}");
            // Params keyword allows passing a variable number of arguments, but all must be of the specified type.
            #endregion

            // Task 14
            #region Task14
            Console.WriteLine("Enter a positive integer:");
            int range = int.Parse(Console.ReadLine());
            for (int i = 1; i <= range; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            #endregion

            // Task 15
            #region Task15
            Console.WriteLine("Enter an integer for multiplication table:");
            int num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine($"{num} x {i} = {num * i}");
            }
            #endregion

            // Task 16
            #region Task16
            Console.WriteLine("Enter a number:");
            int limit = int.Parse(Console.ReadLine());
            for (int i = 1; i <= limit; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
            #endregion
            // Task 23
            #region Task23
            Console.WriteLine("Enter a positive integer:");
            int upperLimit = int.Parse(Console.ReadLine());
            for (int i = 1; i <= upperLimit; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            #endregion

            // Task 24
            #region Task24
            Console.WriteLine("Enter a number for multiplication table:");
            int multiplicationNumber = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine($"{multiplicationNumber} x {i} = {multiplicationNumber * i}");
            }
            #endregion

            // Task 25
            #region Task25
            Console.WriteLine("Enter a number:");
            int evenLimit = int.Parse(Console.ReadLine());
            for (int i = 2; i <= evenLimit; i += 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            #endregion

            // Task 26
            #region Task26
            Console.WriteLine("Enter base number:");
            int baseNumForExponentiation = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter exponent:");
            int exponentForExponentiation = int.Parse(Console.ReadLine());
            Console.WriteLine($"Result: {Math.Pow(baseNumForExponentiation, exponentForExponentiation)}");
            #endregion

            // Task 27
            
            #region Task27
            Console.WriteLine("Enter a string:");
            string inputString = Console.ReadLine();
            char[] reversedString = inputString.ToCharArray();
            Array.Reverse(reversedString);
            Console.WriteLine($"Reversed string: {new string(reversedString)}");
            #endregion

            // Task 28
            #region Task28
            Console.WriteLine("Enter an integer:");
            int inputInteger = int.Parse(Console.ReadLine());
            string reversedInteger = new string(inputInteger.ToString().Reverse().ToArray());
            Console.WriteLine($"Reversed integer: {reversedInteger}");
            #endregion

            // Task 29
            #region Task29
            Console.WriteLine("Enter the size of the array:");
            int arraySize = int.Parse(Console.ReadLine());
            int[] arrayForDistance = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                Console.WriteLine($"Enter element {i + 1}:");
                arrayForDistance[i] = int.Parse(Console.ReadLine());
            }

            int longestDistance = 0;
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = i + 1; j < arraySize; j++)
                {
                    if (arrayForDistance[i] == arrayForDistance[j])
                    {
                        longestDistance = Math.Max(longestDistance, j - i);
                    }
                }
            }
            Console.WriteLine($"Longest distance between matching elements: {longestDistance}");
            #endregion

            // Task 30
            #region Task30
            Console.WriteLine("Enter a sentence:");
            string sentenceToReverse = Console.ReadLine();
            string reversedSentence = string.Join(" ", sentenceToReverse.Split(' ').Reverse());
            Console.WriteLine($"Reversed sentence: {reversedSentence}");
            #endregion

        }
    }
}
