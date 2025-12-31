using System;
using System.Diagnostics;

namespace TutorialMemo.Infrastructure.Logging;

public static class AppLogger
{
    public static event Action<string>? Log;

    public static void Info(string msg)
    {
        Write("INFO", msg);
    }

    public static void Error(Exception ex)
    {
        Write("ERROR", ex.ToString());
    }

    private static void Write(string level, string msg)
    {
        var line = $"[{level}] {msg}";
        Debug.WriteLine(line);
        Log?.Invoke(line);
    }
}
