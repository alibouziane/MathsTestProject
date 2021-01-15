using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Method1();
            //Method2();
            //Traditional ways of Returning a value from Task in C# (4.0):
            Tasks_Without_Input_parameter();
            Tasks_With_Input_parameter();
            //New ways of Returning a value from Task in C# (4.5):
            Task_Using_Task_RunAsync();
            Task_Using_TaskFactory_StartNewAsync();
            Task_Using_Task_FromResultAsync();

        }

        private static async void Task_Using_Task_FromResultAsync()
        {
            int res = await Task.FromResult<int>(ReturnSum(10, 20));
        }



        private static async void Task_Using_TaskFactory_StartNewAsync()
        {
            Func<int> function = new Func<int>(() => ReturnSum(10, 20));
            int res = await Task.Factory.StartNew<int>(function);
        }

        private static async void Task_Using_Task_RunAsync()
        {
            Func<int> function = new Func<int>(() => ReturnSum(10, 20));
            int res = await Task.Run<int>(function);
        }


        private static int ReturnSum(int a, int b)
        {
            return a + b;
        }


        private static void Tasks_Without_Input_parameter()
        {
            Task<int> task = new Task<int>(() =>
            {
                int total = 0;
                for (int i = 0; i < 10; i++)
                {
                    total += i;
                }
                return total;
            });

            task.Start();
            int result = Convert.ToInt32(task.Result);
        }

        private static void Tasks_With_Input_parameter()
        {
            Task<int> task = new Task<int>(obj =>
            {
                int total = 0;
                int max = (int)obj;
                for (int i = 0; i < max; i++)
                {
                    total += i;
                }
                return total;
            }, 10);

            task.Start();
            int result = Convert.ToInt32(task.Result);
        }

        private static void Method2()
        {
            int comp1;
            int max;
            ThreadPool.GetMaxThreads(out max, out comp1);
            int comp2;
            int min;
            ThreadPool.GetMinThreads(out min, out comp2);
            int comp3;
            int ava;
            ThreadPool.GetAvailableThreads(out ava, out comp3);


            Console.WriteLine($"maxThread : {max}");
            Console.WriteLine($"minThread : {min}");
            Console.WriteLine($"avaThread : {ava}");

            Task.Run(() => Thread.Sleep(2000));
            ThreadPool.GetAvailableThreads(out ava, out comp3);
            Console.WriteLine($"new avaThread : {ava}");

            Console.Read();
        }

        private static void Method1()
        {
            var wrap1 = new IntWrappe();
            var wrap2 = new IntWrappe();
            var wrap3 = new IntWrappe();
            wrap1.wrappredInt = 1;
            wrap2.wrappredInt = 2;
            wrap3.wrappredInt = 3;
            GC.Collect();
            wrap2 = null;
            GC.Collect();



            wrap1 = null;

            Parallel.For(0, 1000000, x => RunMillionIterations());

            var one = new Thread(RunMillionIterations) { Name = "One" };
            var two = new Thread(RunMillionIterations) { Name = "Two" };

            one.Start();
            two.Start();

            Console.Read();

        }



        private static void RunMillionIterations()
        {
            var x = "";
            for (int i = 0; i < 1000000; i++)
            {
                x = x + "s";
            }
        }

        class IntWrappe
        {
            public int wrappredInt { get; set; }

            public IntWrappe()
            {
                //Console.Write("object created");
            }

            ~IntWrappe()
            {
                //Console.Write("object destroyed");

            }
        }
    }
}






