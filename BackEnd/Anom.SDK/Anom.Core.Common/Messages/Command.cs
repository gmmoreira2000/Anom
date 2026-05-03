using Anom.Core.Common.Results;
using Anom.Core.Utils.Extensios;
using FluentValidation.Results;

namespace Anom.Core.Common.Messages;

public abstract class Command
{
    public ValidationResult ValidationResult { get; set; }

    public abstract bool IsValid();

    public void Validate(Result result)
    {
        IsValid();

        if (!ValidationResult.Errors.IsNullorEmpty())
            ValidationResult.Errors.
                ForEach(x => result.AddValidation(x.ErrorCode, x.ErrorMessage));
        
    }
}