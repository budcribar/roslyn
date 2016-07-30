using System;
bind ILogger to Logger;
public class Logit
{
    public static void Log()
    {
        Program.Bind();
        ILogger l = new ILogger();
        l.Log("Test");
        Console.Read();
    }
} 

