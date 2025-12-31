using System.IO;
using System.Text;
using TutorialMemo.Infrastructure.Config;
using TutorialMemo.Infrastructure.Logging;

namespace TutorialMemo.Infrastructure.Storage;

public sealed class FixedFileStorage
{
    private static readonly Encoding Utf8NoBom
        = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

    public string Load()
    {
        if (!File.Exists(AppPaths.MemoFilePath))
            return string.Empty;

        return File.ReadAllText(AppPaths.MemoFilePath, Utf8NoBom);
    }

    public void Save(string text)
    {
        Directory.CreateDirectory(AppPaths.DataDirectory);
        File.WriteAllText(AppPaths.MemoFilePath, text, Utf8NoBom);
        AppLogger.Info("保存しました");
    }
}
