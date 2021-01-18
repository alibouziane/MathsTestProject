using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsDemo
{
    public class ThreadManage
    {
        private static int _throw;
        private static object _locker = new object();
        //     true to set the initial state signaled; false to set the initial state to nonsignaled.
        private static ManualResetEvent _mre = new ManualResetEvent(false);//applied for exapmle whe read and write at the same time
        private static AutoResetEvent _are = new AutoResetEvent(true);//applied for exapmle whe write is done by several threads
        private static Mutex _mutex = new Mutex();




        //   initialCount: The initial number of requests for the semaphore that can be granted concurrently.
        //   maximumCount: The maximum number of requests for the semaphore that can be granted concurrently.
        private static Semaphore _semaphore = new Semaphore(initialCount: 1, maximumCount: 1);// how many thread we want to run in parallel min:max min doit etre < max




        /// <summary>
        /// le semaphore est un system de signalisation et non pas de verouillage (LOCK)
        /// il control sur le nombre de thread à etre executé en meme temps
        /// </summary>
        public static void Semaphore()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(WriteSemaphore).Start();
            }
        }

        private static void WriteSemaphore()
        {
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Writing ...");
            _semaphore.WaitOne();
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Writing ...");
            Thread.Sleep(5000);
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Writing COMPLETED");
            _semaphore.Release();

        }

        public static void Mutex()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(WriteMutex).Start();
            }

            // vas levé une exception car le mutex ne pourra etre délocké que par le thread qui loqyué
            // on peut pas deloqué un mutex d el'exterieuer
            //Thread.Sleep(5000);
            //_mutex.ReleaseMutex();
        }






        private static void WriteMutex()
        {
            //only one thread whill be autorised
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Writing ...");
            _mutex.WaitOne();
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Writing ...");
            Thread.Sleep(5000);
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Writing COMPLETED");
            _mutex.ReleaseMutex();

            // le meme thread doit deloquer ce qui a locké: le lock doit eter delocké par le meme thread qui a locké 
        }


        public static void AutoResetEvnt()
        {
            //starting writer thread
            for (int i = 0; i < 5; i++)
            {
                new Thread(WriteAutoReset).Start();
            }
            Thread.Sleep(5000);
            _are.Set();// ici le delock peut se faire via un thread different du thread qui a loqué

        }

        public static void WriteAutoReset()
        {
            //only one thread whill be autorised
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Writing ...");
            _are.WaitOne();
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Writing ...");
            Thread.Sleep(5000);
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Writing COMPLETED");
            _are.Set();
        }

        /// <summary>
        /// threads are writing at the same time other threads are reading
        /// </summary>
        public static void ManualResetEvnt()
        {
            //au moment du writing nous voulons que la lecture ne se fera pas.
            //starting writer thread
            new Thread(Write).Start();
            for (int i = 0; i < 5; i++)
            {
                new Thread(Read).Start();
            }

        }

        public static void Start()
        {
            _throw = 1;
            for (int i = 0; i <= 5; i++)
            {
                new Thread(DoWOrkWithLock).Start();
                new Thread(DoWOrkWithMonitor).Start();
            }
        }



        public static void Write()
        {
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Writing ...");
            _mre.Reset();//au moment du writing nous voulons que la lecture ne se fera pas.
            Thread.Sleep(5000);
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Writing COMPLETED");
            _mre.Set();//send a signal to all treads using the same mre
        }
        public static void Read()
        {
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Waiting ...");
            _mre.WaitOne();//waiting until obtaining the signal from the write thread (_mre.Set)
            Thread.Sleep(5000);
            Console.WriteLine($"Thread{Thread.CurrentThread.ManagedThreadId } Reading");
        }

        private static void DoWOrkWithLock()
        {
            lock (_locker)
            {

                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Starting..");
                Thread.Sleep(2000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Completed");
            }
        }
        private static void DoWOrkWithLockLocjReleasedwhenexceptionisthrown()
        {
            lock (_locker)
            {
                try
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Starting..");

                    Thread.Sleep(2000);
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Completed");
                    if (_throw == 1) throw (new Exception());
                }
                catch
                {
                    _throw++;

                }


            }

        }

        private static void DoWOrkWithMonitor()
        {
            try
            {
                Monitor.Enter(_locker);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Starting..");
                Thread.Sleep(2000);
                //throw (new Exception());
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Completed");
            }
            catch
            {
                //
            }
            finally
            {
                Monitor.Exit(_locker);
            }

        }



    }

}

