using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadsDemo;

namespace DemoApp
{
    public partial class Form1 : Form
    {
        private Account _account;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            _account = new Account();
        }


        private void btnDestroy_Click(object sender, EventArgs e)
        {
            _account = null;
        }

        private void btGC_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void btnBadAsync_Click(object sender, EventArgs e)
        {
            Task t = BadAsync();
            //t.Wait();
            Console.WriteLine("Task Status : {0}", t.Status);
            Console.WriteLine("Task IsFaulted: {0}", t.IsFaulted);
        }

        static async Task BadAsync()
        {
            try
            {
                await Task.Run(() => { throw new Exception(); });
            }
            catch
            {
                Console.WriteLine("Exception in BadAsync");
            }
        }

        private void btnWaitingAsync_Click(object sender, EventArgs e)
        {
            DoRun();
        }

        private void DoRun()
        {
            Task<int> t = CountCharactersAsync("http://www.csharpstar.com", "http://www.techkatak.com");
            tbresult.Text += @"DoRun: Task {0}Finished " + (t.IsCompleted ? "" : "Not ");
            tbresult.Text += @"DoRun: Result = {0}" + t.Result;
            tbresult.Text += @"DoRun: Result = {0}" + t.Result;
        }
        private async Task<int> CountCharactersAsync(string site1, string site2)
        {
            WebClient wc1 = new WebClient();
            WebClient wc2 = new WebClient();
            Task<string> t1 = wc1.DownloadStringTaskAsync(new Uri(site1));
            Task<string> t2 = wc2.DownloadStringTaskAsync(new Uri(site2));
            List<Task<string>> tasks = new List<Task<string>>();
            tasks.Add(t1);
            tasks.Add(t2);
            await Task.WhenAll(tasks);
            tbresult.Text += @" CCA: T1 {0}Finished " + (t1.IsCompleted ? "" : "Not ");
            tbresult.Text += @" CCA: T2 {0}Finished " + (t2.IsCompleted ? "" : "Not ");
            return t1.IsCompleted ? t1.Result.Length : t2.Result.Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = Environment.ProcessorCount;

            MessageBox.Show($"nbre de processeur {c}");
        }

        private void THreadManage_Click(object sender, EventArgs e)
        {
            ThreadManage.Start();

        }

        private void btnManualResetEvnt_Click(object sender, EventArgs e)
        {
            ThreadManage.ManualResetEvnt();
        }

        private void btnAutoResetEvnt_Click(object sender, EventArgs e)
        {
            ThreadManage.AutoResetEvnt();

        }

        private void btnMutex_Click(object sender, EventArgs e)
        {
            ThreadManage.Mutex();

        }

        private void btnSemaphore_Click(object sender, EventArgs e)
        {
            ThreadManage.Semaphore();

        }
    }
    class Account
    {
        public Account()
        {
            MessageBox.Show("Object is created");


        }

        ~Account()
        {
            MessageBox.Show("Object is distroyed");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }


    //The Indexer 
    class Employee
    {
        public string LastName; // Call this field 0.
        public string FirstName; // Call this field 1.
        public string CityOfBirth; // Call this field 2.
        public string this[int index] // Indexer declaration
        {
            set // Set accessor declaration
            {
                switch (index)
                {
                    case 0:
                        LastName = value;
                        break;
                    case 1:
                        FirstName = value;
                        break;
                    case 2:
                        CityOfBirth = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("index");
                }
            }
            get // Get accessor declaration
            {
                switch (index)
                {
                    case 0: return LastName;
                    case 1: return FirstName;
                    case 2: return CityOfBirth;
                    default:
                        throw new ArgumentOutOfRangeException("index");
                }
            }
        }
    }

    class Singleton
    {
        //We create a static variable that will hold the instance of the class.
        private static Singleton _instance;

        private Singleton()
        {
            //To ensure the class has only one instance, we mark the constructor as private. 
            //So, we can only instantiate this class from within the class.
        }
        public static Singleton GetInstance()
        {
            //Then, we create a static method that provides the instance of the singleton class. This method checks
            //if an instance of the singleton class is available.It creates an instance, 
            //if its not available; Otherwise, it returns the available instance.

            return _instance ?? new Singleton();
        }

        //        Issues with the standard implementation
        //The standard singleton implementation code works fine in Single threaded environment.
        //But in multithreaded environment, the GetInstance() code breaks :

    }

    //Handling Multithreading issue with standard singleton implementation

    public sealed class SingletonForMultiThreds
    {
        private static SingletonForMultiThreds _instance;
        private static readonly object Instancelock = new object();

        private SingletonForMultiThreds() { }

        public static SingletonForMultiThreds GetInstance
        {
            get
            {
                lock (Instancelock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonForMultiThreds();
                    }
                    return _instance;
                }
            }
        }
    }

    //    This solves the multithreading issue.But it is slow since only one thread can access GetInstance() method at a time.
    //We can use following approaches for this :




    public sealed class SingletonDoublCheck
    {
        private static SingletonDoublCheck _instance;
        private static readonly object Instancelock = new object();

        private SingletonDoublCheck()
        {
        }

        public static SingletonDoublCheck GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Instancelock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonDoublCheck();
                        }

                    }
                }
                return _instance;
            }
        }

    }
    ////        Early instance creation
    //        //We can choose to create the instance of Singleton class 
    //        //when the class is loaded.This is thread-safe without using locking.


    public class EarlySingleton
    {
        //create instance eagerly
        private static EarlySingleton _instance = new EarlySingleton();

        private EarlySingleton() { }


        public static EarlySingleton GetInstance()
        {
            return _instance;//just return the instance
        }
    }


    //    Singleton Implementation using Generics
    //This will give you a single instance and will effectively be lazy, because 
    //the static constructor doesn’t get called until Build() is called.
    public class GenericSingleton<T> where T : new()
    {
        private static T _msStaticInstance = new T();

        public T GetInstance()
        {
            return _msStaticInstance;
        }
    }

    class Invoke
    {
        public void Method()
        {
            GenericSingleton<SimpleType> instance = new GenericSingleton<SimpleType>();
            SimpleType simple = instance.GetInstance();


            // bellow code casse la notion de singleton en creant un clone de l'instance Hihi
            //clone
            var clone = simple.Clone();
        }

    }

    class SimpleType : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }


        //To avoid creating a clone of our singleton class, we can do the following : 
        protected new object MemberwiseClone()
        {
            throw new Exception("Cloning a singleton object is not allowed");
        }
    }

    //using Lazy<T> type
    //You need to pass a delegate to the constructor which calls the Singleton constructor
    //– which is done most easily with a lambda expression.

    public sealed class LazySingleton
    {
        private static readonly Lazy<LazySingleton> lazy =
            new Lazy<LazySingleton>(() => new LazySingleton());

        public static LazySingleton GetInstance { get { return lazy.Value; } }

        private LazySingleton()
        {
        }
    }

}




