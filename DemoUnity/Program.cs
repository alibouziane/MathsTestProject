using System;
using Unity;

namespace DemoUnity
{
    class Program
    {
        //UI
        static void Main(string[] args)
        {
            IUnityContainer objContainer = new UnityContainer();
            objContainer.RegisterType<Customer>();
            objContainer.RegisterType<IDal, SqlserverDAl>();
            //objContainer.RegisterType<IDal, OracleDal>();


            Customer obj = objContainer.Resolve<Customer>();
            obj.CustomerName = "test";
            obj.Add();
        }
        //Middle Layer
        public class Customer
        {
            private readonly IDal _iobjDal;
            public string CustomerName { get; set; }

            public Customer(IDal iobjDal)
            {
                _iobjDal = iobjDal;
            }
            public void Add()
            {
                _iobjDal.Add();
            }

        }

        //DAl
        public class SqlserverDAl : IDal

        {
            public void Add()
            {
                Console.WriteLine("SQL server inserted");
            }

        }
        public class OracleDal : IDal
        {
            public void Add()
            {
                Console.WriteLine("Oracle inserted");

            }
        }


        public interface IDal
        {
            void Add();
        }

    }


}
