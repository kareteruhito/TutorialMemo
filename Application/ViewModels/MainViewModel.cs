using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TutorialMemo.Application.Commands;
using TutorialMemo.Domain.Models;
using TutorialMemo.Domain.Policies;
using TutorialMemo.Infrastructure.Storage;

namespace TutorialMemo.Application.ViewModels;

public sealed class MainViewModel : INotifyPropertyChanged
{
    private readonly FixedFileStorage _storage = new();
    private readonly TextRequiredPolicy _policy = new();

    private string _text = string.Empty;
    private string _error = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainViewModel()
    {
        SaveCommand = new RelayCommand(Save, CanSave);
        Load();
    }

    public string Text
    {
        get => _text;
        set
        {
            if (_text == value) return;
            _text = value;
            Validate();
            OnPropertyChanged();
            Validate();
        }
    }

    public string ErrorMessage
    {
        get => _error;
        private set
        {
            _error = value;
            OnPropertyChanged();
        }
    }

    public ICommand SaveCommand { get; }

    private void Load()
    {
        Text = _storage.Load();
    }

    private void Save()
    {
        _storage.Save(Text);
    }

    private bool CanSave()
    {
        return _policy.Validate(Text).IsValid;
    }

    private void Validate()
    {
        var result = _policy.Validate(Text);
        ErrorMessage = result.IsValid ? string.Empty : result.ErrorMessage!;

        (SaveCommand as RelayCommand)?.RaiseCanExecuteChanged();
    }

    private void RaiseCommands()
    {
        (SaveCommand as RelayCommand)?.RaiseCanExecuteChanged();
    }

    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
