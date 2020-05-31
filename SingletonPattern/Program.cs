using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class Singleton
    {
        private static Singleton instance=null;

        Singleton()
        {

        }
        public static Singleton Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }

    public sealed class SingletonThreadVersion
    {
        private static SingletonThreadVersion instance;
        private static readonly object padlock = new object();

        SingletonThreadVersion()
        {

        }
        public static SingletonThreadVersion Instance
        {
            get
            {
                if(instance==null)
                {
                    lock(padlock)
                    {
                        instance = new SingletonThreadVersion();
                    }
                }
                return instance;
            }
        }
    }
    public sealed class SingletonDoubleLocking
    {
        private static SingletonDoubleLocking instance;
        private static readonly object padlock = new object();

        SingletonDoubleLocking()
        {

        }
        public static SingletonDoubleLocking Instance
        {
            get
            {
                if(instance==null)
                {
                    lock(padlock)
                    {
                        if(instance==null)
                        {
                            instance = new SingletonDoubleLocking();
                        }
                    }
                }
                return instance;
            }
        }
    }
    public sealed class SingletonExample
    {
        private static SingletonExample instance;
        private static readonly object padlock = new object();

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public SingletonExample()
        {
            Latitude = 109.2;
            Longitude = 112.4;
        }
        public double Calculate()
        {
            return Latitude + Longitude;
        }

        static SingletonExample()
        {

        }
        public static SingletonExample Instance
        {
            get
            {
                if(instance==null)
                {
                    lock(padlock)
                    {
                        if(instance==null)
                        {
                            instance = new SingletonExample();
                        }
                    }
                }
                return instance;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Latitude + Longitude ="+ SingletonExample.Instance.Calculate());
            Console.Read();
        }
    }
}
