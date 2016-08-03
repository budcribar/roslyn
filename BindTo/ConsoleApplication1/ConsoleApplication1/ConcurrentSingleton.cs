using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Singleton
{
    // http://weblogs.asp.net/bsimser/automatically-publishing-nuget-packages-from-github 

    public class ConcurrentSingleton<T>
    {
        private T instance;

        private ConcurrentSingleton()
        {
        }

        private static readonly ConcurrentSingleton<T> hidden = new ConcurrentSingleton<T>();
        public static T Instance { get { return hidden.instance; } }
    }

    public class Dog
    {
        private Dog() { }
        public ConsoleColor Color { get; set; }
    }

    public class Program
    {
        public void Main() {

            Dog d = ConcurrentSingleton<Dog>.Instance;

        }

    }
}
