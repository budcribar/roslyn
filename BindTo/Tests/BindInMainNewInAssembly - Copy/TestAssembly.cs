using System;


public interface ILogger {
   //extern ILogger();
   void Log(string text);
}

public class Logger : ILogger
{
    public Logger() {}
    public void Log(string text) {
        
        Console.WriteLine(text ); }

  
}

public class CustomLogger : ILogger
{
    public void Bug()
        {
        Console.WriteLine(A.count);
         var a = new A();
        Console.WriteLine(A.count);
    }
    public CustomLogger() { }
    public void Log(string text) { Console.WriteLine("Custom" + text); }
}

class A
{
    public static int count = 1;
    static A()
    {
        count++;
    }
}

