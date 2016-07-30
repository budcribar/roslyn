using System;
bind ILogger to Logger;
public class Logit
{
    public static void Log()
    {
        var cl = new CustomLogger();
        cl.Bug();

        ILogger l = new ILogger();
        l.Log("Test");
        Console.Read();
    }
} 

