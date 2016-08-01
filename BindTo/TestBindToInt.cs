using System;
using System.IO;
using System.Collections.Generic;

public class Executive
{
    public void Run()
    {
        var l = new ILogger();
        l.Log("Test");
    }

}

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
       
         bind(int = int) {

            new Executive().Run();
          
            Console.Read();
        };

    }
} 

