using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Singleton
{
    // http://weblogs.asp.net/bsimser/automatically-publishing-nuget-packages-from-github 

    public class Singleton<T> where T:new()
    {
        private T instance;

        private Singleton()
        {
        }

        private static readonly Singleton<T> hidden = new Singleton<T>();
        public static T Instance { get {
                if (hidden.instance == null)
                    hidden.instance = new T();
                return hidden.instance;
            } }
    }
    interface IAnimal
    {
        IAnimal();
        void Speak();
    }
    public abstract class Dog : IAnimal
    {
        public Dog() { }
        public void Speak() { Console.WriteLine("Bark"); }
    }
        public class Cat : IAnimal
        {
            
            public void Speak() { Console.WriteLine("Meow"); }
        }

        public class Program
    {
        public static void Main(string[] args)
        {


            bind(IAnimal = Cat)
        {
                IAnimal a = Singleton<IAnimal>.Instance;
                a.Speak();
                //bind(IAnimal = Dog) a.Speak();

                //bind (IAnimal = Cat)
                //{
                //    a.Speak();
                //}
                //}


            }
        }
    }
}
