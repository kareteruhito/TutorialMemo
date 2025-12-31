using TutorialMemo.Domain;
using TutorialMemo.Domain.Validation;

namespace TutorialMemo.Domain.Policies;

public sealed class TextRequiredPolicy
{
    public TextValidationResult Validate(string? text)
    {
        if (text == null || text.Trim().Length < DomainConstants.MinTextLength)
        {
            return new(
                false,
                $"{DomainConstants.MinTextLength}文字以上入力してください。"
            );
        }

        return new(true, null);
    }
}
