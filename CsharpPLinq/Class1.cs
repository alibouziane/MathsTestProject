using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPLinq
{
    namespace CsharpPLinq
    {
        class CsharpPLinqExample
        {
            static void Main()
            {
                for (var i = 1; i <= 1; i++)
                {
                    var myRange = Enumerable.Range(1, 1000000);

                    Console.WriteLine("Processing..");

                    var stopwatch = Stopwatch.StartNew();

                    var result = myRange.Select(x => x);

                    stopwatch.Stop();

                    Console.WriteLine("Time: {0:FFFFFFF}", stopwatch.Elapsed);

                    myRange = null;
                    result = null;
                }

                Console.WriteLine();

                Console.WriteLine("Parallel Processing..");

                for (var i = 1; i <= Environment.ProcessorCount; i++)
                {
                    var myRange = Enumerable.Range(1, 1000000);

                    var stopWatch = Stopwatch.StartNew();

                    var result = myRange.AsParallel()
                            .WithDegreeOfParallelism(i)
                            .Select(x => x);

                    stopWatch.Stop();

                    Console.WriteLine("Number of cores: {0} Time: {1:FFFFFFF}", i, stopWatch.Elapsed);

                    myRange = null;
                    result = null;
                }

                Console.WriteLine();

                Console.WriteLine("Processing and calling .ToList()");

                for (var i = 1; i <= Environment.ProcessorCount; i++)
                {
                    var myRange = Enumerable.Range(1, 1000000);

                    var stopWatch = Stopwatch.StartNew();

                    var result = myRange.AsParallel()
                           .WithDegreeOfParallelism(i)
                           .Select(x => x).ToList();

                    stopWatch.Stop();

                    Console.WriteLine("Number of cores: {0} Time: {1:FFFFFFF}", i, stopWatch.Elapsed);

                    myRange = null;
                    result = null;
                }

                Console.WriteLine();

                Console.WriteLine("Processing and calling .ToList() after PLINQ execution");

                for (var i = 1; i <= Environment.ProcessorCount; i++)
                {
                    var myRange = Enumerable.Range(1, 1000000);

                    var stopWatch = Stopwatch.StartNew();

                    var result = myRange.AsParallel()
                           .WithDegreeOfParallelism(i)
                           .Select(x => x);

                    result.ToList();

                    stopWatch.Stop();

                    Console.WriteLine("Number of cores: {0} Time: {1:FFFFFFF}", i, stopWatch.Elapsed);

                    myRange = null;
                    result = null;
                }


                Console.ReadKey();
            }
        }
    }
}
