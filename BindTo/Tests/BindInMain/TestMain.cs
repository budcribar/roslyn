using System;

bind ILogger to CustomLogger;

public class Program
{
    public static void Main(string[] args)
    {
        ILogger l = new ILogger();
        l.Log("Test");
        Console.Read();
    }
} 

