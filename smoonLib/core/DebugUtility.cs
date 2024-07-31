namespace smoonLib.core;

public static class DebugUtility
{
    private static void DebugConsole(string message, ConsoleColor colorText)
    {
        Console.ForegroundColor = colorText;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    
    public static void DebugLog(string message)
    {
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void DebugWarning(string message)
    {
        DebugConsole(message, ConsoleColor.Yellow);
    }
    
    public static void DebugError(string message)
    {
        DebugConsole(message, ConsoleColor.Red);
    }
    
    public static void DebugCorrect(string message)
    {
        DebugConsole(message, ConsoleColor.Green);
    }
    
    public static void DebugException(string message)
    {
        throw new Exception(message);
    } 
}