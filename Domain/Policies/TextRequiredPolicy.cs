using TutorialMemo.Domain.Validation;

namespace TutorialMemo.Domain.Policies;

public sealed class TextRequiredPolicy
{
    public TextValidationResult Validate(string? text)
    {
        return string.IsNullOrWhiteSpace(text)
            ? new(false, "1文字以上入力してください。")
            : new(true, null);
    }
}
