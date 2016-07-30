using System;


public interface ILogger {
  // ILogger();
   void Log(string text);
}

public class Logger : ILogger
{
    public Logger() {}
    public void Log(string text) { Console.WriteLine(text); }

  
}

public class CustomLogger : ILogger
{
    public CustomLogger() { }
    public void Log(string text) { Console.WriteLine("Custom" + text); }
}



