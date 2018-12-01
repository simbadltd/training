using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGm
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteTask("[Task #1]", Task1);
            ExecuteTask("[Task #2]", Task2);
            ExecuteTask(
                "[Task #3]",
                () =>
                {
                    Task3('a', 'b', 'c', 'd', 'f');
                    Task3('O', 'Q', 'R', 'S');
                });

            ExecuteTask("[Task #4]", Task4);
        }

        private static void Task1()
        {
            var results = new List<string>();

            for (int i = 0; i <= 127; i++)
            {
                var isMultipleOf3 = i % 3 == 0;
                var isMultipleOf5 = i % 5 == 0;

                if (isMultipleOf3 && isMultipleOf5)
                {
                    results.Add("GreenMoney");
                }
                else if (isMultipleOf3)
                {
                    results.Add("Green");
                }
                else if (isMultipleOf5)
                {
                    results.Add("Money");
                }
                else
                {
                    results.Add(i.ToString());
                }
            }

            Console.WriteLine(string.Join("; ", results));
        }

        private static void Task2()
        {
            var results = new List<string>();
            var sum = 0D;
            var randomize = new Random();

            while (sum < 1D)
            {
                // [kk]: to avoid sum to be greater than 1D, we should calculate <maxLimit> depending on current value of <sum>
                var maxLimit = Math.Min(1D - sum, 0.6D);
                var candidate = Math.Round(randomize.NextDouble() * maxLimit, 2);
                sum += candidate;

                results.Add(candidate.ToString("F2"));
            }

            Console.WriteLine(string.Join("; ", results));
        }

        private static void Task3(params char[] input)
        {
            // [kk] Assumption: input is not null, ordered and have at least 1 char
            var start = (int)input.First();

            for (int i = 1; i < input.Length; i++)
            {
                var expectedCharCode = start + i;
                var actualCharCode = (int)input[i];
                if (expectedCharCode != actualCharCode)
                {
                    Console.WriteLine((char)expectedCharCode);
                    break;
                }
            }
        }

        private static void Task4()
        {
            var a1 = new[] { 1, 4, 6, 7, 9, 17, 14, 22, 324, 550, 670, 890, 201, 84 };
            var a2 = new[] { 203, 4, 321, 102, 9, 73, 14, 22, 32, 521 };

            var result = a1.Intersect(a2).Select(x => new { number = x, sqr = Math.Pow(x, 2) });

            foreach (var item in result)
            {
                Console.WriteLine($"({item.number}, {item.sqr})");
            }
        }

        private static void ExecuteTask(string taskName, Action task)
        {
            Console.WriteLine(taskName);

            task();

            Console.WriteLine("Please press enter to continue...");
            Console.ReadLine();
        }
    }
}