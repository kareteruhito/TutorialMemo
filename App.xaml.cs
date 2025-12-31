
namespace TutorialMemo;

public partial class App : System.Windows.Application
{
    public App()
    {
        // アプリ全体の例外監視（ログ出しだけ。回復はしない）
        this.DispatcherUnhandledException += (s, e) =>
        {
            Infrastructure.Logging.AppLogger.Error(e.Exception);
        };
    }
}
