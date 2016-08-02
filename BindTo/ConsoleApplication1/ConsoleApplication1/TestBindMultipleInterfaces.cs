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

public interface IStatement
{
    void Execute();
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

public class Statement : IStatement
{
    public void Execute() => Console.WriteLine("Statement Executed");
}

public class CustomLogger : ILogger
{
    public void Log(string text) { Console.WriteLine("Custom" + text); }
}

public class Program
{
    public static void Main(string[] args)
    {
       bind (ILogger = CustomLogger, IStatement = Statement) {

            new Executive().Run();
            var stmt = new IStatement();
            
            stmt.Execute();
            Console.Read();
        };

    }
} 

