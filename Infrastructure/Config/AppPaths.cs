using System;
using System.IO;

namespace TutorialMemo.Infrastructure.Config;

public static class AppPaths
{
    // AppData配下に固定ファイル
    public static string DataDirectory =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        TutorialMemo.AppContext.AppName);

    public static string MemoFilePath => Path.Combine(DataDirectory, "memo.txt");
}
