using System;
using System.Threading;
using System.Threading.Tasks;

namespace RaceCondition
{

    //Let’s look at the below example, where we have a shared variable counter and 2 threads are trying to increment value for this shared variable at same time.
    //    Output:
    //The output for above program can be any combination of* and + or first 5 stars and then 5 plus because the operating system decides which thread gets 
    //executed first.so depending on the order of thread execution the output will be printed to console.It will surely print characters[*, +], but order maybe inconsistent.
    //Since the program output is inconsistent, you can’t rely on the output in your application. So let’s see how to avoid this Race condition in C#.

    //Using Thread
    class ProgramThread
    {
        private static int counter;
        static void MainTread(string[] args)
        {
            Thread T1 = new Thread(PrintStar);
            T1.Start();

            Thread T2 = new Thread(PrintPlus);
            T2.Start();

            Console.ReadLine();
        }
        static void PrintStar()
        {
            for (counter = 0; counter < 5; counter++)
            {
                Console.Write(" * " + "\t");
            }
        }

        private static void PrintPlus()
        {
            for (counter = 0; counter < 5; counter++)
            {
                Console.Write(" + " + "\t");
            }
        }
    }
    //Using TPL
    class ProgramTpl
    {
        private static int counter;
        static void MainTpl(string[] args)
        {
            Task.Factory.StartNew(PrintStar);
            Task.Factory.StartNew(PrintPlus);
            Console.ReadLine();
        }
        static void PrintStar()
        {
            for (counter = 0; counter < 5; counter++)
            {
                Console.Write(" * " + "\t");
            }
        }

        private static void PrintPlus()
        {
            for (counter = 0; counter < 5; counter++)
            {
                Console.Write(" + " + "\t");
            }
        }
    }


    //    How to avoid this Race condition in C#?
    //To ensure that the program always display consistent output, we need to write additional code using thread synchronization method.
    //There are several ways to implement Synchronization in C#.

    //1. Synchronization using Thread.Join()
    //Thread.Join method blocks the calling thread until the executing thread terminates.In the program below 
    //we have executed Thread1.Join method before the declaration of thread2, which ensures that delegate associated 
    //with thread1 get executes first before thread2 starts.In this case we always gets consistent output and eliminates race condition.

    class ProgramThreadJoin
    {
        private static int counter;
        static void MainJoin(string[] args)
        {
            var T1 = new Thread(PrintStar);
            T1.Start();
            T1.Join();

            var T2 = new Thread(PrintPlus);
            T2.Start();
            T2.Join();

            // main thread will always execute after T1 and T2 completes its execution
            Console.WriteLine("Ending main thread");
            Console.ReadLine();
        }
        static void PrintStar()
        {
            for (counter = 0; counter < 5; counter++)
            {
                Console.Write(" * " + "\t");
            }
        }

        private static void PrintPlus()
        {
            for (counter = 0; counter < 5; counter++)
            {
                Console.Write(" + " + "\t");
            }
        }
    }




    //2.Synchronization using Task.ContinueWith
    //TPL continue method is useful to start a task after another one completes its execution.

    class ProgramTPLContinue
    {
        private static int counter;
        static void MainTplCOntinue(string[] args)
        {
            Task T1 = Task.Factory.StartNew(PrintStar);
            Task T2 = T1.ContinueWith(antacedent => PrintPlus());

            Task.WaitAll(new Task[] { T1, T2 });

            Console.WriteLine("Ending main thread");
        }
        static void PrintStar()
        {
            for (counter = 0; counter < 5; counter++)
            {
                Console.Write(" * " + "\t");
            }
        }

        private static void PrintPlus()
        {
            for (counter = 0; counter < 5; counter++)
            {
                Console.Write(" + " + "\t");
            }
        }
    }


    //    3. Synchronization using Lock
    //Using Lock statement you can ensure only one thread can be executed at any point of time.
    class ProgramThreadLock
    {
        static object locker = new object();
        private static int counter;
        static void MainLock(string[] args)
        {
            new Thread(PrintStar).Start();
            new Thread(PrintPlus).Start();
        }

        static void PrintStar()
        {
            lock (locker) // Thread safe code
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" * " + "\t");
                }
            }
        }

        static void PrintPlus()
        {
            lock (locker) // Thread safe code
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" + " + "\t");
                }
            }
        }
    }

    //    4. Synchronization using Monitor Enter – Monitor Exit
    //This works exactly like Lock statement.

    class ProgramMonitor
    {
        static object locker = new object();
        private static int counter;

        static void Main(string[] args)
        {
            new Thread(PrintStar).Start();
            new Thread(PrintPlus).Start();
        }

        static void PrintStar()
        {
            Monitor.Enter(locker);
            try
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" + " + "\t");
                }
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }

        static void PrintPlus()
        {
            Monitor.Enter(locker);
            try
            {
                for (counter = 0; counter < 5; counter++)
                {
                    Console.Write(" - " + "\t");
                }
            }
            finally
            {
                Monitor.Exit(locker);
            }
        }
    }

}
