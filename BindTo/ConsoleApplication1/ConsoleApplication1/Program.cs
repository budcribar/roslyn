using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

public interface ILogger
{
    // ILogger();
    void Log(string text);
}

public class Logger : ILogger
{
    public void Log(string text) { Console.WriteLine(text); }
}

public class CustomLogger : ILogger
{
    public void Log(string text) { Console.WriteLine("Custom" + text); }
}

public class Program
{
    public static void Main(string[] args)
    {
        bind (ILogger = CustomLogger)
        {
            ILogger l = new ILogger();

            l.Log("Test");
            Console.Read();
        };

    }
}

