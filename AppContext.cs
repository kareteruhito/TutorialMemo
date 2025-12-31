namespace TutorialMemo;

public static class AppContext
{
    public static string AppName => "TutorialMemo";

#if DEBUG
    public static bool IsDebug => true;
#else
    public static bool IsDebug => false;
#endif
}