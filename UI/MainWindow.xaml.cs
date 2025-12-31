using System.Windows;
using TutorialMemo.Application.ViewModels;

namespace TutorialMemo.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}
