namespace TutorialMemo.Domain.Models;

public sealed class MemoDocument
{
    public string Text { get; set; } = string.Empty;

    public bool IsDirty { get; set; } = false;
}
