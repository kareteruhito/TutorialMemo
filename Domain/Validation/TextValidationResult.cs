namespace TutorialMemo.Domain.Validation;

public readonly record struct TextValidationResult(bool IsValid, string? ErrorMessage);
