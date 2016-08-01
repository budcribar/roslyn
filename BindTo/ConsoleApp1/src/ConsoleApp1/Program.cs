using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Bind;


public interface ILogger
{
    // ILogger();
    void Log(string text);

    string Name { get; set; }
}

public class Logger : ILogger
{
    public Logger() { }

    public Logger(string name) { Name = name; }

    public Logger(ref string name) { name = "cat"; }
    public string Name { get; set; }


    public void Log(string text) { Console.WriteLine(text); }


}

public class CustomLogger : ILogger
{
    public CustomLogger() { }
    public void Log(string text) { Console.WriteLine("Custom" + text); }

    public string Name { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        bind (ILogger = Logger) {
           ILogger l = new ILogger();
           l.Log("Test");
           Console.Read();
       }

    }
}

