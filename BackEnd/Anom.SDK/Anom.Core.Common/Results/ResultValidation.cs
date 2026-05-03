namespace Anom.Core.Common.Results;

public sealed class ResultValidation(string attribute, string message)
{
    public string Message { get; private set; } = message;
    public string Attribute { get; private set; } = attribute;
}