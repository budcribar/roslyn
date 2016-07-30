using System;

bind ILogger to CustomLogger;
bind ILogger to CustomLogger;

public class Program
{
    public static void Bind() { }

    public static void Main(string[] args)
    {
        Logit.Log();
    }
} 

